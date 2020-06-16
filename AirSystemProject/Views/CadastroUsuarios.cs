using AirSystemProject.Models;
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
    public partial class CadastroUsuarios : Form
    {
        private Usuario usuario = null;
        public CadastroUsuarios()
        {
            InitializeComponent();
        }
        public CadastroUsuarios(Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
        }

        private void CadastroUsuarios_Load(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                nomeTextBox.Text = usuario.nome;
                enderecoTextBox.Text = usuario.endereco;
                usuarioTextBox.Text = usuario.usuario;
            }
        }
    }
}
