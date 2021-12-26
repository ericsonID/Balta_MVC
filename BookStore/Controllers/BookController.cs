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
        [Route("listar")]
        public ActionResult Index()
        {
            return View(_db.Livros.ToList());
        }
        [Route("editar")]
        // GET: Livro
        public ActionResult Edit(int id)
        {
            var categorias = _db.Categorias.ToList();
            var livro = _db.Livros.Find(id);
            
            var model = new EditorBookViewModel
            {
                Nome = livro.Nome,
                ISBN = livro.ISBN,
                CategoriaId = livro.CategoriaId,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };
            return View(model);
        }
        [Route("criar")]
        // GET: Livro
        public ActionResult Create()
        {
            //ModelState.AddModelError("Mensagem", "Algum Erro ocorreu!");
            var categorias = _db.Categorias.ToList();
            var model = new EditorBookViewModel
            {
                Nome = "",
                ISBN = "",
                CategoriaId = 0,
                DataLancamento = DateTime.MinValue.Date,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };
            return View(model);
        }
        [Route("criar")]
        [HttpPost]
        
        // GET: Livro
        public ActionResult Create(EditorBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categorias = _db.Categorias.ToList();
                model.CategoriaOptions = new SelectList(categorias, "Id", "Nome");
                return View(model);
            }
            var livro = new Livro();
            livro.Nome = model.Nome;
            livro.ISBN = model.ISBN;
            livro.DataLancamento = model.DataLancamento.Date;
            livro.CategoriaId = model.CategoriaId;
            _db.Livros.Add(livro);
            try
            {
                
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Mensagem", ex.Message);
                var categorias = _db.Categorias.ToList();
                model.CategoriaOptions = new SelectList(categorias, "Id", "Nome");
                return View(model);
            }
            

            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("editar")]
        // GET: Livro
        public ActionResult Edit(EditorBookViewModel model)
        {
            
            var livro = _db.Livros.Find(model);
            _db.Entry<Livro>(livro).State = System.Data.Entity.EntityState.Modified;
            
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
