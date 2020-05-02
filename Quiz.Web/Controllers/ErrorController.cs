﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Quiz.Web.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 400: ViewBag.ErrorMessage = "Sorry, this resource is non existing."; break;
                case 404: ViewBag.ErrorMessage = "Sorry, resource not available or not found."; break;
                default: ViewBag.ErrorMessage = "Sorry, a server error occurred."; break;
            }
            return View("ErrorPage");
        }
    }
}