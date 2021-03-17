namespace AspNetCore.API.Core.Constants
{
    public static class ValidationMessage
    {
        public const string UserName_NullEmptyWhitespace = "Username must not be null, empty, or whitespace.";
        public const string UserName_Required = "Username is required.";

        public const string Password_NullEmptyWhitespace = "Password must not be null, empty, or whitespace.";
        public const string Password_Required = "Password is requrired.";

        public const string AuthCheck_EmptyUsername = "Username is required!";
        public const string AuthCheck_UnathorizedClient = "You're accessing the application with unauthorized client application.";
        public const string AuthCheck_UnauthorizedUser = "Unauthorized Access! Ensure you provided a valid Username";
        public const string AuthCheck_UserNotFound = "User not found! Ensure you provided a valid Username";

        public const string LogOnResult_Success = "Welcome! You are now logged-in.";
        public const string LogOnResult_InvalidCredentials = "Login failed! Use a valid credentials and try again.";
        public const string LogOnResult_InvalidRequest = "Login failed! User valid credentials and try again.";
        public const string LogOnResult_UnathorizedAccess = "Unauthorized Access! User appropriate client application to sign-in.";
        public const string LogOnResult_HaveMultipleActiveSession = "Multiple sign-in detected! Your other session with be disconnected.";

        public const string EncryptionFailed = "Encryption Failed! Provide a valid string value.";
        public const string DecryptionFailed = "Decryption Failed! Ensure that you have used the encrypted value.";

        public const string ApiResponse_Success = "Successfully Processed Request";
        public const string ApiResponse_Error = "Error Processing Request";
    }
}
