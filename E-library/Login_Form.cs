using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_library
{
    public partial class Login_Form : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + @"\E-Library.mdf;Integrated Security=True");

        public Login_Form()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            sqlCon.Open();
        }

        public void StartForm()
        {
            Application.Run(new SplashScreen_Form());
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
            sqlCon.Close();
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            if (Guest_checkbox.Checked == true)
            {
                Main_Form mf = new Main_Form(sqlCon, "Guest", "Guest", 3);
                mf.ShowDialog();
            }
            else
            {
                if (Login_textbox.Text.Length == 0 || Password_textbox.Text.Length == 0)
                {
                    MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string Login = Login_textbox.Text;
                    string Password = Password_textbox.Text;
                    try
                    {

                        string query = "SELECT COUNT(*) FROM Users WHERE Login = '" + Login + "' AND Password = '" + Password + "';";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                        object result = sqlCommand.ExecuteScalar();
                        int counter = Convert.ToInt16(result);
                        if (counter == 0)
                        {
                            MessageBox.Show("Невірний логін чи пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            query = "SELECT Id FROM Users WHERE Login = '" + Login + "' AND Password = '" + Password + "';";
                            sqlCommand = new SqlCommand(query, sqlCon);
                            int id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            query = "SELECT Login FROM Users WHERE Id = '" + id + "';";
                            sqlCommand = new SqlCommand(query, sqlCon);
                            string login = sqlCommand.ExecuteScalar().ToString().TrimEnd();
                            query = "SELECT Password FROM Users WHERE Id = '" + id + "';";
                            sqlCommand = new SqlCommand(query, sqlCon);
                            string password = sqlCommand.ExecuteScalar().ToString().TrimEnd();
                            query = "SELECT Access_level FROM Users WHERE Id = '" + id + "';";
                            sqlCommand = new SqlCommand(query, sqlCon);
                            int access = Convert.ToInt32(sqlCommand.ExecuteScalar());
                            Main_Form mf = new Main_Form(sqlCon, login, password, access);
                            mf.ShowDialog();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Помилка при підключенні чи роботі з базою даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }


        private void Guest_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (Guest_checkbox.Checked == false)
            {
                Login_textbox.Enabled = true;
                Password_textbox.Enabled = true;
                Login_textbox.Clear();
                Password_textbox.Clear();
            }
            if (Guest_checkbox.Checked == true)
            {
                Login_textbox.Enabled = false;
                Password_textbox.Enabled = false;
                Login_textbox.Clear();
                Password_textbox.Clear();
            }
        }

        private void Signup_button_Click(object sender, EventArgs e)
        {
            SignUp_Form sf = new SignUp_Form(sqlCon);
            sf.ShowDialog();
        }
    }
}

