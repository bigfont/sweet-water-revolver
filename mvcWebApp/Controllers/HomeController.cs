using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace mvcWebApp.Controllers
{
    public class HomeController : Controller
    {

        public string domain
        {
            get
            {
                string domain =
                    Request.Url.Scheme +
                    System.Uri.SchemeDelimiter +
                    Request.Url.Host +
                    (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                return domain;
            }
        }


        //
        // GET: /Home/

        public ActionResult Index()
        {
            // NICE-TO-HAVE Sort images by height.
            string imagesDir = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Images");

            string[] files = Directory.EnumerateFiles(imagesDir + "/Gallery").Select(p => this.domain + "/Images/Gallery/" + Path.GetFileName(p)).ToArray();
            string[] carouselFiles = Directory.EnumerateFiles(imagesDir + "/Carousel").Select(p => this.domain + "/Images/Carousel/" + Path.GetFileName(p)).ToArray();           

            ViewBag.ImageVirtualPaths = files;
            
            ViewBag.CarouselVirtualPaths = carouselFiles;            

            return View();
        }

    }
}
