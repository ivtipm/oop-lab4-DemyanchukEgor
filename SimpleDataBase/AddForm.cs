using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDataBase
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void closeAddFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            MainForm mForm = this.Owner as MainForm;
            try
            {
                string author = authorTextBox.Text;
                string title = titleTextBox.Text;
                ushort year = (ushort)Convert.ToUInt64(yearTextBox.Text);
                string genre = genreTextBox.Text;
                uint count = (uint)Convert.ToUInt64(countTextBox.Text);
                uint price = (uint)Convert.ToUInt64(priceTextBox.Text);

                authorTextBox.Text = "";
                titleTextBox.Text = "";
                yearTextBox.Text = "";
                genreTextBox.Text = "";
                countTextBox.Text = "";
                priceTextBox.Text = "";

                mForm.data.AddBook(author, title, year, genre, count, price);
                int n = mForm.data.Book.Count;
                mForm.dataGridViewTable.Rows.Add(author, title, year, genre, count, price);
                mForm.BanChangeColumn(n - 1);
            }
            catch
            {
                MessageBox.Show("Некорректные данные!");
            }
        }

        private void authorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void yearTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
