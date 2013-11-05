﻿using System;
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
        //
        // GET: /Home/

        public ActionResult Index()
        {
            string domain = 
                Request.Url.Scheme + 
                System.Uri.SchemeDelimiter + 
                Request.Url.Host +
                (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

            // NICE-TO-HAVE Sort images by height.
            string imagesDir = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "Images");
            string[] files = Directory.EnumerateFiles(imagesDir).Select(p => domain + "/Images/" + Path.GetFileName(p)).ToArray();

            ViewBag.ImageVirtualPaths = files;

            return View();
        }

    }
}
