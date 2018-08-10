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
    
    public partial class Change_Pass_Form : Form
    {
        string old_pass;
        string log;
        SqlConnection sqlCon;
        public Change_Pass_Form(SqlConnection SQL, string login, string pass)
        {
            InitializeComponent();
            sqlCon = SQL;
            old_pass = pass;
            log = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0 || Password_textbox.Text.Length == 0 || Dubpassword_textbox.Text.Length == 0)
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox1.Text != old_pass)
                {
                    MessageBox.Show("Пароль не вірний!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Password_textbox.Text == Dubpassword_textbox.Text)
                    {
                        try
                        {
                            string query = "UPDATE [Users] SET Password = @Password WHERE Login ='" + log + "'";
                            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                            sqlCommand.Parameters.AddWithValue("@Password", Password_textbox.Text);
                            MessageBox.Show("Пароль успішно змінено!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sqlCommand.ExecuteNonQuery();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
