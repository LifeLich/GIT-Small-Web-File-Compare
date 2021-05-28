using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Web_File_Compare.Controllers
{
    public class LineByLineController : Controller
    {
        public IActionResult LineByLine()
        {
            ViewData["Title"] = "Test";
            ViewData["length"] = 0;
            ViewData["text0"] = new List<string>();
            ViewData["text1"] = new List<string>();
            ViewData["Info"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult LineByLine(IFormFile File0, IFormFile File1)
        {
            if (File0 != null && File1 != null)
            {
                List<string> list1 = ReadTextFile(File0);
                List<string> list2 = ReadTextFile(File1);
                HomeController.AddFiller(list1, list2);
                ViewData["Title"] = "Line By Line";
                ViewData["length"] = list1.Count;
                ViewData["text0"] = list1;
                ViewData["text1"] = list2;
                ViewData["Info"] = "";
            }
            else
            {
                ViewBag.length = 0;
                ViewBag.Info = string.Format("please add 2 files, one in each");
            }
            return View();
        }

        ///<summary> sn:
        ///Turn the file in to a list of each line of text in the file 
        ///</summary>
        public static List<string> ReadTextFile(IFormFile file)
        {
            List<string> result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() != -1)
                {
                    result.Add(reader.ReadLine());
                }
            }
            return result;
        }
    }
}
