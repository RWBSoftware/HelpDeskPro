namespace HelpDeskPro
{
    partial class frmAvaliacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvaliacao));
            btnLimpar = new Button();
            btnSalvar = new Button();
            btnVoltar = new Button();
            txtDescricao = new TextBox();
            label3 = new Label();
            label1 = new Label();
            txtNota = new TextBox();
            label2 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpar.Location = new Point(203, 304);
            btnLimpar.Margin = new Padding(3, 4, 3, 4);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(120, 39);
            btnLimpar.TabIndex = 20;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(76, 175, 80);
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvar.Location = new Point(77, 351);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(246, 39);
            btnSalvar.TabIndex = 19;
            btnSalvar.Text = "Enviar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.BackColor = Color.FromArgb(244, 67, 54);
            btnVoltar.FlatAppearance.BorderSize = 0;
            btnVoltar.FlatStyle = FlatStyle.Flat;
            btnVoltar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVoltar.Location = new Point(77, 304);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(120, 39);
            btnVoltar.TabIndex = 18;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = false;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescricao.Location = new Point(77, 166);
            txtDescricao.MaxLength = 60;
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(246, 127);
            txtDescricao.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(78, 138);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 16;
            label3.Text = "Descrição:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(78, 9);
            label1.Name = "label1";
            label1.Size = new Size(250, 31);
            label1.TabIndex = 15;
            label1.Text = "Avalie sua experiência";
            // 
            // txtNota
            // 
            txtNota.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNota.Location = new Point(77, 103);
            txtNota.MaxLength = 1;
            txtNota.Name = "txtNota";
            txtNota.Size = new Size(246, 32);
            txtNota.TabIndex = 14;
            txtNota.KeyPress += txtNota_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(78, 75);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 13;
            label2.Text = "Nota: (0 - 5)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 40);
            label4.Name = "label4";
            label4.Size = new Size(374, 23);
            label4.TabIndex = 21;
            label4.Text = "Sua opinião ajuda a melhorar nossos softwares!";
            // 
            // frmAvaliacao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 246, 247);
            ClientSize = new Size(400, 416);
            Controls.Add(label4);
            Controls.Add(btnLimpar);
            Controls.Add(btnSalvar);
            Controls.Add(btnVoltar);
            Controls.Add(txtDescricao);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtNota);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmAvaliacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HelpDesk Pro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLimpar;
        private Button btnSalvar;
        private Button btnVoltar;
        private TextBox txtDescricao;
        private Label label3;
        private Label label1;
        private TextBox txtNota;
        private Label label2;
        private Label label4;
    }
}