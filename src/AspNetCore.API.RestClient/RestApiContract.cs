//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.10.7.0 (NJsonSchema v10.3.9.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"

namespace AspNetCore.API.RestClient
{
    using System = global::System;
    
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.7.0 (NJsonSchema v10.3.9.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial interface IRestApiClient
    {
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<AuthCheckResponse> Auth_CheckClientAndUserAuthorizationAsync(AuthRequest request);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<AuthCheckResponse> Auth_CheckClientAndUserAuthorizationAsync(AuthRequest request, System.Threading.CancellationToken cancellationToken);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LoginResponse> Auth_LoginClientAndUserAsync(LoginRequest request);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<LoginResponse> Auth_LoginClientAndUserAsync(LoginRequest request, System.Threading.CancellationToken cancellationToken);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task Auth_LogoutClientAndUserAsync(AuthRequest request);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task Auth_LogoutClientAndUserAsync(AuthRequest request, System.Threading.CancellationToken cancellationToken);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ApplicationUser>> User_GetAllApplicationUsersAsync();
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Collections.Generic.ICollection<ApplicationUser>> User_GetAllApplicationUsersAsync(System.Threading.CancellationToken cancellationToken);
    
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Guid> User_GetuserIdByUsernameAsync(string userName);
    
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <exception cref="SwaggerException">A server side error occurred.</exception>
        System.Threading.Tasks.Task<System.Guid> User_GetuserIdByUsernameAsync(string userName, System.Threading.CancellationToken cancellationToken);
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.9.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthCheckResponse 
    {
        [Newtonsoft.Json.JsonProperty("AuthCheckResult", Required = Newtonsoft.Json.Required.Always)]
        public int AuthCheckResult { get; set; }
    
        [Newtonsoft.Json.JsonProperty("AuthorizedClient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AuthorizedClient { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ValidUsername", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ValidUsername { get; set; }
    
        [Newtonsoft.Json.JsonProperty("UserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.9.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthRequest 
    {
        [Newtonsoft.Json.JsonProperty("ClientId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ClientId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("UserId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("UserName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.9.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class LoginResponse 
    {
        [Newtonsoft.Json.JsonProperty("AuthValidationResult", Required = Newtonsoft.Json.Required.Always)]
        public int AuthValidationResult { get; set; }
    
        [Newtonsoft.Json.JsonProperty("StatusCode", Required = Newtonsoft.Json.Required.Always)]
        public int StatusCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("StatusMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StatusMessage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("AccessToken", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccessToken { get; set; }
    
        [Newtonsoft.Json.JsonProperty("AccessExpiration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? AccessExpiration { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.9.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class LoginRequest 
    {
        [Newtonsoft.Json.JsonProperty("ClientId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid ClientId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("UserId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.9.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class ApplicationUser : User
    {
        [Newtonsoft.Json.JsonProperty("UserId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UserId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.9.0 (Newtonsoft.Json v12.0.0.0)")]
    public abstract partial class User 
    {
        [Newtonsoft.Json.JsonProperty("UserId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("UserName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("FirstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FirstName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("LastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LastName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("EmailAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }
    
        [Newtonsoft.Json.JsonProperty("PhoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
    
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.7.0 (NJsonSchema v10.3.9.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SwaggerException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.10.7.0 (NJsonSchema v10.3.9.0 (Newtonsoft.Json v12.0.0.0))")]
    public partial class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; private set; }

        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108