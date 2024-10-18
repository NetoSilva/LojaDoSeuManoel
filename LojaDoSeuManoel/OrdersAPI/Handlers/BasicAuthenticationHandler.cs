using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using PedidosAPI.NewFolder;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace PedidosAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly TimeProviderService _timeProviderService;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, TimeProviderService timeProviderService)
            : base(options, logger, encoder)
        {
            _timeProviderService = timeProviderService ?? throw new ArgumentNullException(nameof(timeProviderService));
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var header = Request.Headers["Authorization"].ToString();
            if (header != null && header.StartsWith("Basic "))
            {
                var encodedUsernamePassword = header.Substring("Basic ".Length).Trim();
                var usernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
                var username = usernamePassword.Split(':')[0];
                var password = usernamePassword.Split(':')[1];

                // Verificação de autenticação (substituir com a lógica real)
                if (username == "admin" && password == "teste")
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, username) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
            }

            return Task.FromResult(AuthenticateResult.Fail("Falha na autenticação"));
        }

    }
}