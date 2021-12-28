using System.Diagnostics;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MVC_client.Models;

namespace MVC_client.Controllers;
[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5301");
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
        client.SetBearerToken(accessToken);
        var response = await client.GetAsync("https://localhost:6501/identity");
        var content = await response.Content.ReadAsStringAsync();

        return View("Index",content);
    }

    
    public async Task<IActionResult> Privacy()
    {
        var refreshToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
        var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
        var authorizationCode = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.Code);
        var idToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
        var type = HttpContext.User.Identity?.AuthenticationType;

        ViewData["accessToken"] = accessToken;
        ViewData["refreshToken"] = refreshToken;
        ViewData["idToken"] = idToken;
        ViewData["type"] = type;
        return View();
    }
    
    public async Task Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}