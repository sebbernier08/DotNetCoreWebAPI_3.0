using System.Linq;
using System.Security.Claims;

namespace DotNetCoreWebAPI_3._0.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            return int.Parse(claimsPrincipal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}
