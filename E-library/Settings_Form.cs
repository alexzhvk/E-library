using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace E_library
{
    public partial class Settings_Form : Form
    {
        SqlConnection sqlCon;
        int access;
        public Settings_Form(SqlConnection SQL, int access_level)
        {
            InitializeComponent();
            sqlCon = SQL;
            label2.Text = trackBar1.Value.ToString();
            access = access_level;
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._E_LibraryDataSet);

        }

        private void Settings_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_E_LibraryDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this._E_LibraryDataSet.Users);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (access < Convert.ToInt32(access_levelTextBox.Text))
            {
                try
                {
                    //  sqlCon.Open();
                    string query = "DELETE FROM Users WHERE Id = '" + idTextBox.Text.ToString() + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.ExecuteNonQuery();
                    UPDATE();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Недостатньо прав доступу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UPDATE()
        {
            try
            {
                string query = "SELECT * FROM Users";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                usersDataGridView.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (access < Convert.ToInt32(access_levelTextBox.Text))
            {
                try
                {
                    string query = "UPDATE [Users] SET Access_level = @Access_level WHERE Id ='" + idTextBox.Text + "'"; 
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.Parameters.AddWithValue("@Access_level", trackBar1.Value);
                    sqlCommand.ExecuteNonQuery();
                    UPDATE();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Недостатньо прав доступу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = usersDataGridView.CurrentCell.RowIndex;
            int col = usersDataGridView.CurrentCell.ColumnIndex;
            string a = usersDataGridView[0, row].Value.ToString();
            //int col = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                //   sqlCon.Open();
                string query = "SELECT Login FROM Users WHERE Id = '" + a + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                loginTextBox.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Password FROM Users WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                passwordTextBox.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Access_level FROM Users WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                access_levelTextBox.Text = sqlCommand.ExecuteScalar().ToString();

                idTextBox.Text = a;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
