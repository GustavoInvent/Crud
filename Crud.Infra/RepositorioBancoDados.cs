using System.Collections.Generic;
using System.Linq;
using DataModel;
using LinqToDB;
using Crud.Domain;


namespace Crud.Infra
{
    public class RepositorioBancoDados : IRepositorioListaCliente
    {

        public void Salvar(Domain.DadosCliente dadosCliente)
        {

            using (var db = new DadosClienteDB())
            {
                db.dadosClientes
                    .Insert(() => new DadosCliente
                    {
                        Nome = dadosCliente.Nome,
                        Email = dadosCliente.Email,
                        CPF = dadosCliente.CPF,
                        Celular = dadosCliente.Celular
                    });

                 
                 //.Value(p => p.Nome, dadosCliente.Nome)
                 //.Value(p => p.Email, dadosCliente.Email)
                 //.Value(p => p.CPF, dadosCliente.CPF)
                 //.Value(p => p.Celular, dadosCliente.Celular)
                 //.Insert();

            }
        }
        public void Deletar( DadosCliente dadosCliente)
        {

            using (var db = new DadosClienteDB())
            {
                db
                    .dadosClientes
                    .Where(t => t.Id == dadosCliente.Id )
                    .Delete();
            }
           
        }
       
        public void Editar(DadosCliente dadosCliente)
        {

            using (var db = new DadosClienteDB())
            {
                db.dadosClientes
                  .Where(p => p.Id == dadosCliente.Id)
                  .Set(p => p.Nome, dadosCliente.Nome)
                  .Set(p => p.Email, dadosCliente.Email)
                  .Set(p => p.Celular, dadosCliente.Celular)
                  .Set(p => p.CPF, dadosCliente.CPF)
                  .Update();
            }
            
        }

        public List<Domain.DadosCliente> ObterTodos()
        {

            using (var db = new DadosClienteDB())
            {
                var query = from p in db.dadosClientes                         
                            orderby p.Id descending
                            select p;
                return query.ToList();
            }
        }
        public DadosCliente ObterSomenteUm(int pegarId)
        {

            //DadosCliente dadosCliente = null;

            using (var db = new DadosClienteDB())
            {
                return db
                    .dadosClientes
                    .FirstOrDefault(c => c.Id == pegarId);

                //dadosCliente = new DadosCliente();
                //var query = db.dadosClientes
                //    .Where(c => c.Id == pegarId).ToList();
                //foreach (var item in query.ToList())
                //{
                //    dadosCliente.Id = item.Id;
                //    dadosCliente.Nome = item.Nome.ToString();
                //    dadosCliente.Email = item.Email.ToString();
                //    dadosCliente.Celular = item.Celular.ToString();
                //    dadosCliente.CPF = item.Celular.ToString();
                //}
                //return dadosCliente;
            }
        }

    }
}




