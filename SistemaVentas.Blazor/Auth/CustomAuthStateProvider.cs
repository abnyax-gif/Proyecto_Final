using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace SistemaVentas.Blazor.Auth;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _js;
    private AuthenticationState _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public CustomAuthStateProvider(IJSRuntime js)
    {
        _js = js;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {
            var userRole = await _js.InvokeAsync<string>("localStorage.getItem", "user_role");
            var userName = await _js.InvokeAsync<string>("localStorage.getItem", "user_name");

            if (string.IsNullOrEmpty(userRole))
            {
                return _anonymous;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName ?? "Usuario"),
                new Claim(ClaimTypes.Role, userRole)
            };

            var identity = new ClaimsIdentity(claims, "CustomAuth");
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
        catch
        {
            return _anonymous;
        }
    }

    public async Task MarcarComoAutenticado(string usuario, string rol)
    {
        await _js.InvokeVoidAsync("localStorage.setItem", "user_name", usuario);
        await _js.InvokeVoidAsync("localStorage.setItem", "user_role", rol);
        await _js.InvokeVoidAsync("localStorage.setItem", "session_event", "login_" + DateTime.Now.Ticks);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario),
            new Claim(ClaimTypes.Role, rol)
        };

        var identity = new ClaimsIdentity(claims, "CustomAuth");
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public async Task MarcarComoCerradoSesion()
    {
        await _js.InvokeVoidAsync("localStorage.removeItem", "user_name");
        await _js.InvokeVoidAsync("localStorage.removeItem", "user_role");
        await _js.InvokeVoidAsync("localStorage.setItem", "session_event", "logout_" + DateTime.Now.Ticks);

        NotifyAuthenticationStateChanged(Task.FromResult(_anonymous));
    }

    // Alias de compatibilidad para MainLayout.razor
    public async Task MarkUserAsLoggedOut()
    {
        await MarcarComoCerradoSesion();
    }
}