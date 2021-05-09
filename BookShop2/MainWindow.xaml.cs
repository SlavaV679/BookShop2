using System;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;

namespace BookShop2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logic.BooksLogic booksLogic;
        public MainWindow()
        {
            InitializeComponent();

            booksLogic = new Logic.BooksLogic();

            DataTable = booksLogic.LoadData();

            dataGridData.DataContext = DataTable;
        }


        private DataTable DataTable = null;

        private void Row_MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            int columnIndex = dataGridData.SelectedCells.IndexOf(dataGridData.CurrentCell);
            //try
            //{
                if (columnIndex == 4)
                {
                    if (MessageBox.Show("Купить эту книгу?", "Оформление заказа",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        int rowIndex = dataGridData.SelectedIndex;

                        booksLogic.UpdateData(DataTable, rowIndex);

                        DataTable.Rows[rowIndex].Delete();

                    
                        //dataGridData.DataContext = booksLogic.ReloadData();
                        // todo 
                        // правильно ли то что я разделил методы
                        // Обновить БД - UpdateData и
                        // Выгрузить из БД актуальные данные - ReloadData  ??
                        // По сути ведь можно обновить и сразу в этом же методе выгрузить данные.
                    }

                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK);
            //}
        }
    }
}
