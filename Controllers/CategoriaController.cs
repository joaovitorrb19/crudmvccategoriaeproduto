using ControleEstoque.Data;
using ControleEstoque.Models;
using ControleEstoque.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers{

    public class CategoriaController : Controller {
        private readonly IRepository<Categoria> _repository;
        private readonly UnitOfWork _unitofwork;
        public CategoriaController(IRepository<Categoria> repository,UnitOfWork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }

        public ActionResult Index(){
            return View(_repository.Get());
        }

        [HttpGet]
        public ActionResult Cadastrar(int? id){
            var categoriaAux = _repository.GetById(x => x.id == id);
            if(categoriaAux != null){
              return View(categoriaAux);
            } else {
                return View();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(Categoria categoria){
            var categoriaAux = _repository.GetById(x => x.id == categoria.id);
            if(categoriaAux != null){
                _repository.Update(categoria);
               await _unitofwork.Salvar();
               return RedirectToAction("Index");
            } else {
            _repository.Add(categoria);
            await _unitofwork.Salvar();
            return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Excluir(int? id){
            _repository.Remove(x => x.id == id);
            await _unitofwork.Salvar();
            return RedirectToAction("Index");
        }

    }
}