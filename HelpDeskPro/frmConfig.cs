using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDeskPro
{
    public partial class frmConfig : Form
    {
        Usuarios usuarios;
        public frmConfig(Usuarios _usuarios)
        {
            usuarios = _usuarios;
            InitializeComponent();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {

        }

        private void btnMudarSenha_Click(object sender, EventArgs e)
        {
            frmMudarSenha frmMudarSenha = new frmMudarSenha(usuarios);
            frmMudarSenha.Show();
            this.Close();
        }

        private void btnTrocarConta_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btnAvaliacao_Click(object sender, EventArgs e)
        {
            frmAvaliacao frmAvaliacao = new frmAvaliacao(usuarios);
            frmAvaliacao.Show();
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal frmMenu = new frmMenuPrincipal(usuarios);
            frmMenu.Show();
            this.Close();
        }
    }
}
