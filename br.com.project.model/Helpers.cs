using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cadastro_de_produtos.br.com.project.model
{
    public class Helpers
    {
        //Limpar o meu campo de texto
        public void LimparTela(Form tela)
        {
            foreach (Control ctrPai in tela.Controls)
            {
                foreach (Control ctr1 in ctrPai.Controls)
                {
                    if (ctr1 is TabPage)
                    {
                        foreach (Control ctr2 in ctr1.Controls)
                        {
                            if (ctr2 is TextBox)
                            {
                                (ctr2 as TextBox).Text = string.Empty;
                            }

                            if (ctr2 is MaskedTextBox)
                            {
                                (ctr2 as MaskedTextBox).Text = string.Empty;
                            }

                            if (ctr2 is ComboBox) {
                                (ctr2 as ComboBox).Text = string.Empty;
                            }

                        }
                    }
                }
            }
        }

        public void BuscarCep(string cep, TextBox txtEndereco, TextBox txtBairro, TextBox txtCidade, ComboBox cbUf, TextBox txtComplemento)
        {

            try
            {
                //Buscar o CEP
                string xml = $"https://viacep.com.br/ws/{cep}/xml/";
                //Ler o XML
                DataSet dados = new DataSet();
                dados.ReadXml(xml);
                //Preencher os campos de texto
                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                cbUf.Text = dados.Tables[0].Rows[0]["uf"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao buscar CEP: {erro.Message}");

            }
        }

    }
}