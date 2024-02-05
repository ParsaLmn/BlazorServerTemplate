using Application.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Services
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthTokenProvider _tokenProvider;

        public AppAuthenticationStateProvider(IAuthTokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public async Task RaiseAuthenticationStateHasChanged()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(await GetAuthenticationStateAsync()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var access_token = await _tokenProvider.GetAcccessTokenAsync();

            if (string.IsNullOrWhiteSpace(access_token)) return NotSignedIn();
            if (!IsValidToken(access_token)) return NotSignedIn();

            var identity = new ClaimsIdentity(claims: ParseTokenClaims(access_token), authenticationType: "Bearer");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public async Task<bool> IsUserAuthenticatedAsync()
        {
            return (await GetAuthenticationStateAsync()).User.Identity?.IsAuthenticated == true;
        }

        private AuthenticationState NotSignedIn()
        {
            _tokenProvider.RemoveAcccessTokenAsync();
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        private IEnumerable<Claim> ParseTokenClaims(string access_token)
        {
            return Jose.JWT.Payload<Dictionary<string, object>>(access_token)
                .Select(keyValue => new Claim(keyValue.Key, keyValue.Value.ToString() ?? string.Empty))
                .ToArray();
        }
        private bool IsValidToken(string token)
        {
            JwtSecurityToken jwtSecurityToken;
            try
            {
                jwtSecurityToken = new JwtSecurityToken(token);
            }
            catch (Exception)
            {
                return false;
            }

            return jwtSecurityToken.ValidTo > DateTime.UtcNow;
        }
    }
}
