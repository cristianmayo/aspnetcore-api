using AspNetCore.API.TransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AspNetCore.API.Core.Enumerations;
using AspNetCore.API.Infrastructure.Services;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUserService _userService;
        private readonly IClientApplicationService _clientService;
        private readonly IClientUserSessionService _sessionService;

        public AuthController(
            IApplicationUserService userService,
            IClientApplicationService clientService,
            IClientUserSessionService sessionService
        )
        {
            _userService = userService;
            _clientService = clientService;
            _sessionService = sessionService;
        }


        [HttpPost("check")]
        public async Task<AuthCheckResponse> CheckClientAndUserAuthorizationAsync(AuthRequest request)
        {
            try {
                if(request.ClientId == Guid.Empty) {
                    return new AuthCheckResponse { AuthCheckResult = (int)AuthCheckResult.InvalidClientId };
                }

                if(string.IsNullOrWhiteSpace(request.UserName)) {
                    return new AuthCheckResponse { AuthCheckResult = (int)AuthCheckResult.InvalidUserName };
                }

                var isAuthorizedClient = await _clientService.IsAuthorizedClient(request.ClientId);
                if(!isAuthorizedClient) {
                    return new AuthCheckResponse {
                        AuthCheckResult = (int)AuthCheckResult.UnauthorizedClient,
                        AuthorizedClient = isAuthorizedClient
                    };
                }

                var isValidUsername = await _userService.IsValidUsernameAsync(request.UserName);
                if(!isValidUsername) {
                    return new AuthCheckResponse {
                        AuthCheckResult = (int)AuthCheckResult.UnauthorizedUser,
                        AuthorizedClient = isAuthorizedClient,
                        ValidUsername = isValidUsername
                    };
                }

                var user = await _userService.GetApplicationUserByUserNameAsync(request.UserName);

                return new AuthCheckResponse {
                    AuthCheckResult = (int)AuthCheckResult.AuthorizedClientAndUser,
                    AuthorizedClient = isAuthorizedClient,
                    ValidUsername = isValidUsername,
                    UserId = user.UserId
                };
            }
            catch(Exception) {
                throw;
            }
        }

        [HttpPost("login")]
        public async Task<LoginResponse> LoginClientAndUserAsync(LoginRequest request)
        {
            try {

                if(request.ClientId == Guid.Empty || request.UserId == Guid.Empty || string.IsNullOrWhiteSpace(request.Password)) {
                    return new LoginResponse {
                        AuthValidationResult = (int)AuthValidationResult.InvalidRequest,
                        StatusCode = StatusCodes.Status400BadRequest,
                        StatusMessage = $"IdentityCliet.Auth.LoginClientAndUserAsync: " +
                                        $"Invalid request parameter(s)."
                    };
                }

                var authorizedUser = await _userService.IsAuthorizedUserAsync(request.UserId);

                if(!authorizedUser) {
                    return new LoginResponse {
                        AuthValidationResult = (int)AuthValidationResult.UnauthorizedAccess,
                        StatusCode = StatusCodes.Status401Unauthorized,
                        StatusMessage = $"IdentityCliet.Auth.LoginClientAndUserAsync: " +
                                        $"Unauthorized User using \"{request.UserId}\" UserId."
                    };
                }

                var haveValidCredentials = await _userService.IsValidUserCredentialsAsync(request.UserId, request.Password);

                if(!haveValidCredentials) {
                    return new LoginResponse {
                        AuthValidationResult = (int)AuthValidationResult.InvalidCredentials,
                        StatusCode = StatusCodes.Status400BadRequest,
                        StatusMessage = $"IdentityCliet.Auth.LoginClientAndUserAsync: " +
                                        $"Invalid User password."
                    };
                }

                var haveMultipleSession = await _sessionService.HaveMiltipleClientUserSessionAsync(request.ClientId, request.UserId);
                if(haveMultipleSession) {
                    return new LoginResponse {
                        AuthValidationResult = (int)AuthValidationResult.HaveMultipleActiveSession,
                        StatusCode = StatusCodes.Status409Conflict,
                        StatusMessage = $"IdentityCliet.Auth.LoginClientAndUserAsync: " +
                                        $"User \"{request.UserId}\" already have active session for \"{request.ClientId}\" Client."
                    };
                }

                var clientUserSession = await _sessionService.SetClientUserSessionAsync(request.ClientId, request.UserId);

                return new LoginResponse {
                    AuthValidationResult = (int)AuthValidationResult.VerifiedCredentials,
                    AccessToken = clientUserSession.AccessToken,
                    AccessExpiration = clientUserSession.AccessExpiration,
                    StatusCode = StatusCodes.Status202Accepted,
                    StatusMessage = $"IdentityCliet.Auth.LoginClientAndUserAsync: " +
                                    $"User \"{request.UserId}\" successfully logged in \"{request.ClientId}\" Client."
                };
            }
            catch(Exception) {
                throw;
            }
        }

        [HttpPost("logout")]
        public async Task LogoutClientAndUserAsync(AuthRequest request)
        {
            try {
                if(request.ClientId == Guid.Empty) {
                    var message = $"IdentityCliet.Auth.LogoutClientAndUserAsync: Invalid ClientId \"{request.ClientId}\" was supplied.";
                    throw new Exception(message);
                }

                if(request.UserId == Guid.Empty) {
                    var message = $"IdentityCliet.Auth.LogoutClientAndUserAsync: Invalid UserId \"{request.UserId}\" was supplied.";
                    throw new Exception(message);
                }

                await _sessionService.ClearClientUserSessionAsync(request.ClientId, request.UserId);
            }
            catch(Exception) {
                throw;
            }
        }
    }
}
