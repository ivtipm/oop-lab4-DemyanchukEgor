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
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void closeSearchFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            MainForm frm = this.Owner as MainForm;

            if ((frm.data.Book.Count == 0) || (enterAuthorOrTitleTextBox.Text == ""))
                return;

            frm.dataGridViewTable.ClearSelection();
            List<int> foundElements = frm.data.SearchFile(enterAuthorOrTitleTextBox.Text);

            if (foundElements[0] == -1)
            {
                MessageBox.Show("Ничего не удалось найти!");
                return;
            }

            frm.dataGridViewTable.CurrentCell = frm.dataGridViewTable[0, foundElements[0]];

            for (int i = 0; i < foundElements.Count; i++)
            {
                frm.dataGridViewTable.Rows[foundElements[i]].Selected = true;
            }
        }
    }
}
