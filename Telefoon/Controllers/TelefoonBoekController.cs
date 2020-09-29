using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                writer.WriteLine($"{nummer};{newTelefoon.naam};{newTelefoon.adres}");
                
                writer.Close();

                //File.appendAllLines(filePath, adresboekNieuw);
            

            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

        
        public ActionResult Search()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Search(string naam)
        {
            string lijn = "g";
            string filePath = @"C:\Users\anne\Documents\telefoonboek.txt";
            StreamReader sr = new StreamReader(filePath);
            List<info> lijst = new List<info>();

            //List<string> boek = new List<string>();


            while (lijn != null)
            {
                lijn = sr.ReadLine();
                if (lijn != null)
                {
                    info niewe = new info();
                    string[] words = lijn.Split(';');
                    niewe.nummer = Int32.Parse(words[0]);
                    niewe.naam = words[1];
                    niewe.adres = words[2];

                    lijst.Add(niewe);

                }
            }

            List<info> filter = lijst.Where(e => e.naam.Contains(naam)).ToList();

            sr.Close();

            ViewBag.lijst = filter;

            return View("Search", filter);
        }

    }






}