namespace LoggerAspNetCore.Authorization.Requirement
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyMonitorRequirement" />.
    /// </summary>
    public class OnlyMonitorRequirement : IAuthorizationRequirement
    {
        public string Rol = Roles.Monitor;
    }
}
