using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Cadastro_de_produtos.br.com.project.conexao
{

    public class ConnectionFactory
    {
        public MySqlConnection GetConnection()
        {
            try
            {
                // 1. Tenta obter de variáveis de ambiente (melhor para CI/CD)
                string envConnection = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                if (!string.IsNullOrEmpty(envConnection))
                {
                    return new MySqlConnection(envConnection);
                }

                // 2. Fallback para o App.config (desenvolvimento local)
                string configConnection = ConfigurationManager.ConnectionStrings["bdprodutos"]?.ConnectionString;
                if (!string.IsNullOrEmpty(configConnection))
                {
                    return new MySqlConnection(configConnection);
                }

                throw new InvalidOperationException("Nenhuma configuração de conexão encontrada. " +
                    "Configure as variáveis de ambiente ou o App.config.");
            }
            catch (Exception ex)
            {
                // Log seguro para open-source (não expõe detalhes sensíveis)
                throw new InvalidOperationException("Falha ao criar conexão com o banco. " +
                    "Verifique sua configuração.", ex);
            }
        }
    }
}