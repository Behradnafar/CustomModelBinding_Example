using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Docs.Samples;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.CompilerServices;
using ModelBinding.Bugeto.Models;
using Routing.Bugeto.Models;

namespace Routing.Bugeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index( )
        {
            return View();
        }    
        public IActionResult Edit([FromServices] IMyService myService)
        {
            myService.Test();
            return View();
        }   
        
        [Consumes("application/xml")]
        [HttpPost]
        public IActionResult Edit(string[] ch, Dictionary<int,string> dic, IFormCollection keyValues , IFormFile file, IFormFileCollection formFiles )
        {
            return View();
        }   
 

        public IActionResult NewUser([ModelBinder(binderType: typeof(UserCustomModelBinder))]User newUser)
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }    
       
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public interface IMyService
    {
        void Test();
    }
    public class MyService : IMyService
    {
        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}