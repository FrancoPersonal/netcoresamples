namespace LoggerAspNetCore.Authorization.Requirement
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyWriteRequirement" />.
    /// </summary>
    public class OnlyWriteRequirement : IAuthorizationRequirement
    {
        public string Rol = Roles.Write;
    }
}
