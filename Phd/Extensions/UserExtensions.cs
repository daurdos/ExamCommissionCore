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


        // добавляю методы по все ролям пользователей системы
        public static bool IsChairmanBacRus(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПредседательБакалавриатРус");
        }

        public static bool IsChairmanBacKaz(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПредседательБакалавриатКаз");
        }

        public static bool IsChairmanBacEng(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПредседательБакалавриатАнг");
        }


        public static bool IsChairmanMagRus(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПредседательБакалавриатРус");
        }

        public static bool IsChairmanMagKaz(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПредседательБакалавриатКаз");
        }

        public static bool IsChairmanMagEng(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПредседательБакалавриатАнг");
        }



        public static bool IsSecretaryBacRus(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("СекретарьБакалавриатРус");
        }
        public static bool IsSecretaryBacKaz(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("СекретарьБакалавриатКаз");
        }
        public static bool IsSecretaryBacEng(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("СекретарьБакалавриатАнг");
        }


        public static bool IsSecretaryMagRus(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("СекретарьБакалавриатРус");
        }
        public static bool IsSecretaryMagKaz(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("СекретарьБакалавриатKaz");
        }
        public static bool IsSecretaryMagEng(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("СекретарьБакалавриатАнг");
        }



        public static bool IsInstructorBacRus(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПреподавательБакалавриатРус");
        }

        public static bool IsInstructorBacKaz(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПреподавательБакалавриатКаз");
        }
        public static bool IsInstructorBacEng(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПреподавательБакалавриатАнг");
        }



        public static bool IsInstructorMagRus(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПреподавательБакалавриатРус");
        }

        public static bool IsInstructorMagKaz(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПреподавательБакалавриатКаз");
        }
        public static bool IsInstructorMagEng(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("ПреподавательБакалавриатАнг");
        }

        public static bool IsEmployee(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("Сотрудник");
        }

        public static bool IsAdministrator(this ClaimsPrincipal principal)
        {
            return principal.IsInRole("Администратор");
        }

    }
}
