﻿using System;
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
    public partial class frmLogin : Form
    {
        LembrarDeMim lembrar = new LembrarDeMim();

        public frmLogin()
        {
            InitializeComponent();
            CarregarLogin();
        }

        public void CarregarLogin()
        {
            LembrarDeMim dados = lembrar.Carregar();
            if (dados != null)
            {
                txtBoxUsuario.Text = dados.Usuario;
                txtBoxSenha.Text = dados.senha;
                cBoxLembrarDeMim.Checked = dados.Lembrar;
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            BancoDeDados bancoDeDados = new BancoDeDados();
            HashSenha hash = new HashSenha();
            if (bancoDeDados.Login(txtBoxUsuario.Text, hash.GerarHash(txtBoxSenha.Text)))
            {
                Usuarios usuarios = new Usuarios
                {
                    Usuario = txtBoxUsuario.Text,
                    Senha = hash.GerarHash(txtBoxSenha.Text)
                };

                frmMenuPrincipal frmMenuPrincipal = new frmMenuPrincipal(usuarios);
                frmMenuPrincipal.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void cBoxMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtBoxSenha.UseSystemPasswordChar = !cBoxMostrarSenha.Checked;
        }

        private void cBoxLembrarDeMim_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxLembrarDeMim.Checked)
                lembrar.Salvar(txtBoxUsuario.Text, txtBoxSenha.Text, cBoxLembrarDeMim.Checked);
            else
                lembrar.Apagar();
        }
    }
}
