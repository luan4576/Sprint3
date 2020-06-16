using AirSystemProject.Models;
using AirSystemProject.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirSystemProject.Views
{
    public partial class TelaListarUsuarios : Form
    {
        UsuarioRepository repository = new UsuarioRepository();
        public TelaListarUsuarios()
        {
            InitializeComponent();
        }

        private void TelaListarUsuarios_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            Usuario usuario = new Usuario
            {
                codigo = 1,
                nome = "luan",
                endereco = "rua blablabla",
                senha = "1234",
                confirmarSenha = "1234",
                usuario = "luan"

            };
            usuarios.Add(usuario);
            dgvListaPessoa.DataSource = usuario;

               
                carregaLista();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
          
            new CadastroUsuarios().ShowDialog();
        
            carregaLista();
        }
        
        private void dgvListaAluno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewRow linha = dgvListaPessoa.Rows[e.RowIndex];
      
            string nome = linha.Cells[1].Value.ToString();
            string endereco = linha.Cells[2].Value.ToString();
            string userName = linha.Cells[3].Value.ToString();
            string senha = linha.Cells[4].Value.ToString();
            string confirmarSenha = linha.Cells[5].Value.ToString();
           
            int codigo = Convert.ToInt32(linha.Cells[0].Value.ToString());
           
            Usuario usuario = new Usuario
            {
                codigo = codigo,
                nome = nome,
                endereco = endereco,
                usuario = userName,
                senha = senha,
                confirmarSenha = confirmarSenha,

    };

            new CadastroUsuarios(usuario).ShowDialog();
            
            carregaLista();
        }

        private void dgvListaPessoa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult dr = MessageBox.Show("Deseja excluir este usuário?", "Atenção"
                    , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    DataGridViewRow linha = dgvListaPessoa.Rows[e.RowIndex];

                    int codigo = Convert.ToInt32(linha.Cells[0].Value.ToString());

                    repository.deletar(codigo);

                    carregaLista();
                }
            }
        }

        private void dgvListaAluno_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult dr = MessageBox.Show("Deseja excluir este usuário?", "Atenção"
                    , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    DataGridViewRow linha = dgvListaPessoa.Rows[e.RowIndex];

                    int codigo = Convert.ToInt32(linha.Cells[0].Value.ToString());

                    repository.deletar(codigo);

                    carregaLista();
                }
            }
        }

        private void carregaLista()
        {
            UsuarioRepository repository = new UsuarioRepository();
            dgvListaPessoa.DataSource = null;
            dgvListaPessoa.DataSource = repository.buscarTodos();
            alterarContador();
        }

        private void filtroTextbox_TextChanged(object sender, EventArgs e)
        {
            dgvListaPessoa.DataSource = null;

            dgvListaPessoa.DataSource = repository.buscarTodos().FindAll(x =>
                x.nome.ToUpper().Contains(filtroTextbox.Text.ToUpper()) ||
                x.endereco.ToUpper().Contains(filtroTextbox.Text.ToUpper()) ||
                x.usuario.ToUpper().Contains(filtroTextbox.Text.ToUpper())
            );

            alterarContador();

        }






        private void alterarContador()
        {
            
            lblContador.Text = $"{dgvListaPessoa.RowCount} itens de {repository.buscarTodos().Count}";
        }
    }
}
