using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace E_library
{
    public partial class SignUp_Form : Form
    {
        SqlConnection sqlCon;
        public SignUp_Form(SqlConnection SQL)
        {
            InitializeComponent();
            sqlCon = SQL;
        }

        private void Signup_button_Click(object sender, EventArgs e)
        {
            string Login = Login_textbox.Text;
            if (Login_textbox.Text.Length == 0 || Password_textbox.Text.Length == 0 || Dubpassword_textbox.Text.Length == 0)
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Password_textbox.Text == Dubpassword_textbox.Text)
                {
                    try
                    {
                        string query = "SELECT COUNT(*) FROM Users WHERE Login = '" + Login + "';";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                        object result = sqlCommand.ExecuteScalar();
                        int counter = Convert.ToInt16(result);
                        if (counter == 1)
                        {
                            MessageBox.Show("Даний користувач вже зареєстрований в системі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            query = "INSERT INTO [Users] "
                                    + "([Login], [Password], [Access_level])" +
                                    "VALUES" +
                                    "('" + Login_textbox.Text + "', '"
                                    + Password_textbox.Text + "', '"
                                    + 2 + "')";
                            sqlCommand = new SqlCommand(query, sqlCon);
                            sqlCommand.ExecuteNonQuery();
                            MessageBox.Show("Обліковий запис " + Login_textbox.Text + " успішно зареєстровано в системі з рівнем прав доступу: користувач\nДля зміни рівня прав доступу звертайтеся до адміністратора!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Помилка при підключенні чи роботі з базою даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Перевірте правильність введення паролю!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
