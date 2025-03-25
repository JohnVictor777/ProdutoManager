using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cadastro_de_produtos.br.com.project.view
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        // Evento do botão Fornecedor - Abre a tela de cadastro de fornecedores
        private void BtnFornecedor_Click(object sender, EventArgs e)
        {
            FrmFornecedor telaFornecedor = new FrmFornecedor();
            telaFornecedor.ShowDialog();
        }

        // Evento do botão Produto - Abre a tela de cadastro de produtos
        private void BtnProduto_Click(object sender, EventArgs e)
        {
            FrmProduto telaProduto = new FrmProduto();
            telaProduto.ShowDialog();
        }

        // Evento do botão Sair - Encerra a aplicação
        private void BtnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja Sair?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verifica se o usuário confirmou a saída
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
