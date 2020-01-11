using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilterSortPagingApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace FilterSortPagingApp.Controllers
{
    public class HomeController : Controller
    {
        BookContext db;
        public HomeController(BookContext context)
        {
            db = context;
            // добавляем начальные данные
            if (db.BookKinds.Count() != 0) return;
            var detective = new BookKind { Name = "detective" }; 
            var romance = new BookKind { Name = "romance" };
            var poems = new BookKind { Name = "poems" }; 
            var drama = new BookKind { Name = "drama" };
            var horror = new BookKind { Name = "horror" }; 

            var book1 = new Book { Name = "A Study in Scarlet", Type = detective, Price = 2131, CreationDate = DateTime.Now};
            var book2 = new Book { Name = "The Cuckoo's Calling", Type = detective, Price = 1999, CreationDate = DateTime.Now };
            var book3 = new Book { Name = "Then She Was Gone", Type = drama, Price = 2312, CreationDate = DateTime.Now };
            var book4 = new Book { Name = "Pride and Prejudice", Type = drama, Price = 2139, CreationDate = DateTime.Now };
            var book5 = new Book { Name = "To Kill a Mockingbird", Type = horror, Price = 546, CreationDate = DateTime.Now };
            var book6 = new Book { Name = "One Hundred Years of Solitude", Type = horror, Price = 546, CreationDate = DateTime.Now };
            var book7 = new Book { Name = "A Passage to India", Type = poems, Price = 547, CreationDate = DateTime.Now };
            var book8 = new Book { Name = "Things Fall Apart", Type = poems, Price = 546, CreationDate = DateTime.Now };
            var book9 = new Book { Name = "Beloved", Type = romance, Price = 546, CreationDate = DateTime.Now };
            var book10 = new Book { Name = "Mrs. Dalloway", Type = romance, Price = 345, CreationDate = DateTime.Now};
                
            db.BookKinds.AddRange(detective, romance, poems, drama, horror);
            db.Books.AddRange(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10);
            db.SaveChanges();
        }
        public async Task<IActionResult> Index(int? type, string name, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            const int pageSize = 5;

            //фильтрация
            IQueryable<Book> books = db.Books.Include(x => x.Type);

            if (type != null && type != 0)
            {
                books = books.Where(p => p.TypeId == type);
            }
            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(p => p.Name.Contains(name));
            }

            // сортировка
            books = sortOrder switch
            {
                SortState.NameDesc => books.OrderByDescending(s => s.Name),
                SortState.PriceAsc => books.OrderBy(s => s.Price),
                SortState.PriceDesc => books.OrderByDescending(s => s.Price),
                SortState.TypeAsc => books.OrderBy(s => s.Type.Name),
                SortState.TypeDesc => books.OrderByDescending(s => s.Type.Name),
                _ => books.OrderBy(s => s.Name)
            };

            // пагинация
            var count = await books.CountAsync();
            var items = await books.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            var viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.BookKinds.ToList(), type, name),
                Books = items
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Book book)
        {
            if (db.Books.Contains(book))
            {
                return BadRequest();
            }
            
            if(!db.BookKinds.Contains(book.Type))
            {
                db.BookKinds.Add(book.Type);
            }
            
            book.CreationDate = DateTime.Now;
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}