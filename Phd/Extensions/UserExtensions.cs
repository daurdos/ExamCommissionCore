using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Phd.Extensions
{
    public static class UserExtensions
    {
        public static bool IsAdmin(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("admin");
        }

        public static bool IsModerator(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("Модератор");
        }
    }
}
