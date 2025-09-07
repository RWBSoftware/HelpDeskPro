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
    public partial class frmMudarSenha : Form
    {
        Usuarios usuarios;
        public frmMudarSenha(Usuarios _usuarios)
        {
            InitializeComponent();
            usuarios = _usuarios;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig(usuarios);
            frmConfig.Show();
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HashSenha hashSenha = new HashSenha();
            string senhaAtual = hashSenha.GerarHash(txtSenhaAtual.Text);

            if (txtBoxSenha.Text.Length < 6)
            {
                MessageBox.Show("A senha deve ter no mínimo 6 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (senhaAtual == usuarios.Senha)
            {
                if (txtBoxSenha.Text == txtBoxSenhaNovamente.Text)
                {
                    if(txtSenhaAtual.Text == txtBoxSenha.Text)
                    {
                        MessageBox.Show("A sua nova senha não pode ser igual, a sua antiga senha!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        BancoDeDados bancoDeDados = new BancoDeDados();
                        string novaSenha = hashSenha.GerarHash(txtBoxSenhaNovamente.Text);
                        if (bancoDeDados.AlterarSenha(usuarios.Usuario, usuarios.Senha ,novaSenha))
                        {
                            usuarios.Senha = novaSenha;
                            MessageBox.Show("Senha alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmConfig frmConfig = new frmConfig(usuarios);
                            frmConfig.Show();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Erro ao alterar a senha. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        
                }
                else
                {
                    MessageBox.Show("As senhas não coincidem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Senha atual incorreta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void cBoxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxSenha.UseSystemPasswordChar = !cBoxMostrarSenha.Checked;
            txtBoxSenhaNovamente.UseSystemPasswordChar = !cBoxMostrarSenha.Checked;
            txtSenhaAtual.UseSystemPasswordChar = !cBoxMostrarSenha.Checked;
        }
    }
}
