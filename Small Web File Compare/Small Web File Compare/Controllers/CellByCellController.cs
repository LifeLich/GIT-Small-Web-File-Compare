using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Small_Web_File_Compare.Controllers
{
    public class CellByCellController : Controller
    {
        public IActionResult CellByCell()
        {
            ViewData["Title"] = "Test";
            ViewData["length"] = 0;
            ViewData["text0"] = new List<string>();
            ViewData["text1"] = new List<string>();
            ViewData["Info"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult CellByCell(IFormFile File0, IFormFile File1)
        {
            if (File0 != null && File1 != null)
            {
                List<string> list1 = LineByLineController.ReadTextFile(File0);
                List<string> list2 = LineByLineController.ReadTextFile(File1);

                List<string> header = CreateHeader(list1[0], list2[0]);

                
                List<List<string>> array1 = CreateArray(list1);
                List<List<string>> array2 = CreateArray(list2);
                AddArrayFiller(array1, array2, header.Count);

                ViewData["Title"] = "Line By Line";
                ViewData["length"] = list1.Count;
                ViewBag.header = header;
                ViewBag.text0 = array1;
                ViewBag.text1 = array2;
                ViewData["Info"] = "";
            }
            else
            {
                ViewBag.length = 0;
                ViewBag.Info = string.Format("please add 2 files, one in each");
            }
            return View();
        }

        private List<string> CreateHeader(string v1, string v2)
        {
            string[] header0 = v1.Split('\t');
            string[] header1 = v2.Split('\t');

            return ((header0.Length > header1.Length) ? header0 : header1).ToList<string>();
        }

        private List<List<string>> CreateArray(List<string> list1)
        {
            List<List<string>> result = new List<List<string>>();
            for (int i = 0; i < list1.Count; i++)
            {
                List<string> row = list1[i].Split('\t').ToList();
                result.Add(row);
            }
            return result;
        }

        public static void AddArrayFiller(List<List<string>> list1, List<List<string>> list2, int headerSize)
        {
            List<string> FullList = new List<string>();

            while (list1.Count != list2.Count)
            {
                if (list1.Count < list2.Count)
                {
                    list1.Add(new List<string>());
                }
                else
                {
                    list2.Add(new List<string>());
                }
            }
            for (int row = 0; row < list1.Count; row++)
            {
                HomeController.AddFiller(list1[row], list2[row]);
            }
        }
    }
}
