using ControleEstoque.Data;
using ControleEstoque.Models;
using ControleEstoque.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers{

    public class ProdutoController : Controller {

        private readonly IRepository<Produto> _repository;

        private readonly IRepository<Categoria> _repositoryCat;

        private readonly UnitOfWork _unitofwork;

        public ProdutoController(IRepository<Produto> repository,UnitOfWork unitofwork,IRepository<Categoria> repositoryCat)
        {
            _repository = repository;
            _unitofwork = unitofwork;
            _repositoryCat = repositoryCat;
        }

        public ActionResult Index(){
            ViewBag.Categorias = _repositoryCat.Get();
            return View(_repository.Get());
        }

        [HttpGet]
        public ActionResult Cadastrar(int? id){
            ViewBag.Categorias = _repositoryCat.Get();
            
            var produtoAux = _repository.GetById(x => x.id == id);
            
            if(produtoAux != null){
                return View(produtoAux);
            } else {
                return View();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Produto produto,[FromServices]DataContext context){

  

            var produtoAux = _repository.GetById(x => x.id == produto.id);

            if(produtoAux != null){
                _repository.Update(produto);
               await _unitofwork.Salvar();
                return RedirectToAction("Index");
            } else {
                _repository.Add(produto);
                await _unitofwork.Salvar();
                return RedirectToAction("Index");
            }
            
        }

    }

}