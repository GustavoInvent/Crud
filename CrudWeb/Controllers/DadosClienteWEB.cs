using Microsoft.AspNetCore.Mvc;
using Crud.Domain;
using System.Linq;
using System.Data.SqlClient;


namespace CrudWeb.Controllers
{
    public class DadosClienteWEB : Controller
    {

        private readonly IRepositorioListaCliente _repositorioCliente;
        public DadosClienteWEB(IRepositorioListaCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        [HttpGet]
        public IActionResult Cadastrados()
        {
            var retorno = _repositorioCliente.ObterTodos();
            return View(retorno.ToList());
        }

        [HttpGet]
        public IActionResult NovoCadastro()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            DadosCliente dadosCliente = _repositorioCliente.ObterSomenteUm(id);

            return View(dadosCliente);
            
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            DadosCliente dadosCliente = _repositorioCliente.ObterSomenteUm(id);

            return View(dadosCliente);
            
        }
        

        [HttpPost]
        public IActionResult NovoCadastro(DadosCliente dadosCliente)
        {
           
           _repositorioCliente.Salvar(dadosCliente);
               return RedirectToAction("Cadastrados");

            return View(dadosCliente);
        }
        
        
        [HttpPost]
        public ActionResult Deletar(DadosCliente dadosCliente)
        {
            
                _repositorioCliente.Deletar(dadosCliente);
                return RedirectToAction("Cadastrados");
            
            return View(dadosCliente);
        }
        
        
        [HttpPost]
        public IActionResult Editar(DadosCliente dadosCliente)
        {
            
                _repositorioCliente.Editar(dadosCliente);
                return RedirectToAction("Cadastrados");
            
            return View(dadosCliente);
        }
        
    }

}
