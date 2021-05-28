using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Web_File_Compare.Controllers
{
    public class WordByWordController : Controller
    {
        public IActionResult WordByWord()
        {
            ViewData["Title"] = "Test";
            ViewData["length"] = 0;
            ViewBag.text0 = new List<string>();
            ViewBag.text1 = new List<string>();
            ViewData["Info"] = "";
            return View();
        } 
        [HttpPost]
        public IActionResult WordByWord(IFormFile File0, IFormFile File1)
        {
            if (File0 != null && File1 != null)
            {
                List<string> list1 = ReadTextFile(File0);
                List<string> list2 = ReadTextFile(File1);
                HomeController.AddFiller(list1, list2);
                ViewData["Title"] = "Line By Line";
                ViewData["length"] = list1.Count;
                ViewBag.text0 = list1;
                ViewBag.text1 = list2;
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
        ///Turn the file in to a list of each word of text in the file 
        ///</summary>
        public static List<string> ReadTextFile(IFormFile file)
        {
            List<string> textList = LineByLineController.ReadTextFile(file);
            List<string> result = new List<string>();
            foreach (var text in textList)
            {
                result.AddRange(text.Split(' '));

            }
            return result;
        }
    }
}
