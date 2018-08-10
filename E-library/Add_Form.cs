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
    public partial class Add_Form : Form
    {
        SqlConnection sqlCon;
        string sFileName;
        string iFileName;
        byte[] byteArray = null;
        public Add_Form(SqlConnection SQL)
        {
            InitializeComponent();
            sqlCon = SQL;
            типcomboBox.SelectedIndex = 0;
            жанрСomboBox.SelectedIndex = 0;
            SelectPicBtn.Enabled = false;
            button1.Enabled = false;
            label2.Text = "Не обрано";
            label3.Text = "Не обрано";

        }

        private void SelectPicBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            //choofdlog.Filter = "Pdf files (*.pdf)|*.pdf*";
            // choofdlog.FilterIndex = 1;
            choofdlog.Filter = "Images|*.png;*.bmp;*.jpeg;*.jpg";
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
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
            if(назваTextBox.Text.Trim().Length == 0 || авторTextBox.Text.Trim().Length == 0 || рік_виданняTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Заповніть обов'язкові поля(позначені зірочкою)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkBox1.Checked == true && типcomboBox.SelectedIndex == 0)
                {
                    if (label2.Text == "Не обрано")
                    {
                        MessageBox.Show("Оберіть обкладинку або приберіть параметр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            // sqlCon.Open();
                            /*
                            using (Bitmap image = new Bitmap(sFileName))
                            {
                                MemoryStream stream = new MemoryStream();
                                image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                                byteArray = stream.ToArray();
                            }
                            */

                            /*
                            string query = @"INSERT INTO [Наявні_книги] "
                                        + "([Назва], [Автор], [Рік_видання], [Тип], [Додано], [Жанр], [Опис], [Ціна], [Коментар], [Оцінка])" +
                                        "VALUES" +
                                        "('" + назваTextBox.Text + "', '"
                                        + авторTextBox.Text + "', '"
                                        + рік_виданняTextBox.Text + "', '"
                                        + типTextBox.Text + "', '"
                                        + DateTime.Today.ToString("yyyy-MM-dd") + "', '"
                                        + жанрСomboBox.Text + "', '"
                                        + описTextBox.Text + "', '"
                                        + Convert.ToDouble(цінаUpDown.Value) + "', '"
                                        + коментарTextBox.Text + "', '"
                                        + оцінкаTextBox.Text + "')";
                                        */

                            string query = "INSERT INTO [Наявні_книги] (Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Обкладинка,Оцінка) values (@Назва,@Автор,@Рік_видання,@Тип,@Додано,@Жанр,@Опис,@Ціна,@Коментар,@Обкладинка,@Оцінка)";
                            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                            sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
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
                else if (checkBox1.Checked == false && типcomboBox.SelectedIndex == 0)
                {
                    try
                    {
                        string query = "INSERT INTO [Наявні_книги] (Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка) values (@Назва,@Автор,@Рік_видання,@Тип,@Додано,@Жанр,@Опис,@Ціна,@Коментар,@Оцінка)";
                        SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                        sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
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
                else if (checkBox1.Checked == true && типcomboBox.SelectedIndex == 1)
                {
                    if (label2.Text == "Не обрано")
                    {
                        MessageBox.Show("Оберіть обкладинку або приберіть параметр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (label3.Text == "Не обрано")
                    {
                        MessageBox.Show("Оберіть посилання або приберіть параметр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            string query = "INSERT INTO [Наявні_книги] (Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Обкладинка,Оцінка,Посилання) values (@Назва,@Автор,@Рік_видання,@Тип,@Додано,@Жанр,@Опис,@Ціна,@Коментар,@Обкладинка,@Оцінка,@Посилання)";
                            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                            sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
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
                else if (checkBox1.Checked == false && типcomboBox.SelectedIndex == 1)
                {
                    if (label3.Text == "Не обрано")
                    {
                        MessageBox.Show("Оберіть посилання або приберіть параметр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            string query = "INSERT INTO [Наявні_книги] (Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка,Посилання) values (@Назва,@Автор,@Рік_видання,@Тип,@Додано,@Жанр,@Опис,@Ціна,@Коментар,@Оцінка,@Посилання)";
                            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                            sqlCommand.Parameters.AddWithValue("@Назва", назваTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Автор", авторTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Рік_видання", рік_виданняTextBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Тип", типcomboBox.Text);
                            sqlCommand.Parameters.AddWithValue("@Додано", DateTime.Today.ToString("yyyy-MM-dd"));
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
            if((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }
            e.Handled = true;
        }

        //***************************************
        //*показ последней вставленной картинки *
        //***************************************



    }
}

