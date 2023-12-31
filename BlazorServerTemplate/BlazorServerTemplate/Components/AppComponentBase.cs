﻿using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
//using Shared.Resources;

namespace BlazorServerTemplate.Components
{
    public partial class AppComponentBase : ComponentBase
    {
        [Inject] protected IJSRuntime JsRuntime { get; set; } = default!;
        [Inject] protected IWebServiceClient WebServiceClient { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        [Inject] protected IAuthTokenProvider AuthTokenProvider { get; set; } = default!;
        [Inject] protected IAuthenticationService AuthenticationService { get; set; } = default!;
        [Inject] protected AppAuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
        //[Inject] protected IStringLocalizer<General> Localizer { get; set; } = default!;


    }
}
