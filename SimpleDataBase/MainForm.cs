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
    public partial class MainForm : Form
    {
        public BooksData data = new BooksData();
        public string oldValue = "";
        public string filename = "";

        public MainForm()
        {
            InitializeComponent();

            dataGridViewTable.Rows[0].ReadOnly = true;
            dataGridViewTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            choiseSortComboBox.Text = choiseSortComboBox.Items[0].ToString();

            autoSaveLabel.Visible = false;
            saveLabel.Visible = false;
            sortPanel.Visible = false;

            InitializeTimers();
        }

        private void InitializeTimers()
        {
            saveTimer.Interval = 3000;
            saveTimer.Tick += new EventHandler(saveTimer_Tick);
            autoSaveTimer.Interval = 60000;
            autoSaveTimer.Tick += new EventHandler(autoSaveTimer_Tick);
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            if (autoSaveLabel.Visible)
            {
                autoSaveLabel.Visible = false;
            }
            else
            {
                saveLabel.Visible = false;
            }
            saveTimer.Enabled = false;
            saveTimer.Stop();
        }

        private void autoSaveTimer_Tick(object sender, EventArgs e)
        {
            data.SaveToFile(filename);
            autoSaveLabel.Visible = true;
            saveTimer.Enabled = true;
            saveTimer.Start();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addform = new AddForm();
            addform.Owner = this;
            addform.Show();
        }
        public void BanChangeColumn(int index) =>
            dataGridViewTable.Rows[index].Cells[0].ReadOnly = true;

        private void sortButton_Click(object sender, EventArgs e)
        {
            if (!sortPanel.Visible)
                sortPanel.Visible = true;
            else
                sortPanel.Visible = false;
        }

        private void toSortButton_Click(object sender, EventArgs e)
        {
            if (data.Book.Count != 0)
            {
                dataGridViewTable.Rows.Clear();

                if (choiseSortComboBox.SelectedIndex == 0)
                    data.Sort(SortDirection.Ascending);
                else
                    data.Sort(SortDirection.Descending);

                WriteToDataGrid();
            }
        }

        private void WriteToDataGrid()
        {
            for (int i = 0; i < data.Book.Count; i++)
            {
                Book b = (Book)data.Book[i];
                dataGridViewTable.Rows.Add(b.Author, b.Title, b.Year, b.Genre, b.Count, b.Price);
                BanChangeColumn(i);
            }
            dataGridViewTable.Rows[data.Book.Count].ReadOnly = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int count = dataGridViewTable.Rows.Count;
            foreach (DataGridViewRow row in dataGridViewTable.SelectedRows)
            {
                int index = row.Index;
                if (index == count - 1) return;
                data.DeleteBook(index);
                dataGridViewTable.Rows.RemoveAt(index);
            }
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            if (data.Book.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены, " +
                    "что хотите стереть все данные?\nОтменить это действие будет невозможно!", 
                    "Подтверждение", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    data.DeleteBooks();
                    dataGridViewTable.Rows.Clear();
                }
            }
        }

        private void dataGridViewTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indRow = dataGridViewTable.Rows[e.RowIndex].Index;
            int indColumn = dataGridViewTable.Columns[e.ColumnIndex].Index;
            object value = dataGridViewTable.Rows[indRow].Cells[indColumn].Value;
            if (value is null)
            {
                MessageBox.Show("Вы не ввели новое значение!", "Ошибка");
                dataGridViewTable.Rows[indRow].Cells[indColumn].Value = oldValue;
                return;
            }

            if (indColumn == 0)
                data.ChangeAuthor((string)value, indRow);

            else if (indColumn == 1)
                data.ChangeTitle((string)value, indRow);

            else if (indColumn == 2)
                data.ChangeYear((ushort)Convert.ToUInt64(value), indRow);

            else if (indColumn == 3)
                data.ChangeGenre((string)value, indRow);

            else if (indColumn == 4)
                data.ChangeCount((uint)Convert.ToUInt64(value), indRow);

            else if (indColumn == 5)
                data.ChangePrice((uint)Convert.ToUInt64(value), indRow);
        }

        private void dataGridViewTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                oldValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((data.Book.Count != 0) || (filename != ""))
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены, " +
                    "что хотите создать новый файл?", "Подтверждение", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    this.Text = "База данных книжного магазина";
                    filename = "";
                    data.DeleteBooks();
                    dataGridViewTable.Rows.Clear();
                    saveTimer.Stop();
                    saveTimer.Enabled = false;
                    autoSaveTimer.Stop();
                    autoSaveTimer.Enabled = false;
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            filename = openFileDialog.FileName;
            this.Text = filename + " - База данных книжного магазина";

            dataGridViewTable.Rows.Clear();
            data.OpenFile(filename);

            WriteToDataGrid();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename == "")
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                filename = saveFileDialog.FileName;
                this.Text = filename + " - База данных книжного магазина";
            }

            if (!autoSaveTimer.Enabled)
            {
                autoSaveTimer.Enabled = true;
                autoSaveTimer.Start();
            }

            saveLabel.Visible = true;
            saveTimer.Enabled = true;
            saveTimer.Start();

            data.SaveToFile(filename);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Info = "База данных наличия книг в книжном магазине\nВерсия 1.0\n\n";
            MessageBox.Show(Info, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.Owner = this;
            sf.Show();
        }

        private void оРазработчикеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Info = "Разработчик: Демьянчук Е.В., студент группы ИВТ-18-1\n\n" +
                "GitHub: https://github.com/DemyanchukEgor \n";
            MessageBox.Show(Info, "О разработчике", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void autoSaveLabel_Click(object sender, EventArgs e)
        {

        }

        private void choiseSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
