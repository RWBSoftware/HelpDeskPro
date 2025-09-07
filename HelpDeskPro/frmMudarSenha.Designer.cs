namespace HelpDeskPro
{
    partial class frmMudarSenha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMudarSenha));
            txtBoxSenhaNovamente = new TextBox();
            label4 = new Label();
            btnVoltar = new Button();
            btnAlterar = new Button();
            cBoxMostrarSenha = new CheckBox();
            txtBoxSenha = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtSenhaAtual = new TextBox();
            SuspendLayout();
            // 
            // txtBoxSenhaNovamente
            // 
            txtBoxSenhaNovamente.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxSenhaNovamente.Location = new Point(79, 229);
            txtBoxSenhaNovamente.MaxLength = 60;
            txtBoxSenhaNovamente.Name = "txtBoxSenhaNovamente";
            txtBoxSenhaNovamente.Size = new Size(193, 32);
            txtBoxSenhaNovamente.TabIndex = 29;
            txtBoxSenhaNovamente.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(79, 201);
            label4.Name = "label4";
            label4.Size = new Size(173, 25);
            label4.TabIndex = 28;
            label4.Text = "Senha Novamente: ";
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = Color.FromArgb(244, 67, 54);
            btnVoltar.FlatAppearance.BorderSize = 0;
            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoltar.Location = new Point(103, 355);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(145, 49);
            btnVoltar.TabIndex = 27;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.FromArgb(0, 119, 204);
            btnAlterar.FlatAppearance.BorderSize = 0;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAlterar.Location = new Point(103, 298);
            btnAlterar.Margin = new Padding(3, 4, 3, 4);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(145, 49);
            btnAlterar.TabIndex = 26;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // cBoxMostrarSenha
            // 
            cBoxMostrarSenha.AutoSize = true;
            cBoxMostrarSenha.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cBoxMostrarSenha.Location = new Point(110, 267);
            cBoxMostrarSenha.Name = "cBoxMostrarSenha";
            cBoxMostrarSenha.Size = new Size(131, 24);
            cBoxMostrarSenha.TabIndex = 25;
            cBoxMostrarSenha.Text = "Mostrar Senha";
            cBoxMostrarSenha.UseVisualStyleBackColor = true;
            cBoxMostrarSenha.CheckedChanged += cBoxMostrarSenha_CheckedChanged;
            // 
            // txtBoxSenha
            // 
            txtBoxSenha.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBoxSenha.Location = new Point(79, 159);
            txtBoxSenha.MaxLength = 60;
            txtBoxSenha.Name = "txtBoxSenha";
            txtBoxSenha.Size = new Size(193, 32);
            txtBoxSenha.TabIndex = 24;
            txtBoxSenha.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(79, 131);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 22;
            label3.Text = "Senha Nova:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(79, 64);
            label2.Name = "label2";
            label2.Size = new Size(115, 25);
            label2.TabIndex = 21;
            label2.Text = "Senha Atual:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 21);
            label1.Name = "label1";
            label1.Size = new Size(195, 31);
            label1.TabIndex = 20;
            label1.Text = "Altere Sua Senha";
            // 
            // txtSenhaAtual
            // 
            txtSenhaAtual.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSenhaAtual.Location = new Point(79, 92);
            txtSenhaAtual.MaxLength = 60;
            txtSenhaAtual.Name = "txtSenhaAtual";
            txtSenhaAtual.Size = new Size(193, 32);
            txtSenhaAtual.TabIndex = 30;
            txtSenhaAtual.UseSystemPasswordChar = true;
            // 
            // frmMudarSenha
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 247);
            ClientSize = new Size(350, 425);
            Controls.Add(txtSenhaAtual);
            Controls.Add(txtBoxSenhaNovamente);
            Controls.Add(label4);
            Controls.Add(btnVoltar);
            Controls.Add(btnAlterar);
            Controls.Add(cBoxMostrarSenha);
            Controls.Add(txtBoxSenha);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmMudarSenha";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HelpDesk Pro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxSenhaNovamente;
        private Label label4;
        private Button btnVoltar;
        private Button btnAlterar;
        private CheckBox cBoxMostrarSenha;
        private TextBox txtBoxSenha;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtSenhaAtual;
    }
}