namespace LoggerAspNetCore.Authorization.Requirement
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyManagersRequirement" />.
    /// </summary>
    public class OnlyManagersRequirement : IAuthorizationRequirement
    {
        public string Rol = Roles.Write;
    }
}
