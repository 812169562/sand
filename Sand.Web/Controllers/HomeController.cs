using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sand.Dependency;
using Sand.Filter;
using Sand.Service;

namespace Sand.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        //public IService Service { get; set; }

        public HomeController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    //public interface IService:IDependency
    //{
    //    [LogInterceptor]
    //    string CallBack();
    //}


    //public class TService : IService
    //{
    //    public TService()
    //    {
    //    }
    //    public string CallBack()
    //    {
    //        return "1";
    //    }
    //}
}
