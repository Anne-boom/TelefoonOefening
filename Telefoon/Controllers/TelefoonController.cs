using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Telefoon.Controllers
{
    public class TelefoonController : Controller
    {
        // GET: Telefoon


        static telefoonModel telefoon1 = new telefoonModel();

        public ActionResult Index()
        {
            return View("index", telefoon1.displayTelefoon);
        }

        public ActionResult KlikKnop(string text)
        {
            telefoon1.klikKnop(text);
            return View("Index", telefoon1.displayTelefoon);
        }

        
       
    }

    public class telefoonModel
    {
        public Display displayTelefoon = new Display();

        string vorigeKnop = "";
        int aantalClick = 0;
        DateTime tijdVorigeKlik = DateTime.Now;

        
        public void klikKnop(string text)
        {
            TimeSpan verschil = DateTime.Now.Subtract(tijdVorigeKlik);
            tijdVorigeKlik = DateTime.Now;
            if(vorigeKnop == text)
            {
                if(verschil.TotalSeconds <1.0)
                {
                    aantalClick++;
                    displayTelefoon.DisplayText = displayTelefoon.DisplayText.Substring(0, displayTelefoon.DisplayText.Length - 1);
                    if(aantalClick > text.Length -1)
                    {
                        aantalClick = 0;
                    }
                    displayTelefoon.DisplayText += text[aantalClick];
                }
                else
                {
                    
                    displayTelefoon.DisplayText += text[0];
                    aantalClick = 0; ;
                }
                
                
            }
            else
            {
                displayTelefoon.DisplayText += text[0];
                vorigeKnop = text;
                aantalClick = 0;
            }

        }
    }

    public class Display
    {
        public string DisplayText = "";
        public string DebugText = "";
        
    }
}