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
    public class FornecedorDAO
    {

        #region CONEXÃO COM BANCO DE DADOS
        private MySqlConnection conexao;

        // Construtor - inicializa a conexão com o banco de dados
        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().GetConnection();
        }
        #endregion

        #region MÉTODO PARA CADASTRAR FORNECEDOR
        public void CadastrarFornecedor(Fornecedor obj)
        {
                try
                {
                    // Comando SQL para inserção de novo fornecedor
                    string sql = @"insert into tb_fornecedores (nome, cnpj, email, telefone,celular, cep, endereco, numero,complemento, bairro, cidade,estado) 
                            values (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                    // Configuração dos parâmetros do comando SQL
                    MySqlCommand cmd = new MySqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@nome", obj.nome);
                    cmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                    cmd.Parameters.AddWithValue("@email", obj.email);
                    cmd.Parameters.AddWithValue("@telefone", obj.telefone);
                    cmd.Parameters.AddWithValue("@celular", obj.celular);
                    cmd.Parameters.AddWithValue("@cep", obj.cep);
                    cmd.Parameters.AddWithValue("@endereco", obj.endereco);
                    cmd.Parameters.AddWithValue("@numero", obj.numero);
                    cmd.Parameters.AddWithValue("@complemento", obj.complemento);
                    cmd.Parameters.AddWithValue("@bairro", obj.bairro);
                    cmd.Parameters.AddWithValue("@cidade", obj.cidade);
                    cmd.Parameters.AddWithValue("@estado", obj.estado);

                    conexao.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fornecedor cadastrado com sucesso!");
                    conexao.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show($" Erro ao cadastrar o fornecedor: {erro.Message}");
                }
        }
        #endregion

        #region MÉTODO PARA ATUALIZAR FORNECEDOR
        public void AtualizarFornecedor(Fornecedor obj)
        {
            try
            {
                // Comando SQL para atualização de fornecedor existente
                string sql = @"update tb_fornecedores set nome=@nome, cnpj=@cnpj, email=@email, telefone=@telefone, celular=@celular, cep=@cep, endereco=@endereco, 
                                numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade,estado=@estado where id=@id";

                // Configuração dos parâmetros do comando SQL
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@nome", obj.nome);
                cmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                cmd.Parameters.AddWithValue("@email", obj.email);
                cmd.Parameters.AddWithValue("@telefone", obj.telefone);
                cmd.Parameters.AddWithValue("@celular", obj.celular);
                cmd.Parameters.AddWithValue("@cep", obj.cep);
                cmd.Parameters.AddWithValue("@endereco", obj.endereco);
                cmd.Parameters.AddWithValue("@numero", obj.numero);
                cmd.Parameters.AddWithValue("@complemento", obj.complemento);
                cmd.Parameters.AddWithValue("@bairro", obj.bairro);
                cmd.Parameters.AddWithValue("@cidade", obj.cidade);
                cmd.Parameters.AddWithValue("@estado", obj.estado);
                cmd.Parameters.AddWithValue("@id", obj.id);

                conexao.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor atualizado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($" Erro ao atualizar o fornecedor: {erro.Message}");
            }
        }
        #endregion

        #region MÉTODO PARA EXCLUIR FORNECEDOR
        public void ExcluirFornecedor(Fornecedor obj)
        {
            try
            {
                // Comando SQL para exclusão de fornecedor por ID
                string sql = "delete from tb_fornecedores where id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", obj.id);

                conexao.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Fornecedor excluído com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir o fornecedor: {erro.Message}");
            }

        }
        #endregion

        #region MÉTODO PARA LISTAR FORNECEDORES
        public DataTable ListarFornecedor()
        {
            try
            {
                // Criação da tabela de dados para armazenar os resultados
                DataTable tabelafornecedor = new DataTable();

                // Consulta SQL para obter todos os fornecedores
                string sql = @"SELECT f.id, f.nome, f.cnpj, f.email,
                                f.telefone, f.celular, f.cep, f.endereco, f.numero,
                                f.complemento, f.bairro, f.cidade, f.estado
                                FROM tb_fornecedores as f";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    conexao.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabelafornecedor);
                    }
                    conexao.Close();
                }
                return tabelafornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao listar fornecedor {erro.Message}");
                return null;
            }
        }
        #endregion

        #region MÉTODO PARA LISTAR FORNECEDORES POR NOME
        public DataTable ListarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();

                // Consulta SQL com filtro por nome (busca parcial)
                string sql = "select * from tb_fornecedores where nome like @nome";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
                    conexao.Open();

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabelafornecedor);
                    }
                    conexao.Close();
                }
                return tabelafornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao listar fornecedor {erro.Message}");
                return null;
            }
        }
        #endregion

        #region MÉTODO PARA BUSCAR FORNECEDORES POR NOME
        public DataTable BuscarFornecedorPorNome(string nome)
        {
            try
            {
                DataTable tabelafornecedor = new DataTable();

                // Consulta SQL com filtro por nome (busca exata)
                string sql = "select * from tb_fornecedores where nome = @nome";

                using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
                    conexao.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(tabelafornecedor);
                    }
                    conexao.Close();
                }
                return tabelafornecedor;
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao buscar fornecedor {erro.Message}");
                return null;
            }
        }
        #endregion

    }
}
