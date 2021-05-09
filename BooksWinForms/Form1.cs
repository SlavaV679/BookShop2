using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BooksWinForms
{
    public partial class Form1 : Form
    {             private string ConnectionStringDb = ConfigurationManager.ConnectionStrings["BooksDb"].ConnectionString;

        private SqlConnection SqlConnection = null;

        private SqlCommandBuilder SqlBuilder = null;

        private SqlDataAdapter SqlDataAdapter = null;

        private DataSet DataSet = null;

        private SqlDataReader SqlReader = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



            SqlConnection = new SqlConnection(ConnectionStringDb);
            SqlConnection.Open();

            //await SqlConnection.OpenAsync();
            //if (SqlConnection.State == ConnectionState.Open)
            //{
            //    MessageBox.Show("Подключение установлено!");
            //}

            //SqlCommand command = new SqlCommand("SELECT * FROM [Books]", SqlConnection);

            SqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] FROM Books", SqlConnection);

            SqlBuilder = new SqlCommandBuilder(SqlDataAdapter);

            SqlBuilder.GetInsertCommand();
            SqlBuilder.GetUpdateCommand();
            SqlBuilder.GetDeleteCommand();
            //DataTable dataTable = new DataTable();
            //SqlDataAdapter.Fill(dataTable);
            
            DataSet = new DataSet();

            SqlDataAdapter.Fill(DataSet, "Books");

            dataGridView1.DataSource = DataSet.Tables["Books"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //dataGridView1[5, i] = linkCell;
            }
        }
    }
}
