using MySql.Data.MySqlClient;
using Sistema_de_Cadastro_de_produtos.br.com.project.conexao;
using Sistema_de_Cadastro_de_produtos.br.com.project.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cadastro_de_produtos.br.com.project.dao
{
    public class ProdutoDAO
    {
        #region CONEXÃO COM BANCO DE DADOS
        private MySqlConnection conexao;

        // Construtor - inicializa a conexão com o banco de dados
        public ProdutoDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }
        #endregion

        #region MÉTODO PARA CADASTRAR PRODUTO
        public void CadastrarProduto(Produto obj)
        {
            try
            {
                // Comando SQL para inserção de novo fornecedor
                string sql = @"insert into tb_produtos (descricao, preco, qtd_estoque, for_id) 
                                values (@descricao, @preco, @qtd_estoque, @for_id)";

                // Configuração dos parâmetros do comando SQL
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@descricao", obj.descricao);
                cmd.Parameters.AddWithValue("@preco", obj.preco);
                cmd.Parameters.AddWithValue("@qtd_estoque", obj.qtdestoque);
                cmd.Parameters.AddWithValue("@for_id", obj.for_id);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao cadastrar o produto: {erro.Message}");
            }
        }
        #endregion

        #region MÉTODO PARA LISTAR PRODUTOS
        public DataTable ListarProduto()
        {
            try
            {
                // Criação da tabela de dados para armazenar os resultados
                DataTable tabelaprodutos = new DataTable();

                // Consulta SQL para obter todos os fornecedores
                string sql = @"select p.id as 'Código',
	                                  p.descricao as 'Descrição',
	                                  p.preco as 'Preço',
	                                  p.qtd_estoque as 'Qtd Estoque',
	                                  f.nome as 'Fornecedor' from tb_produtos as p
	                                  join tb_fornecedores as f on (p.for_id = f.id);";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    conexao.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabelaprodutos);
                    }
                    conexao.Close();
                }
                return tabelaprodutos;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao listar os produtos: {erro.Message}");
                return null;
            }
        }
        #endregion

        #region MÉTODO PARA ATUALIZAR  PRODUTO
        public void AtualizarProduto(Produto obj)
        {
            try
            {
                // Comando SQL para atualização de fornecedor existente
                string sql = @"update tb_produtos set descricao = @descricao, preco = @preco, qtd_estoque = @qtd_estoque, for_id = @for_id 
                               where id = @id";

                // Configuração dos parâmetros do comando SQL
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@descricao", obj.descricao);
                cmd.Parameters.AddWithValue("@preco", obj.preco);
                cmd.Parameters.AddWithValue("@qtd_estoque", obj.qtdestoque);
                cmd.Parameters.AddWithValue("@for_id", obj.for_id);
                cmd.Parameters.AddWithValue("@id", obj.id);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto atualizado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao atualizar o produto: {erro.Message}");
            }
        }
        #endregion

        #region MÉTODO PARA EXCLUIR PRODUTO
        public void ExcluirProduto(Produto obj)
        {
            try
            {
                // Comando SQL para exclusão de fornecedor por ID
                string sql = @"delete from tb_produtos where id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", obj.id);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Produto excluído com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir o produto: {erro.Message}");
            }
        }
        #endregion

        #region MÉTODO PARA LISTAR PRODUTO POR NOME
        public DataTable ListarProdutoPorNome(string nome)
        {
            try
            {
                DataTable tabelaproduto = new DataTable();

                // Consulta SQL com filtro por nome (busca parcial)
                string sql = @"select * from tb_produtos where descricao like @descricao";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@descricao", $"%{nome}%");
                    conexao.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabelaproduto);
                    }
                    conexao.Close();
                }

                return tabelaproduto;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao listar os produtos: {erro.Message}");
                return null;
            }
        }
        #endregion

        #region Buscar Produto por Nome
        public DataTable BuscarProdutoPorNome(string nome)
        {
            try
            {
                DataTable tabelaproduto = new DataTable();

                // Consulta SQL com filtro por nome (busca exata)
                string sql = @"select * from tb_produtos where descricao = @descricao";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@descricao", $"%{nome}%");
                    conexao.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabelaproduto);
                    }
                    conexao.Close();
                }
                return tabelaproduto;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao buscar o produto: {erro.Message}");
                return null;
            }
        }
        #endregion

        #region Retorna produto por código
        public Produto RetornaProdutoPorCodigo(int id)
        {
            try
            {
                // Consulta SQL com filtro por codigo (busca exata)
                string sql = @"select * from tb_produtos where id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);

                cmd.Parameters.AddWithValue("@id", id);
                conexao.Open();
                MySqlDataReader rs = cmd.ExecuteReader();

                if (rs.Read())
                {
                    Produto p = new Produto();
                    p.id = rs.GetInt32("id");
                    p.descricao = rs.GetString("descricao");
                    p.preco = rs.GetDecimal("preco");

                    return p;
                }
                else
                {
                    MessageBox.Show($"Nenhum produto encontrado com esse código!");
                    return null;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show($"Ocorreu o erro: {erro.Message}");
                return null;
            }
        }
        #endregion

    }
}
