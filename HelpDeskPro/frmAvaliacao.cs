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
    public partial class frmAvaliacao : Form
    {
        Usuarios usuarios;
        public frmAvaliacao(Usuarios _usuarios)
        {
            InitializeComponent();
            usuarios = _usuarios;
        }

        public void AbrirForms()
        {
            frmConfig frmConfig = new frmConfig(usuarios);
            frmConfig.Show();
            this.Close();
        }

        public void Verificacao()
        {
            if (int.TryParse(txtNota.Text, out int nota))
            {
                if (nota >= 0 && nota <= 5)
                {
                    MessageBox.Show("Avaliação salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AbrirForms();
                }
                else
                    MessageBox.Show("Por favor, insira uma nota entre 0 e 5.", "Nota Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Por favor, insira uma nota entre 0 e 5.", "Nota Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Verificacao();
        }

        private void txtNota_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Clear();
            txtNota.Clear();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            AbrirForms();
        }
    }
}
