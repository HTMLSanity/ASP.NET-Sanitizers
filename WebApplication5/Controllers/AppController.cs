using Ganss.XSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;
using WebApplication4.Models;

namespace WebApplication5.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            return View();
        }

        

        // GET: App/Form
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Form(string List, string Unsanitized_HTML , string Tags)
        {
                char[] delimiterChars = { ',' };
                Session["output"] = "";
                Session["output1"] = "";
                string text = "";
                string[] list = new string[] { };
                list = Tags.Split(delimiterChars);
                text = HSanitizer.SanitizeHtml(Unsanitized_HTML, list);
                Session["output"] = text;
                Session["output1"] = AntiXssEncoder.HtmlEncode(text, false);
                return RedirectToAction("Output");
        }

        public ActionResult Page2()
        {
            return View();
        }


        // GET: App/Form2
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Form2(string Unsanitized_HTML)
        {
            Session["output"] = "";
            Session["output1"] = "";
            var sanitizer = new HtmlSanitizer();
            var sanitized = sanitizer.Sanitize(Unsanitized_HTML);
            Session["output"] = sanitized ;
            Session["output1"] = AntiXssEncoder.HtmlEncode(sanitized, false);
            return RedirectToAction("Output");
        }


        public ActionResult Page3()
        {
            return View();
        }

        // GET: App/Form2
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Form3(string Unsanitized_HTML)
        {
            Session["output"] = "";
            Session["output1"] = "";
            var sanitizer = new HtmlSanitizer();
            var sanitized = sanitizer.Sanitize(Unsanitized_HTML);
            Session["output"] = sanitized;
            Session["output1"] = AntiXssEncoder.HtmlEncode(sanitized, false);

            return RedirectToAction("Output");
        }

        public ViewResult Output()
        {
            return View();
        }
    }
}