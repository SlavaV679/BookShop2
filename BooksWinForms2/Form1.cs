using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksWinForms2
{
    public partial class Form1 : Form
    {
        private string ConnectionStringDb = ConfigurationManager.ConnectionStrings["BooksDb"].ConnectionString;

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
            LoadData();
        }

        private void LoadData()
        {
            SqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] FROM Books", SqlConnection);

            SqlBuilder = new SqlCommandBuilder(SqlDataAdapter);

            SqlBuilder.GetInsertCommand();
            SqlBuilder.GetUpdateCommand();
            SqlBuilder.GetDeleteCommand();

            DataSet = new DataSet();

            SqlDataAdapter.Fill(DataSet, "Books");

            dataGridView1.DataSource = DataSet.Tables["Books"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //dataGridView1[4, i] = linkCell;
            }

        }

        private void ReloadData()
        {
            DataSet.Tables["Books"].Clear();

            SqlDataAdapter.Fill(DataSet, "Books");

            dataGridView1.DataSource = DataSet.Tables["Books"];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //dataGridView1[4, i] = linkCell;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView1.Rows.RemoveAt(rowIndex);

                            DataSet.Tables["Books"].Rows[rowIndex].Delete();

                            SqlDataAdapter.Update(DataSet, "Books");
                        }
                    }
                    else if (task == "Isert")
                    {

                    }
                    else if (task == "Update")
                    {

                    }
                    ReloadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }


    }
}
