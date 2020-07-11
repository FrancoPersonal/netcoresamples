namespace LoggerAspNetCore.Authorization.Requirement
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyEmployeesRequirement" />.
    /// </summary>
    public class OnlyEmployeesRequirement : IAuthorizationRequirement
    {
    }
}
