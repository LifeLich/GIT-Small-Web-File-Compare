using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Small_Web_File_Compare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Web_File_Compare.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       // public IActionResult Index()
       // {
       //     ViewData["Title"]   = "Test";
       //     ViewData["length"]  = 0;
       //     ViewData["text0"]   = new List<string>();
       //     ViewData["text1"]   = new List<string>();
       //     ViewData["Info"]    = "";
       //     return View();
       // }
       // [HttpPost]
       // public IActionResult Index(IFormFile File0, IFormFile File1)
       // {
       //     if (File0 != null && File1 != null)
       //     {
       //         List<string> list1 = LineByLineController.ReadTextFile(File0);
       //         List<string> list2 = LineByLineController.ReadTextFile(File1);
       //         AddFiller(list1, list2);
       //         ViewData["Title"] = "Line By Line";
       //         ViewData["length"]  = list1.Count;
       //         ViewData["text0"]   = list1;
       //         ViewData["text1"]   = list2;
       //         ViewData["Info"] = "";
       //     }
       //     else
       //     {
       //         ViewBag.length = 0;
       //         ViewBag.Info = string.Format("please add 2 files, one in each");
       //     }
       //     return View();
       // }

        ///<summary> sn:
        ///This method is to insure that if a list is small than the other
        ///The other lists data will still be included 
        ///</summary>
        public static void AddFiller(List<string> list1, List<string> list2)
        {
            while (list1.Count != list2.Count)
            {
                if (list1.Count < list2.Count)
                {
                    list1.Add("");
                }
                else
                {
                    list2.Add("");
                }
            }
        }
    }
}
