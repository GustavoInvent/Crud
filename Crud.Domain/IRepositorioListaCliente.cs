using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Crud.Domain
{
    public interface IRepositorioListaCliente
    {
        void Salvar(DadosCliente dadosCliente);
        void Deletar(DadosCliente dadosCliente);
        void Editar(DadosCliente dadosCliente);
        DadosCliente ObterSomenteUm(int pegarId);
        List<DadosCliente> ObterTodos();   
        
    }
}




