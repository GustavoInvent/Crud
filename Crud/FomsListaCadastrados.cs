using System;
using System.Windows.Forms;
using Crud.Domain;
using Ninject.Parameters;


namespace Crud.UI
{
    public partial class FomsListaCadastrados : Form
    {

        public IRepositorioListaCliente RepositorioListaCliente;

        public DadosCliente dadosCliente = new DadosCliente();
        public FomsListaCadastrados(IRepositorioListaCliente _repositorioListaCliente, DadosCliente dados)
        {

            RepositorioListaCliente = _repositorioListaCliente;
            dadosCliente = dados;

            InitializeComponent();

        }
        private void btNovoUsuario_Click(object sender, EventArgs e)
        {
            //Instaciar outra form
            var param = new ConstructorArgument("dados", new DadosCliente());
            FomsCadastro telaCadastro = NinjectRepos.Resolve<FomsCadastro>(param);
           
            telaCadastro.ShowDialog(this);

            DataGridlistaCliente.DataSource = null;
            DataGridlistaCliente.DataSource = RepositorioListaCliente.ObterTodos(); 
            
        }
        private void btEditar_Click(object sender, EventArgs e)
        {

            var i = DataGridlistaCliente.CurrentRow;
            if (i == null)
            {
                MessageBox.Show("Selecione um cliente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dados = DataGridlistaCliente.CurrentRow.DataBoundItem as DadosCliente;

            var param = new ConstructorArgument("dados", new DadosCliente
            {
               Id = dados.Id,
               Nome= dados.Nome,
               Email = dados.Email,
               Celular = dados.Celular,
               CPF = dados.CPF,
           
        });

            FomsCadastro TelaEditar = NinjectRepos.Resolve<FomsCadastro>(param);
            TelaEditar.ShowDialog(this);

            DataGridlistaCliente.DataSource = null;
            DataGridlistaCliente.DataSource = RepositorioListaCliente.ObterTodos();

        }   
    
        private void BtExcluir_Click_1(object sender, EventArgs e)
        {
            //Verificar se alguma linha foi selecionada
            var i = DataGridlistaCliente.CurrentRow;
            if (i == null)
            {
                MessageBox.Show("Selecione um cliente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                //Selecionar a linha em um DataGrid
                           
                var dados = DataGridlistaCliente.CurrentRow.DataBoundItem as DadosCliente;

                DialogResult YesNo = new DialogResult();
                YesNo = MessageBox.Show("Você tem certeza de que quer excluir esse cliente?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (YesNo == DialogResult.Yes)
                {
                    //Remover a linha
                    RepositorioListaCliente.Deletar(dados);
                }
                else
                {
                    return;
                }

            }
            //Atualizar DataGrid
            DataGridlistaCliente.DataSource = null;
            DataGridlistaCliente.DataSource = RepositorioListaCliente.ObterTodos();

        }

        private void FomsListaCadastrados_Load(object sender, EventArgs e)
        {
            DataGridlistaCliente.DataSource = null;
            DataGridlistaCliente.DataSource = RepositorioListaCliente.ObterTodos();
        }
    }
}
