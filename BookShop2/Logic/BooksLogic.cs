using BookShop.Core.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BookShop2.Logic
{
    class BooksLogic
    {
        private string ConnectionStringDb = ConfigurationManager.ConnectionStrings["BooksDb"].ConnectionString;

        //private SqlConnection SqlConnection = null;

        private SqlCommandBuilder SqlBuilder = null;

        private SqlDataAdapter SqlDataAdapter = null;

        private DataTable DataTable = null;

        public DataTable LoadData()
        {
            using (var sqlConnection = new SqlConnection(ConnectionStringDb))
            {
                sqlConnection.Open();

                SqlDataAdapter = new SqlDataAdapter("SELECT *, 'Buy' AS [Buy] FROM Books", sqlConnection);

                SqlBuilder = new SqlCommandBuilder(SqlDataAdapter);

                SqlBuilder.GetInsertCommand();
                SqlBuilder.GetUpdateCommand();
                SqlBuilder.GetDeleteCommand();

                DataTable = new DataTable();
                SqlDataAdapter.Fill(DataTable);
            }
            return DataTable;

            //DataTable = new DataTable();
            //DataTable.Columns.Add("Id");
            //DataTable.Columns.Add("Title");
            //DataTable.Columns.Add("Author");
            //DataTable.Columns.Add("Date");
            //DataTable.Columns.Add("Buy");

            //using (BookDbContext context = new BookDbContext())
            //{
            //    var booksList = context.Books.ToList();

            //    foreach (var item in booksList)
            //    {
            //        var row = DataTable.NewRow();

            //        row["Id"] = item.Id;
            //        row["Title"] = item.Title;
            //        row["Author"] = item.Author;
            //        row["Date"] = Convert.ToString(item.Date);
            //        row["Buy"] = "Buy";

            //        DataTable.Rows.Add(row);
            //    }
            //}
            //return DataTable;
        }

        public void UpdateData(DataTable dataTable, int rowIndex)
        {
            using (var sqlConnection = new SqlConnection(ConnectionStringDb))
            {
                sqlConnection.Open();

                SqlDataAdapter = new SqlDataAdapter("SELECT *, 'Buy' AS [Buy] FROM Books", sqlConnection);

                SqlBuilder = new SqlCommandBuilder(SqlDataAdapter);

                SqlDataAdapter.Update(dataTable);

                // todo
                // здесь нам нужна только последняя строка 
                // SqlDataAdapter.Update(dataTable);
                // однако в SqlDataAdapter надо как то передать строку подключения
                // (как передать только эту строку, без команды)
                // и дальше создать SqlBuilder.

            }

            //using (BookDbContext context = new BookDbContext())
            //{
            //    var cellValue = dataTable.Rows[rowIndex].Field<string>("Id");
            //    // todo
            //    // почему здесь поле int но система принимает string?
            //    Book book = context.Books
            //        .Where(s => s.Id == int.Parse(cellValue))
            //        .FirstOrDefault();
            //    if (book != null)
            //    {
            //        context.Remove(book);
            //        context.SaveChanges();
            //    }

            //    //Book book = new Book();
            //    //foreach (DataRow row in dataTable.Rows)
            //    //{
            //    //    //book.Id = row.Field<int>("Id");
            //    //    book.Title = row.Field<string>("Title");//    "tiile4";//  
            //    //    book.Author = row.Field<string>("Author");//    "author";//    
            //    //    book.Date = new DateTime(1900, 01, 01, 12, 00, 00);// DateTime.Parse(row.Field<string>("Date"));
            //    //                                                       //context.Books.Update(book);
            //    //    context.SaveChanges();
            //    //}

            //}
        }

        public DataTable ReloadData()
        {
            DataTable.Clear();

            using (var sqlConnection = new SqlConnection(ConnectionStringDb))
            {
                sqlConnection.Open();

                SqlDataAdapter = new SqlDataAdapter("SELECT *, 'Buy' AS [Buy] FROM Books", sqlConnection);

                SqlBuilder = new SqlCommandBuilder(SqlDataAdapter);

                SqlDataAdapter.Fill(DataTable);
            }

            return DataTable;
        }
    }
}
