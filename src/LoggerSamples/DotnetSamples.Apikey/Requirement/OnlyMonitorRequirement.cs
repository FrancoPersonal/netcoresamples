namespace LoggerAspNetCore.Authorization.Requirement
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyThirdPartiesRequirement" />.
    /// </summary>
    public class OnlyThirdPartiesRequirement : IAuthorizationRequirement
    {
        public string Rol = Roles.Monitor;
    }
}
