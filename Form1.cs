using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hands_on_work_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MySqlConnectionStringBuilder conexaoBanco()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "locadora";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            return conexaoBD;
        }


        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void limparCampos()
        {
            textBoxID.Clear();
            textBoxAno.Clear();
            textBoxCor.Clear();
            textBoxNome.Clear();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO carro (nomeCarro,anoCarro,corCarro) " +
                    "VALUES('" + textBoxNome.Text + "'," + Convert.ToInt16(textBoxAno.Text) + " ,'" + textBoxCor.Text + "' )";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();
                MessageBox.Show("Inserido com sucesso");
                limparCampos();
                atualizarGrid();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "UPDATE carro SET nomeCarro = '" + textBoxNome.Text + "', " +
                    "corCarro = '" + textBoxCor.Text + "', " +
                    "anoCarro = '" + textBoxAno.Text + "' WHERE idCarro = " + textBoxID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Atualizado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                if (dataGridViewCarro.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewCarro.CurrentRow.Selected = true;
                    //preenche os textbox com as células da linha selecionada
                    textBoxNome.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnNome"].FormattedValue.ToString();
                    textBoxCor.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnCor"].FormattedValue.ToString();
                    textBoxAno.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnAno"].FormattedValue.ToString();
                    textBoxID.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnID"].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }
        }


        private void atualizarGrid()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM carro";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dataGridViewCarro.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridViewCarro.Rows[0].Clone();//FAZ UM CAST E CLONA A LINHA DA TABELA
                    row.Cells[1].Value = reader.GetInt32(1);//ID
                    row.Cells[2].Value = reader.GetString(2);//NOME
                    row.Cells[3].Value = reader.GetString(3);//ANO
                    dataGridViewCarro.Rows.Add(row);//ADICIONA A LINHA NA TABELA
                }

                realizaConexaoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("not today ! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void Locadora_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }



        private void buttonDeletar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                // "DELETE FROM filme WHERE idCarro = "+ textBoxId.Text +""
                comandoMySql.CommandText = "UPDATE carro SET inativoFilme = 1 WHERE idCarro = " + textBoxID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Deletado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }






        }

        private void dataGridViewCarro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                if (dataGridViewCarro.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dataGridViewCarro.CurrentRow.Selected = true;
                    //preenche os textbox com as células da linha selecionada
                    textBoxNome.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnNome"].FormattedValue.ToString();
                    textBoxCor.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnCor"].FormattedValue.ToString();
                    textBoxAno.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnAno"].FormattedValue.ToString();
                    textBoxID.Text = dataGridViewCarro.Rows[e.RowIndex].Cells["ColumnID"].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

