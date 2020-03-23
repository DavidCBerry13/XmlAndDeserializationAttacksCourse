using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsecureDeserialization.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace InsecureDeserialization.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            webRoot = hostingEnvironment.WebRootPath;
        }

        protected String webRoot;


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Json()
        {
            string filePath = Path.Combine(webRoot, "ImportantFile.txt");

            // Every time this page is refreshed, we will make sure to set file to read-write
            FileInfo fileInfo = new FileInfo(filePath);
            fileInfo.IsReadOnly = false;

            // For the View
            ViewData["FilePath"] = filePath.Replace(@"\", @"\\");

            return View();
        }



    }
}
