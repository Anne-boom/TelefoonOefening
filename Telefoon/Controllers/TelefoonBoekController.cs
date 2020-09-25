using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telefoon.Models;
using static System.Net.WebRequestMethods;

namespace Telefoon.Controllers
{
    public class TelefoonBoekController : Controller
    {
        // GET: TelefoonBoek
        
        public ActionResult Index()
        {
            string adres = "g";
            string filePath = @"C:\Users\anne\Documents\telefoonboek.txt";
            StreamReader sr = new StreamReader(filePath);

            List<string> boek = new List<string>();
            
            while(adres!= null)
            {
               adres = sr.ReadLine();
                if(adres!=null)
                {
                    boek.Add(adres);
                }
            }
            sr.Close();

            return View(boek);
        }
        
        public ActionResult Create()
    {
        return View();
    }

 [HttpPost]
    public ActionResult Create(info newTelefoon)
    {
        string[] adresboekNieuw = new string[3];
        if (ModelState.IsValid)
        {
                string nummer = (newTelefoon.nummer).ToString();
                adresboekNieuw[0] = nummer;
                adresboekNieuw[1] = newTelefoon.naam;
                adresboekNieuw[2] = newTelefoon.adres;

                string filePath = @"C:\Users\anne\Documents\telefoonboek.txt";
                StreamWriter writer = new StreamWriter(filePath, true);
                writer.WriteLine($"{nummer} {newTelefoon.naam} {newTelefoon.adres}");
                
                writer.Close();

                //File.appendAllLines(filePath, adresboekNieuw);
            

            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    }

    

  

   
}