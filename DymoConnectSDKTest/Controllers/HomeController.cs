using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DymoSDK.Implementations;

namespace DymoConnectSDKTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Print()
        {
            var label = DymoLabel.Instance;
            var printers = DymoPrinter.Instance.GetPrinters();
            var printer = printers.FirstOrDefault();
            if (printer != null)
            {
                label.LoadLabelFromFilePath("generatedXML.dymo");

                DymoPrinter.Instance.PrintLabel(label, printer.Name);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}