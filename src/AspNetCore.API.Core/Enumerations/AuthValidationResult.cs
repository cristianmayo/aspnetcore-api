namespace AspNetCore.API.Core.Enumerations
{
    public enum AuthValidationResult
    {
        VerifiedCredentials,
        PasswordChangeRequired,
        InvalidRequest,
        InvalidCredentials,
        UnauthorizedAccess,
        HaveMultipleActiveSession
    }
}
