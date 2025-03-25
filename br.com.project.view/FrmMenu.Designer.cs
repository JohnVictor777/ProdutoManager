namespace Sistema_de_Cadastro_de_produtos.br.com.project.view
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.BtnFornecedor = new System.Windows.Forms.Button();
            this.BtnSair = new System.Windows.Forms.Button();
            this.BtnProduto = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnFornecedor
            // 
            this.BtnFornecedor.BackColor = System.Drawing.Color.Navy;
            this.BtnFornecedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFornecedor.ForeColor = System.Drawing.Color.White;
            this.BtnFornecedor.Location = new System.Drawing.Point(14, 197);
            this.BtnFornecedor.Name = "BtnFornecedor";
            this.BtnFornecedor.Size = new System.Drawing.Size(257, 88);
            this.BtnFornecedor.TabIndex = 17;
            this.BtnFornecedor.Text = "Cadastrar Fornecedor";
            this.BtnFornecedor.UseVisualStyleBackColor = false;
            this.BtnFornecedor.Click += new System.EventHandler(this.BtnFornecedor_Click);
            // 
            // BtnSair
            // 
            this.BtnSair.BackColor = System.Drawing.Color.Red;
            this.BtnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSair.ForeColor = System.Drawing.Color.White;
            this.BtnSair.Location = new System.Drawing.Point(605, 197);
            this.BtnSair.Name = "BtnSair";
            this.BtnSair.Size = new System.Drawing.Size(257, 88);
            this.BtnSair.TabIndex = 16;
            this.BtnSair.Text = "Sair";
            this.BtnSair.UseVisualStyleBackColor = false;
            this.BtnSair.Click += new System.EventHandler(this.BtnSair_Click);
            // 
            // BtnProduto
            // 
            this.BtnProduto.BackColor = System.Drawing.Color.Navy;
            this.BtnProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnProduto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduto.ForeColor = System.Drawing.Color.White;
            this.BtnProduto.Location = new System.Drawing.Point(304, 197);
            this.BtnProduto.Name = "BtnProduto";
            this.BtnProduto.Size = new System.Drawing.Size(257, 88);
            this.BtnProduto.TabIndex = 15;
            this.BtnProduto.Text = "Cadastrar Produto";
            this.BtnProduto.UseVisualStyleBackColor = false;
            this.BtnProduto.Click += new System.EventHandler(this.BtnProduto_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 96);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(237, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "TELA PRINCIPAL";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(874, 432);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnFornecedor);
            this.Controls.Add(this.BtnSair);
            this.Controls.Add(this.BtnProduto);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnFornecedor;
        private System.Windows.Forms.Button BtnSair;
        private System.Windows.Forms.Button BtnProduto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}