using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project4.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Net;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project4.Controllers
{
    public class AuthorController : Controller
    {
        BookContext db;
        public AuthorController(BookContext context)
        {
            db = context;
        }


        public IActionResult Author(string? text)
        {
            if (text != null && text.Trim() != "") {
                var artists = db.Authors
                .Where(c => c.Name.Contains(text) ||
                    c.Country.Contains(text));

                return View(artists);
            } else {
                return View(db.Authors.ToList());
            }
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return View();
        }

        public IActionResult Delete(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Author author = db.Authors.Find(ID);
            if (author == null) {
                return new NotFoundResult();
            }
            db.Authors.Remove(db.Authors.Find(ID));
            db.SaveChanges();
            return Redirect("/Author/Author");
        }

        public IActionResult Detail(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Author author = db.Authors.Find(ID);
            if (author == null) {
                return new NotFoundResult();
            }
            ViewBag.Name = author.Name;
            ViewBag.ID = author.ID;
            ViewBag.Country = author.Country;
            ViewBag.Name = author.Name;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            if (ID == null) {
                return new BadRequestResult();
            }
            Author author = db.Authors.Find(ID);
            if (author == null) {
                return new NotFoundResult();
            }
            ViewBag.Name = author.Name;
            ViewBag.ID = author.ID;
            ViewBag.Country = author.Country;
            ViewBag.Name = author.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (author == null) {
                return new BadRequestResult();
            }

            Author artist2 = db.Authors.Find(author.ID);
            artist2.Country = author.Country;
            artist2.Name = author.Name;
            db.SaveChanges();

            return Redirect("/Author/Author");
        }

    }
}
