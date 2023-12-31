﻿using System.Globalization;
using Microsoft.JSInterop;

public static class WebAssemblyHostExtension
{
    public async static Task SetDefaultCulture(this WebApplication host)
    {
        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
        var result = await jsInterop.InvokeAsync<string>("getBlazorCulture");
        CultureInfo culture;
        if (result != null)
            culture = new CultureInfo(result);
        else
            culture = new CultureInfo("fa-IR");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}

