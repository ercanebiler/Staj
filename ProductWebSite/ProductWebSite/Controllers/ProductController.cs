using ProductWebSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProductWebSite.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductClass> productClasses = new List<ProductClass>();


        // GET: Product
        public ActionResult ProductView()
        {



                readFile();



    
           return View(productClasses);


        }


       

        public void readFile()
        {
            int sayi =productClasses.Count;
            try
            {   // Open the text file using a stream reader.
                string path = @"C:\Users\Ercan\Desktop\Github\Staj\ProductWebSite\ProductWebSite\ProductData.txt";
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("iso-8859-9")))
                {
                    // Read the stream to a string, and write the string to the console.

                    String line = sr.ReadLine();
                    while (line != null)
                    {
                        String[] splitLine = line.Split(' ');
                        String[] dateSplit = splitLine[2].Split('.');
                        String[] timeSplit = splitLine[3].Split(':');
                        DateTime lastUpdatedTimeS = new DateTime(Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[1]), Convert.ToInt32(dateSplit[0]), Convert.ToInt32(timeSplit[0]), Convert.ToInt32(timeSplit[1]), Convert.ToInt32(timeSplit[2]));
                        String name = splitLine[1];
                        int id = Convert.ToInt32(splitLine[0]);
                        if(sayi>0)
                        {
                            foreach (var productCla in ProductController.productClasses)
                            {
                                if (productCla.Id == id)
                                {
                                    var result = DateTime.Compare(productCla.lastUpdatedTime, lastUpdatedTimeS);
                                    Console.WriteLine(productCla.lastUpdatedTime + " " + lastUpdatedTimeS + " " + result);
                                    if (result != 0)
                                    {
                                        productCla.Name = name;
                                        productCla.lastUpdatedTime = lastUpdatedTimeS;
                                    }
                                }
                            }
                        }
                        else
                        {
                            var tempProduct = new ProductClass() { Id = Convert.ToInt32(splitLine[0]), Name = splitLine[1], lastUpdatedTime = new DateTime(Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[1]), Convert.ToInt32(dateSplit[0]), Convert.ToInt32(timeSplit[0]), Convert.ToInt32(timeSplit[1]), Convert.ToInt32(timeSplit[2])) };
                            productClasses.Add(tempProduct);
                        }


                        line = sr.ReadLine();
                    }


                    sr.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }

            
        }

        public ActionResult Page(int page)
        {
            return Content("Page :" + page);
        }

    }
}