using Sistema_de_Cadastro_de_produtos.br.com.project.dao;
using Sistema_de_Cadastro_de_produtos.br.com.project.model;
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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        // Evento Load do formulário - Inicializa componentes e carrega dados
        private void FrmProduto_Load(object sender, EventArgs e)
        {
            try
            {

                // Define valor inicial padrão para o campo de preço (formato monetário)
                TxtPreco.Text = 0m.ToString("N2");

                // Cria instância do DAO para acesso aos dados de fornecedores
                FornecedorDAO f_dao = new FornecedorDAO();

                // Configuração do ComboBox de fornecedores:
                // - Verifica se existem dados válidos (não nulos e com colunas esperadas)
                // - Define a fonte de dados, o campo a ser exibido e o valor associado
                
                    CbFornecedor.DataSource = f_dao.ListarFornecedor(); ;
                    CbFornecedor.DisplayMember = "nome";
                    CbFornecedor.ValueMember = "id";
                

                CarregarProdutos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Método para carregar todos os produtos na tabela
        private void CarregarProdutos()
        {
            ProdutoDAO dao = new ProdutoDAO();
            TabelaProdutos.DataSource = dao.ListarProduto();
        }

        // Evento do botão Novo - Limpa todos os campos
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        // Evento do botão Adicionar - Cadastra novo produto
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            //Armazenando os dados do produto
            try
            {
                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(TxtDescricao.Text) ||
                    string.IsNullOrWhiteSpace(TxtPreco.Text) ||
                    string.IsNullOrWhiteSpace(TxtQtd.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios!");
                    return;
                }

                // Validação de campos numéricos
                if (!decimal.TryParse(TxtPreco.Text, out decimal preco))
                {
                    MessageBox.Show("Preço inválido!");
                    return;
                }

                if (!int.TryParse(TxtQtd.Text, out int qtdEstoque))
                {
                    MessageBox.Show("Quantidade de estoque inválida!");
                    return;
                }

                // Cria objeto Produto com os dados do formulário
                Produto obj = new Produto
                {
                    descricao = TxtDescricao.Text,
                    preco = preco,
                    qtdestoque = qtdEstoque,
                    for_id = Convert.ToInt32(CbFornecedor.SelectedValue)
                };

                // Cadastra o produto no banco de dados
                ProdutoDAO dao = new ProdutoDAO();
                dao.CadastrarProduto(obj);

                // Atualiza a tabela e limpa os campos
                CarregarProdutos();
                new Helpers().LimparTela(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Evento do botão Atualizar - Edita produto existente
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(TxtDescricao.Text) ||
                    string.IsNullOrWhiteSpace(TxtPreco.Text) ||
                    string.IsNullOrWhiteSpace(TxtQtd.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios!");
                    return;
                }

                // Validação de campos numéricos
                if (!decimal.TryParse(TxtPreco.Text, out decimal preco))
                {
                    MessageBox.Show("Preço inválido!");
                    return;
                }

                if (!int.TryParse(TxtQtd.Text, out int qtdEstoque))
                {
                    MessageBox.Show("Quantidade de estoque inválida!");
                    return;
                }

                // Validação do fornecedor selecionado
                if (CbFornecedor.SelectedValue == null || !int.TryParse(CbFornecedor.SelectedValue.ToString(), out int for_id))
                {
                    MessageBox.Show("Fornecedor inválido!");
                    return;
                }

                // Cria objeto Produto com os dados do formulário
                Produto obj = new Produto
                {
                    descricao = TxtDescricao.Text,
                    preco = preco,
                    qtdestoque = qtdEstoque,
                    for_id = for_id
                };

                // Atualiza o produto no banco de dados
                ProdutoDAO dao = new ProdutoDAO();
                dao.CadastrarProduto(obj);

                // Atualiza a tabela e limpa os campos
                CarregarProdutos();
                new Helpers().LimparTela(this);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // Evento do botão Deletar - Remove produto selecionado
        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                // Cria objeto Produto apenas com o ID para exclusão
                Produto obj = new Produto();
                obj.id = Convert.ToInt32(TxtCodigo.Text);

                ProdutoDAO dao = new ProdutoDAO();
                dao.ExcluirProduto(obj);

                CarregarProdutos();
                new Helpers().LimparTela(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Evento do botão Pesquisar - Busca produtos por nome/descrição
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = TxtPesquisa.Text;
            ProdutoDAO dao = new ProdutoDAO();
            TabelaProdutos.DataSource = dao.BuscarProdutoPorNome(nome);

            if (TabelaProdutos.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado!");
               TabelaProdutos.DataSource = dao.ListarProduto();
            }
        }

        // Evento CellClick da tabela - Preenche campos ao clicar em um produto
        private void TabelaProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Preenche os campos com os dados da linha selecionada
                TxtCodigo.Text = TabelaProdutos.CurrentRow.Cells[0].Value.ToString();
                TxtDescricao.Text = TabelaProdutos.CurrentRow.Cells[1].Value.ToString();
                TxtPreco.Text = TabelaProdutos.CurrentRow.Cells[2].Value.ToString();
                TxtQtd.Text = TabelaProdutos.CurrentRow.Cells[3].Value.ToString();
                CbFornecedor.Text = TabelaProdutos.CurrentRow.Cells[4].Value.ToString();
                
                // Muda para a aba de cadastro/edição
                TabelaProduto.SelectedTab = tabPage1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Evento KeyPress da pesquisa - Busca dinâmica durante digitação
        private void TxtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = $"%{TxtPesquisa.Text}%";
            ProdutoDAO dao = new ProdutoDAO();

            TabelaProdutos.DataSource = dao.ListarProdutoPorNome(nome);
        }

    }
}
