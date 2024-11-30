using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedirectToAction_MVC.Models;

namespace RedirectToAction_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult RedirectedAction(){

        return View();
    }
    public IActionResult ParametreAction(string name){


        return View("ParametreAction",name);
    }
    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {

        if(model.Name=="Hakan"){

            // bir actiondan başka bir action'a yönlendirme yapmak için kullanabilirsiniz!!
            //return RedirectToAction("RedirectedAction");
            // RedirectToAction ile bir action'dan başka bir action'a yönlenebilirsiniz!!
            // redirecttoaction ile farklı controller'daki bir action'a da yönlenebilirsiniz
            //return RedirectToAction("Index","Wissen");
            //RedirectToAction ile parametre transferi yapabilirsiniz 
            
            // name isimli veriyi, diğer action'a parametre olarak gönderdik!!


            return RedirectToAction("ParametreAction",model.Name);

            
        }
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

 

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
