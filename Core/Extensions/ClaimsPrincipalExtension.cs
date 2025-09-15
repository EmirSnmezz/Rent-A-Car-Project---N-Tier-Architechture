using System.Security.Claims;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtension
    {
       public static List<string> Claims(this ClaimsPrincipal cliamsPrincipal, string claimType)
        {
            var result = cliamsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();

            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
