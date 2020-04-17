using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phd.Data;
using Phd.Extensions;
using Phd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly PhdContext _context;

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context, RoleManager<IdentityRole> roleManager = null)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            // RoleInitializer.InitializeAsync(_userManager, _roleManager, _context).Wait();
            
            
            try
            {
                RoleInitializer.InitializeAsync(_userManager, _roleManager, _context).Wait();
            }
            catch (Exception e)
            {
                // Console.WriteLine("Возникло исключение!");
               // throw e; // если разкомментировать выдаст ошибку-исключение. Нужно разобраться

            }
            
           
        }

        public PhdContext Context
        {
            get
            {
                return _context;
            }
        }

        public UserManager<User> UserManager
        {
            get
            {
                return _userManager;
            }
        }

        public SignInManager<User> SingInManager
        {
            get
            {
                return _signInManager;
            }
        }


        public string GetUserId()
        {
            return UserManager.GetUserId(HttpContext.User);
        }

        public User GetUser()
        {
            return UserManager.GetUserAsync(HttpContext.User).Result;
        }

        public async Task<User> GetUserAsync()
        {
            return await UserManager.GetUserAsync(HttpContext.User);
        }

        public bool IsAdmin()
        {
            return HttpContext.User.IsAdmin(); // Вызывать методы расширения. Как делал Жангельды. HttpContext - содержит дополнительную информацию при подключении сайту
        }

        public bool IsModerator()
        {
            return HttpContext.User.IsModerator(); // Вызывать методы расширения. Как делал Жангельды. HttpContext - содержит дополнительную информацию при подключении сайту
        }


        //пример как сделать булевове свойство возвращающее тру фолс при определенных условиях
        public bool IsStudent
        {
            get
            {
                return HttpContext.User.IsInRole("admin");
            }
        }

    }
}
