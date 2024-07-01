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

namespace CRUD_C_
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;
        int i = 0;

        dbconnection dbconn =new dbconnection(); 
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection(dbconn.dbconnect());

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carregarRegistro();
        }

        public void carregarRegistro()
        {
            dataGridView1.Rows.Clear();
            conn.Open();
            cmd = new MySqlCommand("SELECT `codestu`, `nomeestu`, `nomemae`, `curso`, `datanasc`, `endereco`, `telefone` FROM `tb_crud`", conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                dataGridView1.Rows.Add(dataGridView1.Rows.Count + 1,dr["codestu"].ToString(),dr["nomeestu"].ToString(),dr["nomemae"].ToString(),dr["curso"].ToString(),dr["datanasc"].ToString(),dr["endereco"].ToString(),dr["telefone"].ToString());
            }
            dr.Close();
            conn.Close();

        }

        public void Limpar()
        {
            txt_endereco.Clear();
            txt_nomeMae.Clear();
            txt_telefone.Clear();
            txt_codEstu.Clear();
            txt_nomeEstu.Clear();
            cbo_curso.SelectedIndex = -1;
            dtp_dataNasc.Value = DateTime.Now;
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if ((txt_codEstu.Text==string.Empty) || (txt_nomeEstu.Text==string.Empty) || (txt_nomeMae.Text==string.Empty) || (txt_endereco.Text==string.Empty) || (txt_telefone.Text==string.Empty) || (cbo_curso.Text==string.Empty))
            {
                MessageBox.Show("Atenção: Campo de preenchimento obrigatório?", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                string date1 = dtp_dataNasc.Value.ToString("dd-MM-yyyy");
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tb_crud`(`codestu`, `nomeestu`, `nomemae`, `curso`, `datanasc`, `endereco`, `telefone`) VALUES (@codestu,@nomeestu,@nomemae,@curso,@datanasc,@endereco,@telefone)", conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@codestu",txt_codEstu.Text);
                cmd.Parameters.AddWithValue("@nomeestu", txt_nomeEstu.Text);
                cmd.Parameters.AddWithValue("@nomemae", txt_nomeMae.Text);
                cmd.Parameters.AddWithValue("@curso", cbo_curso.Text);
                cmd.Parameters.AddWithValue("@datanasc", date1);
                cmd.Parameters.AddWithValue("@endereco", txt_endereco.Text);
                cmd.Parameters.AddWithValue("@telefone", txt_telefone.Text);

                i=cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Registro Salvo com Sucesso!","CRUD",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Falha ao Salvar Registro!", "CRUD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                conn.Close();
                carregarRegistro();
                Limpar();
            }
        }
    }
}
