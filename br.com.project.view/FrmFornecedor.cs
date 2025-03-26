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
    public partial class FrmFornecedor : Form
    {
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        // Evento Load do formulário - Carrega os fornecedores ao abrir a tela
        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            CarregarFornecedor();
        }

        // Evento do botão Buscar - Consulta CEP via webservice
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            new Helpers().BuscarCep(TxtCep.Text, TxtEndereco, TxtBairro, TxtCidade, CbUf, TxtComplemento);
        }

        // Método para carregar todos os fornecedores na tabela
        private void CarregarFornecedor()
        {
            FornecedorDAO dao = new FornecedorDAO();
            TabelaFornecedores.DataSource = dao.ListarFornecedor();
        }

        // Evento do botão Novo - Limpa todos os campos
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        // Evento do botão Adicionar - Cadastra novo fornecedor
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(TxtNome.Text) ||
                    string.IsNullOrWhiteSpace(TxtCnpj.Text) ||
                    string.IsNullOrWhiteSpace(TxtEmail.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefone.Text) ||
                    string.IsNullOrWhiteSpace(TxtCelular.Text) ||
                    string.IsNullOrWhiteSpace(TxtCep.Text) ||
                    string.IsNullOrWhiteSpace(TxtEndereco.Text) ||
                    string.IsNullOrWhiteSpace(TxtBairro.Text) ||
                    string.IsNullOrWhiteSpace(TxtCidade.Text) ||
                    string.IsNullOrWhiteSpace(CbUf.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios!");
                    return;
                }

                // Validação do campo número
                if (!int.TryParse(TxtNumero.Text, out int numero))
                {
                    MessageBox.Show("Insira um número!");
                    return;
                }

                // Cria objeto Fornecedor com os dados do formulário
                Fornecedor obj = new Fornecedor()
                {
                    nome = TxtNome.Text,
                    cnpj = TxtCnpj.Text,
                    email = TxtEmail.Text,
                    telefone = TxtTelefone.Text,
                    celular = TxtCelular.Text,
                    cep = TxtCep.Text,
                    endereco = TxtEndereco.Text,
                    numero = Convert.ToInt32(TxtNumero.Text),
                    complemento = TxtComplemento.Text,
                    bairro = TxtBairro.Text,
                    cidade = TxtCidade.Text,
                    estado = CbUf.Text,
                };

                FornecedorDAO dao = new FornecedorDAO();
                dao.CadastrarFornecedor(obj);

                // Atualiza a tabela e limpa os campos
                CarregarFornecedor();
                new Helpers().LimparTela(this);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Evento do botão Atualizar - Edita fornecedor existente
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validação dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(TxtNome.Text) ||
                    string.IsNullOrWhiteSpace(TxtCnpj.Text) ||
                    string.IsNullOrWhiteSpace(TxtEmail.Text) ||
                    string.IsNullOrWhiteSpace(TxtTelefone.Text) ||
                    string.IsNullOrWhiteSpace(TxtCelular.Text) ||
                    string.IsNullOrWhiteSpace(TxtCep.Text) ||
                    string.IsNullOrWhiteSpace(TxtEndereco.Text) ||
                    string.IsNullOrWhiteSpace(TxtBairro.Text) ||
                    string.IsNullOrWhiteSpace(TxtCidade.Text) ||
                    string.IsNullOrWhiteSpace(CbUf.Text))
                {
                    MessageBox.Show("Preencha todos os campos obrigatórios!");
                    return;
                }

                if (!int.TryParse(TxtNumero.Text, out int numero))
                {
                    MessageBox.Show("Insira um número!");
                    return;
                }

                // Cria objeto Fornecedor com os dados do formulário
                Fornecedor obj = new Fornecedor()
                {
                    nome = TxtNome.Text,
                    cnpj = TxtCnpj.Text,
                    email = TxtEmail.Text,
                    telefone = TxtTelefone.Text,
                    celular = TxtCelular.Text,
                    cep = TxtCep.Text,
                    endereco = TxtEndereco.Text,
                    numero = Convert.ToInt32(TxtNumero.Text),
                    complemento = TxtComplemento.Text,
                    bairro = TxtBairro.Text,
                    cidade = TxtCidade.Text,
                    estado = CbUf.Text,
                    id = Convert.ToInt32(TxtCodigo.Text),
                };

                FornecedorDAO dao = new FornecedorDAO();
                dao.AtualizarFornecedor(obj);

                CarregarFornecedor();
                new Helpers().LimparTela(this);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Evento do botão Deletar - Remove fornecedor selecionado
        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                Fornecedor obj = new Fornecedor();
                obj.id = Convert.ToInt32(TxtCodigo.Text);

                FornecedorDAO dao = new FornecedorDAO();
                dao.ExcluirFornecedor(obj);

                CarregarFornecedor();
                new Helpers().LimparTela(this);
            }
            catch (Exception)
            {
                throw;
            }

        }

        // Evento do botão Pesquisar - Busca fornecedores por nome
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = TxtPesquisa.Text;
            FornecedorDAO dao = new FornecedorDAO();
            TabelaFornecedores.DataSource = dao.BuscarFornecedorPorNome(nome);

            if (TabelaFornecedores.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum fornecedor encontrado!");
                TabelaFornecedores.DataSource = dao.ListarFornecedorPorNome(nome);
            }
        }

        // Evento KeyPress da pesquisa - Busca dinâmica durante digitação
        private void TxtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = $"%{TxtPesquisa.Text}%";
            FornecedorDAO dao = new FornecedorDAO();

            TabelaFornecedores.DataSource = dao.ListarFornecedorPorNome(nome);
        }

        // Evento CellClick da tabela - Preenche campos ao clicar em um fornecedor
        private void TabelaFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Preenche os campos com os dados da linha selecionada
                TxtCodigo.Text = TabelaFornecedores.CurrentRow.Cells[0].Value.ToString();
                TxtNome.Text = TabelaFornecedores.CurrentRow.Cells[1].Value.ToString();
                TxtCnpj.Text = TabelaFornecedores.CurrentRow.Cells[2].Value.ToString();
                TxtEmail.Text = TabelaFornecedores.CurrentRow.Cells[3].Value.ToString();
                TxtTelefone.Text = TabelaFornecedores.CurrentRow.Cells[4].Value.ToString();
                TxtCelular.Text = TabelaFornecedores.CurrentRow.Cells[5].Value.ToString();
                TxtCep.Text = TabelaFornecedores.CurrentRow.Cells[6].Value.ToString();
                TxtEndereco.Text = TabelaFornecedores.CurrentRow.Cells[7].Value.ToString();
                TxtNumero.Text = TabelaFornecedores.CurrentRow.Cells[8].Value.ToString();
                TxtComplemento.Text = TabelaFornecedores.CurrentRow.Cells[9].Value.ToString();
                TxtBairro.Text = TabelaFornecedores.CurrentRow.Cells[10].Value.ToString();
                TxtCidade.Text = TabelaFornecedores.CurrentRow.Cells[11].Value.ToString();
                CbUf.Text = TabelaFornecedores.CurrentRow.Cells[12].Value.ToString();

                // Muda para a aba de cadastro/edição
                TabelaFornecedor.SelectedTab = tabPage1;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
