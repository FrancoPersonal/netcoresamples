namespace DotnetSamples.Apikey.Authorization.Requirement
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// Defines the <see cref="OnlyReadRequirement" />.
    /// </summary>
    public class OnlyReadRequirement : IAuthorizationRequirement
    {
        public string Rol = Roles.Read;
    }
}
