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
    public partial class Edit_Form : Form
    {
        SqlConnection sqlCon;
        int counter_pics = 0, counter_links = 0;
        string sFileName;
        string iFileName;
        byte[] byteArray = null;
        int ID;
        public Edit_Form(SqlConnection SQL, string id, string Name, string Author, int Year, string Type, string Genre, string About, double Price, string Comment, int Mark, string Link)
        {
            InitializeComponent();
            ID = Convert.ToInt32(id);
            sqlCon = SQL;
            назваTextBox.Text = Name;
            авторTextBox.Text = Author;
            рік_виданняTextBox.Text = Year.ToString();
            if (Type == "Паперова")
                типcomboBox.SelectedIndex = 0;
            else
                типcomboBox.SelectedIndex = 1;

            switch (Genre)
            {
                case "Бойовики":
                    {
                        жанрСomboBox.SelectedIndex = 0;
                        break;
                    }
                case "Детективи":
                    {
                        жанрСomboBox.SelectedIndex = 1;
                        break;
                    }
                case "Дитячі":
                    {
                        жанрСomboBox.SelectedIndex = 2;
                        break;
                    }
                case "Документальні":
                    {
                        жанрСomboBox.SelectedIndex = 3;
                        break;
                    }
                case "Гумор":
                    {
                        жанрСomboBox.SelectedIndex = 4;
                        break;
                    }
                case "Любовні романи":
                    {
                        жанрСomboBox.SelectedIndex = 5;
                        break;
                    }
                case "Науково-освітні":
                    {
                        жанрСomboBox.SelectedIndex = 6;
                        break;
                    }
                case "Поезія":
                    {
                        жанрСomboBox.SelectedIndex = 7;
                        break;
                    }
                case "Пригоди":
                    {
                        жанрСomboBox.SelectedIndex = 8;
                        break;
                    }
                case "Проза":
                    {
                        жанрСomboBox.SelectedIndex = 9;
                        break;
                    }
                case "Релігія":
                    {
                        жанрСomboBox.SelectedIndex = 10;
                        break;
                    }
                case "Фантастика":
                    {
                        жанрСomboBox.SelectedIndex = 11;
                        break;
                    }
                case "Економіка":
                    {
                        жанрСomboBox.SelectedIndex = 12;
                        break;
                    }
            }
            цінаUpDown.Value = Convert.ToDecimal(Price);
            коментарTextBox.Text = Comment;
            оцінкаUpDown.Value = Convert.ToDecimal(Mark);
            описTextBox.Text = About;
            if (типcomboBox.SelectedIndex == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;

            SelectPicBtn.Enabled = false;
        }

        private void SelectPicBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            //choofdlog.Filter = "Pdf files (*.pdf)|*.pdf*";
            // choofdlog.FilterIndex = 1;
            choofdlog.Filter = "Images|*.png;*.bmp;*.jpeg;*.jpg";
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                counter_pics++;
                iFileName = choofdlog.FileName;
                label2.Text = Path.GetFileName(choofdlog.FileName);  //с расширением
                try
                {
                    using (Bitmap image = new Bitmap(iFileName))
                    {
                        MemoryStream stream = new MemoryStream();
                        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        byteArray = stream.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if (counter_pics>=1 && counter_links == 0)
            {
                if (label2.Text == "Не обрано")
                {
                    MessageBox.Show("Оберіть обкладинку або приберіть параметр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        
                        string query = "UPDATE [Наявні_книги] SET Назва = @Назва,Автор = @Автор,Рік_видання = @Рік_видання,Тип = @Тип,Жанр = @Жанр,Опис = @Опис,Ціна = @Ціна,Коментар = @Коментар,Обкладинка = @Обкладинка,Оцінка = @Оцінка WHERE Id ='" + ID + "'";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                        sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                       // sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
                        sqlCommand.Parameters.AddWithValue("@Жанр", жанрСomboBox.Text.ToString().TrimEnd());
                        sqlCommand.Parameters.AddWithValue("@Опис", описTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Ціна", Convert.ToDouble(цінаUpDown.Value));
                        sqlCommand.Parameters.AddWithValue("@Коментар", коментарTextBox.Text);
                        SqlParameter imageParameter = sqlCommand.Parameters.Add("@Обкладинка", SqlDbType.Binary);
                        imageParameter.Value = byteArray;
                        imageParameter.Size = byteArray.Length;
                        sqlCommand.Parameters.AddWithValue("@Оцінка", Convert.ToString(оцінкаUpDown.Value));

                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Книгу додано до бібліотеки!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // sqlCon.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка");
                        //MessageBox.Show("Помилка при підключенні чи роботі з базою даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (counter_links == 0 && counter_pics == 0)
            {
                try
                {
                    string query = "UPDATE [Наявні_книги] SET Назва = @Назва,Автор = @Автор,Рік_видання = @Рік_видання,Тип = @Тип,Жанр = @Жанр,Опис = @Опис,Ціна = @Ціна,Коментар = @Коментар,Оцінка = @Оцінка WHERE Id ='" + ID + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                   // sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("@Жанр", жанрСomboBox.Text.ToString().TrimEnd());
                    sqlCommand.Parameters.AddWithValue("@Опис", описTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Ціна", Convert.ToDouble(цінаUpDown.Value));
                    sqlCommand.Parameters.AddWithValue("@Коментар", коментарTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Оцінка", Convert.ToString(оцінкаUpDown.Value));

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Книгу додано до бібліотеки!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // sqlCon.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка");
                    //MessageBox.Show("Помилка при підключенні чи роботі з базою даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (counter_links >= 1 && counter_pics >= 1)
            {
                if (label2.Text == "Не обрано")
                {
                    MessageBox.Show("Оберіть обкладинку або приберіть параметр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        
                        string query = "UPDATE [Наявні_книги] SET Назва = @Назва,Автор = @Автор,Рік_видання = @Рік_видання,Тип = @Тип,Жанр = @Жанр,Опис = @Опис,Ціна = @Ціна,Коментар = @Коментар,Обкладинка = @Обкладинка,Оцінка = @Оцінка,Посилання = @Посилання WHERE Id ='" + ID + "'";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                        sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                        //sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
                        sqlCommand.Parameters.AddWithValue("@Жанр", жанрСomboBox.Text.ToString().TrimEnd());
                        sqlCommand.Parameters.AddWithValue("@Опис", описTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Ціна", Convert.ToDouble(цінаUpDown.Value));
                        sqlCommand.Parameters.AddWithValue("@Коментар", коментарTextBox.Text);
                        SqlParameter imageParameter = sqlCommand.Parameters.Add("@Обкладинка", SqlDbType.Binary);
                        imageParameter.Value = byteArray;
                        imageParameter.Size = byteArray.Length;
                        sqlCommand.Parameters.AddWithValue("@Оцінка", Convert.ToString(оцінкаUpDown.Value));
                        sqlCommand.Parameters.AddWithValue("@Посилання", sFileName);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Книгу додано до бібліотеки!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // sqlCon.Close();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Помилка");
                        //MessageBox.Show("Помилка при підключенні чи роботі з базою даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (counter_pics == 0 && counter_links >= 1)
            {

                try
                {
                    string query = "UPDATE [Наявні_книги] SET Назва = @Назва,Автор = @Автор,Рік_видання = @Рік_видання,Тип = @Тип,Жанр = @Жанр,Опис = @Опис,Ціна = @Ціна,Коментар = @Коментар,Оцінка = @Оцінка,Посилання = @Посилання WHERE Id ='" + ID + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                    //sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
                    sqlCommand.Parameters.AddWithValue("@Жанр", жанрСomboBox.Text.ToString().TrimEnd());
                    sqlCommand.Parameters.AddWithValue("@Опис", описTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Ціна", Convert.ToDouble(цінаUpDown.Value));
                    sqlCommand.Parameters.AddWithValue("@Коментар", коментарTextBox.Text);
                    //SqlParameter imageParameter = sqlCommand.Parameters.Add("@Обкладинка", SqlDbType.Binary);
                    // imageParameter.Value = byteArray;
                    //imageParameter.Size = byteArray.Length;
                    sqlCommand.Parameters.AddWithValue("@Оцінка", Convert.ToString(оцінкаUpDown.Value));
                    sqlCommand.Parameters.AddWithValue("@Посилання", sFileName);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Книгу додано до бібліотеки!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // sqlCon.Close();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Помилка");
                    //MessageBox.Show("Помилка при підключенні чи роботі з базою даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void Add_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            //sqlCon.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Не обрано";
            if (checkBox1.Checked == true)
            {
                SelectPicBtn.Enabled = true;
            }
            else
            {
                SelectPicBtn.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Pdf files (*.pdf)|*.pdf*";
            choofdlog.FilterIndex = 1;
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                counter_links++;
                sFileName = choofdlog.FileName;
                label3.Text = Path.GetFileName(choofdlog.FileName);  //с расширением
            }
        }

        private void типcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (типcomboBox.SelectedIndex == 0)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void рік_виданняTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

    }
}

