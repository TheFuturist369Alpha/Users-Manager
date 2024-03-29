﻿using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.UI.Controllers
{
    [Controller]
    public class Home : Controller
    {
        private readonly IWebHostEnvironment _env;

        public Home(IWebHostEnvironment env)
        {
            _env = env;
            
        }

        
        
        public IActionResult Welcome()
        {
            ViewData["Current"] = this._env.EnvironmentName;
            return View();
        }
       
    }
}
