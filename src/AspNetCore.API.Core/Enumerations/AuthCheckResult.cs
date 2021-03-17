namespace AspNetCore.API.Core.Enumerations
{
    public enum AuthCheckResult
    {
        AuthorizedClientAndUser,
        InvalidClientId,
        UnauthorizedClient,
        InvalidUserName,
        UnauthorizedUser
    }
}
