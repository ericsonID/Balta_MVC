using BookStore.Context;
using BookStore.Domain;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("livros")]
    public class BookController : Controller
    {
        BookStoreDataContext _db = new BookStoreDataContext();
        [Route("criar")]
        // GET: Livro
        public ActionResult Create()
        {
            var categorias = _db.Categorias.ToList();
            var model = new CreateBookViewModel
            {
                Nome = "",
                ISBN = "",
                CategoriaId = 0,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };
            return View(model);
        }
        [HttpPost]
        [Route("criar")]
        // GET: Livro
        public ActionResult Create(CreateBookViewModel model)
        {
            return View();
        }

    }
}