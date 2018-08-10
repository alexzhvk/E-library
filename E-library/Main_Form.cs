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
using System.IO;

namespace E_library
{
    public partial class Main_Form : Form
    {
        string login, password;
        int access;
        SqlConnection sqlCon;
        public Main_Form(SqlConnection SQL, string Login, string Password, int Access)
        {
            InitializeComponent();
            sqlCon = SQL;
            login = Login;
            password = Password;
            access = Access;
            exitBtn.ReadOnly = true;
            commentTxB.ReadOnly = true;
            exitBtn.BackColor = Color.White;
            commentTxB.BackColor = Color.White;
            
            if (Access == 3)
            {
                Change_Pass_Btn.Enabled = false;
                button2.Enabled = false;
                addBtn.Enabled = false;
                Clear_Btn.Enabled = false;
                deleteBtn.Enabled = false;
                editBtn.Enabled = false;
            }
            if (Access == 2)
            {
                Change_Pass_Btn.Enabled = true;
                button2.Enabled = false;
                addBtn.Enabled = false;
                Clear_Btn.Enabled = false;
                deleteBtn.Enabled = false;
                editBtn.Enabled = false;
            }
            if (Access == 1 || Access == 0)
            {
                Change_Pass_Btn.Enabled = true;
                button2.Enabled = true;
                addBtn.Enabled = true;
                Clear_Btn.Enabled = true;
               deleteBtn.Enabled = true;
              editBtn.Enabled = true;
            }

            string query = "SELECT COUNT(Id) FROM Наявні_книги";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            int counter = Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (counter > 0)
            {
                обкладинкаPictureBox.Visible = true;
                Header_Lbl.Visible = true;
                Author_Lbl.Visible = true;
                viewBtn.Visible = true;
                exitBtn.Visible = true;
                label18.Visible = true;
                commentTxB.Visible = true;
                trackBar1.Enabled = true;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox1.Enabled = true;
                if (Access == 1 || Access == 0)
                {
                    deleteBtn.Enabled = true;
                    editBtn.Enabled = true;
                }
                diagramBtn.Enabled = true;
                query = "SELECT MIN(Id) FROM Наявні_книги";
                sqlCommand = new SqlCommand(query, sqlCon);
                int ID = Convert.ToInt32(sqlCommand.ExecuteScalar());

                try
                {
                    //sqlCon.Open();
                    query = "SELECT MIN(Id) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar1.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar1.Value = trackBar1.Minimum;
                    textBox1.Text = "1";

                    query = "SELECT MAX(Id) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar1.Maximum = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    trackBar1.TickFrequency = 1;
                    trackBar1.LargeChange = 3;
                    trackBar1.SmallChange = 2;

                    query = "SELECT MIN(Рік_видання) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar2.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar3.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar2.Value = trackBar2.Minimum;

                    textBox2.Text = trackBar2.Value.ToString();

                    trackBar2.TickFrequency = 1;
                    trackBar2.LargeChange = 3;
                    trackBar2.SmallChange = 2;
                    trackBar3.TickFrequency = 1;
                    trackBar3.LargeChange = 3;
                    trackBar3.SmallChange = 2;

                    query = "SELECT MAX(Рік_видання) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar2.Maximum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar3.Maximum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar3.Value = trackBar3.Maximum;
                    textBox3.Text = trackBar3.Value.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //sqlCon.Close();
                }



                //int col = dataGridView1.CurrentCell.ColumnIndex;
                try
                {
                    //   sqlCon.Open();
                    query = "SELECT Назва FROM Наявні_книги WHERE Id = '" + ID + "'";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    Header_Lbl.Text = sqlCommand.ExecuteScalar().ToString();

                    query = "SELECT Автор FROM Наявні_книги WHERE Id = '" + ID + "'";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    Author_Lbl.Text = sqlCommand.ExecuteScalar().ToString();

                    query = "SELECT Опис FROM Наявні_книги WHERE Id = '" + ID + "'";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    exitBtn.Text = sqlCommand.ExecuteScalar().ToString();

                    query = "SELECT Коментар FROM Наявні_книги WHERE Id = '" + ID + "'";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    commentTxB.Text = sqlCommand.ExecuteScalar().ToString();

                    try
                    {
                        query = "SELECT Обкладинка FROM Наявні_книги WHERE Id = " + ID;
                        sqlCommand = new SqlCommand(query, sqlCon);
                        MemoryStream stream = new MemoryStream((byte[])sqlCommand.ExecuteScalar());
                        this.обкладинкаPictureBox.Image = Image.FromStream(stream);
                    }
                    catch
                    {
                        обкладинкаPictureBox.Image = Properties.Resources.no_image;
                    }

                    query = "SELECT Посилання FROM Наявні_книги WHERE Id = '" + ID + "'";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    string link = sqlCommand.ExecuteScalar().ToString().Trim();
                    if (link.Length == 0)
                    {
                        viewBtn.Visible = false;
                        viewBtn.Enabled = false;
                    }
                    else
                    {
                        viewBtn.Visible = true;
                        viewBtn.Enabled = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                обкладинкаPictureBox.Visible = false;
                Header_Lbl.Visible = false;
                Author_Lbl.Visible = false;
                viewBtn.Visible = false;
                exitBtn.Visible = false;
                label18.Visible = false;
                commentTxB.Visible = false;
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
                deleteBtn.Enabled = false;
                editBtn.Enabled = false;
                diagramBtn.Enabled = false;
            }
            Update_Current_Books();
        }

        void Update_Current_Books()
        {
            string query = "SELECT COUNT(Id) FROM Наявні_книги";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            int counter = Convert.ToInt32(sqlCommand.ExecuteScalar());
            try
            {
                //sqlCon.Open();
                query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги";
                sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                trackBar1.Value = trackBar1.Minimum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (counter > 0)
            {
                обкладинкаPictureBox.Visible = true;
                Header_Lbl.Visible = true;
                Author_Lbl.Visible = true;
                viewBtn.Visible = true;
                exitBtn.Visible = true;
                label18.Visible = true;
                commentTxB.Visible = true;
                trackBar1.Enabled = true;
                trackBar2.Enabled = true;
                trackBar3.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox1.Enabled = true;
                if (access == 1 || access == 0)
                {
                    deleteBtn.Enabled = true;
                   editBtn.Enabled = true;
                }
                diagramBtn.Enabled = true;
                

                try
                {
                    //sqlCon.Open();
                    query = "SELECT MIN(Id) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar1.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar1.Value = trackBar1.Minimum;
                    textBox1.Text = "1";

                    query = "SELECT MAX(Id) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar1.Maximum = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    trackBar1.TickFrequency = 1;
                    trackBar1.LargeChange = 3;
                    trackBar1.SmallChange = 2;

                    query = "SELECT MIN(Рік_видання) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar2.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar3.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar2.TickFrequency = 1;
                    trackBar2.LargeChange = 3;
                    trackBar2.SmallChange = 2;
                    trackBar3.TickFrequency = 1;
                    trackBar3.LargeChange = 3;
                    trackBar3.SmallChange = 2;

                    query = "SELECT MAX(Рік_видання) FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    trackBar2.Maximum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    trackBar3.Maximum = Convert.ToInt32(sqlCommand.ExecuteScalar());


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                обкладинкаPictureBox.Visible = false;
                Header_Lbl.Visible = false;
                Author_Lbl.Visible = false;
                viewBtn.Visible = false;
                exitBtn.Visible = false;
                label18.Visible = false;
                commentTxB.Visible = false;
                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox1.Enabled = false;
                deleteBtn.Enabled = false;
                editBtn.Enabled = false;
                diagramBtn.Enabled = false;
            }
        }

        private void проПрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void наявні_книгиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.наявні_книгиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._E_LibraryDataSet);

        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_E_LibraryDataSet.Наявні_книги". При необходимости она может быть перемещена или удалена.
            this.наявні_книгиTableAdapter.Fill(this._E_LibraryDataSet.Наявні_книги);

        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Form af = new Add_Form(sqlCon);
            af.ShowDialog();
            Update_Current_Books();
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //sqlCon.Close();
        }

        private void Бойовики_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Бойовики%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Дитячі%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        void SetBars()
        {
            string query = "SELECT MIN(Рік_видання) FROM Наявні_книги";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            trackBar2.Value = Convert.ToInt32(sqlCommand.ExecuteScalar());

            query = "SELECT MAX(Рік_видання) FROM Наявні_книги";
            sqlCommand = new SqlCommand(query, sqlCon);
            trackBar3.Value = Convert.ToInt32(sqlCommand.ExecuteScalar());
        }

        private void AllBooks_Btn_Click(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(Id) FROM Наявні_книги";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            int counter = Convert.ToInt32(sqlCommand.ExecuteScalar());
            if (counter > 0)
            {
                try
                {
                    //sqlCon.Open();
                    query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги";
                    sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.ExecuteNonQuery();
                    DataTable DT = new DataTable();
                    SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                    SqlDA.Fill(DT);
                    наявні_книгиDataGridView.DataSource = DT;

                    SetBars();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //sqlCon.Close();
                }
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Детективи%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Документальні%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        private void linkLabel13_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Гумор%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        private void linkLabel5_Click(object sender, EventArgs e)
        {
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Любовні романи%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        private void linkLabel6_Click(object sender, EventArgs e)
        {
            try
            {
                // sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Науково-освітні%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // sqlCon.Close();
            }
        }

        private void linkLabel7_Click(object sender, EventArgs e)
        {
            try
            {
                // sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Поезія%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // sqlCon.Close();
            }
        }

        private void linkLabel8_Click(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Пригоди%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //  sqlCon.Close();
            }
        }

        private void linkLabel9_Click(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Проза%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //  sqlCon.Close();
            }
        }

        private void linkLabel10_Click(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Релігія%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // sqlCon.Close();
            }
        }

        private void linkLabel11_Click(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Фантастика%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // sqlCon.Close();
            }
        }

        private void linkLabel12_Click(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Жанр LIKE N'Економіка%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // sqlCon.Close();
            }
        }

        private void linkLabel14_Click(object sender, EventArgs e)
        {
            try
            {
                // sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Тип LIKE N'Паперова%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //   sqlCon.Close();
            }
        }

        private void linkLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                //   sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Тип LIKE N'Електронна%'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
                SetBars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //   sqlCon.Close();
            }
        }

        private void наявні_книгиDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = наявні_книгиDataGridView.CurrentCell.RowIndex;
            int col = наявні_книгиDataGridView.CurrentCell.ColumnIndex;
            string a = наявні_книгиDataGridView[0, row].Value.ToString();
            //int col = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                //   sqlCon.Open();
                string query = "SELECT Назва FROM Наявні_книги WHERE Id = '" + a + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                Header_Lbl.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Автор FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Author_Lbl.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Опис FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                exitBtn.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Коментар FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                commentTxB.Text = sqlCommand.ExecuteScalar().ToString();

                trackBar1.Value = Convert.ToInt32(a);
                textBox1.Text = a;

                query = "SELECT Посилання FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                string link = sqlCommand.ExecuteScalar().ToString().Trim();
                if (link.Length == 0)
                {
                    viewBtn.Visible = false;
                    viewBtn.Enabled = false;
                }
                else
                {
                    viewBtn.Visible = true;
                    viewBtn.Enabled = true;
                }
                try
                {
                    query = "SELECT Обкладинка FROM Наявні_книги WHERE Id = " + a;
                    sqlCommand = new SqlCommand(query, sqlCon);
                    MemoryStream stream = new MemoryStream((byte[])sqlCommand.ExecuteScalar());
                    this.обкладинкаPictureBox.Image = Image.FromStream(stream);
                }
                catch
                {
                    обкладинкаPictureBox.Image = Properties.Resources.no_image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //   sqlCon.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //sqlCon.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT MIN(Id) FROM Наявні_книги";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                int MIN = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT MAX(Id) FROM Наявні_книги";
                sqlCommand = new SqlCommand(query, sqlCon);
                int MAX = Convert.ToInt32(sqlCommand.ExecuteScalar());


                if (Convert.ToInt32(textBox1.Text) > MAX)
                    textBox1.Text = MAX.ToString();
                if (Convert.ToInt32(textBox1.Text) < MIN)
                    textBox1.Text = MIN.ToString();
                //trackBar2.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                trackBar1.Value = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //   sqlCon.Close();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "DELETE FROM Наявні_книги WHERE Id = '" + trackBar1.Value.ToString() + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                Update_Current_Books();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            //sqlCon.Close();
            Add_Form af = new Add_Form(sqlCon);
            af.ShowDialog();
            Update_Current_Books();

        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно бажаєте очистити таблицю?", "Очищення", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    //  sqlCon.Open();
                    string query = "TRUNCATE TABLE Наявні_книги";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.ExecuteNonQuery();
                    Update_Current_Books();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = trackBar3.Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT MIN(Рік_видання) FROM Наявні_книги";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                int MIN = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT MAX(Рік_видання) FROM Наявні_книги";
                sqlCommand = new SqlCommand(query, sqlCon);
                int MAX = Convert.ToInt32(sqlCommand.ExecuteScalar());


                //trackBar2.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //  sqlCon.Open();
                string query = "SELECT MIN(Рік_видання) FROM Наявні_книги";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                int MIN = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT MAX(Рік_видання) FROM Наявні_книги";
                sqlCommand = new SqlCommand(query, sqlCon);
                int MAX = Convert.ToInt32(sqlCommand.ExecuteScalar());


               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Бойовики_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private void обкладинкаPictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            обкладинкаPictureBox.Image = Properties.Resources.no_image;
        }

        private void diagramBtn_Click(object sender, EventArgs e)
        {
            Diagram_Form df = new Diagram_Form(sqlCon);
            df.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            int row = наявні_книгиDataGridView.CurrentCell.RowIndex;
            int col = наявні_книгиDataGridView.CurrentCell.ColumnIndex;
            string a = наявні_книгиDataGridView[0, row].Value.ToString();

            string Name, Author, Type, Genre, About, Comment, Picture, Link;
            int Year, Mark;
            double Price;
            //int col = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                //   sqlCon.Open();
                string query = "SELECT Назва FROM Наявні_книги WHERE Id = '" + a + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                Name = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Автор FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Author = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Рік_видання FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Year = Convert.ToInt32(sqlCommand.ExecuteScalar());

                query = "SELECT Тип FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Type = sqlCommand.ExecuteScalar().ToString().Trim();

                query = "SELECT Жанр FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Genre = sqlCommand.ExecuteScalar().ToString().TrimEnd();

                query = "SELECT Опис FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                About = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Ціна FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Price = Convert.ToDouble(sqlCommand.ExecuteScalar());

                query = "SELECT Коментар FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Comment = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Оцінка FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Mark = Convert.ToInt32(sqlCommand.ExecuteScalar());

                query = "SELECT Посилання FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Link = sqlCommand.ExecuteScalar().ToString().Trim();

                Edit_Form ef = new Edit_Form(sqlCon, a, Name, Author, Year, Type, Genre, About, Price, Comment, Mark, Link);
                ef.ShowDialog();
                Update_Current_Books();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void наявні_книгиDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int row = наявні_книгиDataGridView.CurrentCell.RowIndex;
            int col = наявні_книгиDataGridView.CurrentCell.ColumnIndex;
            string a = наявні_книгиDataGridView[0, row].Value.ToString();
            //int col = dataGridView1.CurrentCell.ColumnIndex;
            try
            {
                //   sqlCon.Open();
                string query = "SELECT Назва FROM Наявні_книги WHERE Id = '" + a + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                Header_Lbl.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Автор FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                Author_Lbl.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Опис FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                exitBtn.Text = sqlCommand.ExecuteScalar().ToString();

                query = "SELECT Коментар FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                commentTxB.Text = sqlCommand.ExecuteScalar().ToString();

                trackBar1.Value = Convert.ToInt32(a);
                textBox1.Text = a;

                query = "SELECT Посилання FROM Наявні_книги WHERE Id = '" + a + "'";
                sqlCommand = new SqlCommand(query, sqlCon);
                string link = sqlCommand.ExecuteScalar().ToString().Trim();
                if (link.Length == 0)
                {
                    viewBtn.Visible = false;
                    viewBtn.Enabled = false;
                }
                else
                {
                    viewBtn.Visible = true;
                    viewBtn.Enabled = true;
                }
                try
                {
                    query = "SELECT Обкладинка FROM Наявні_книги WHERE Id = " + a;
                    sqlCommand = new SqlCommand(query, sqlCon);
                    MemoryStream stream = new MemoryStream((byte[])sqlCommand.ExecuteScalar());
                    this.обкладинкаPictureBox.Image = Image.FromStream(stream);
                }
                catch
                {
                    обкладинкаPictureBox.Image = Properties.Resources.no_image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //   sqlCon.Close();
            }


        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            int row = наявні_книгиDataGridView.CurrentCell.RowIndex;
            string a = наявні_книгиDataGridView[0, row].Value.ToString();
            string query = "SELECT Посилання FROM Наявні_книги WHERE Id = '" + a + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            string link = sqlCommand.ExecuteScalar().ToString().Trim();
            View_Form vf = new View_Form(link);
            vf.ShowDialog();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About_Form af = new About_Form();
            af.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings_Form sf = new Settings_Form(sqlCon, access);
            sf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT MIN(Рік_видання) FROM Наявні_книги";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                int MIN = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT MAX(Рік_видання) FROM Наявні_книги";
                sqlCommand = new SqlCommand(query, sqlCon);
                int MAX = Convert.ToInt32(sqlCommand.ExecuteScalar());
                /*

                if (Convert.ToInt32(textBox2.Text) > MAX)
                    textBox2.Text = MAX.ToString();
                if (Convert.ToInt32(textBox2.Text) < MIN)
                    textBox2.Text = MIN.ToString();
                if (Convert.ToInt32(textBox3.Text) > MAX)
                    textBox3.Text = MAX.ToString();
                if (Convert.ToInt32(textBox3.Text) < MIN)
                    textBox3.Text = MIN.ToString();
                */
                //trackBar2.Minimum = Convert.ToInt32(sqlCommand.ExecuteScalar());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                //sqlCon.Open();
                string query = "SELECT Id,Назва,Автор,Рік_видання,Тип,Додано,Жанр,Опис,Ціна,Коментар,Оцінка FROM Наявні_книги WHERE Рік_видання BETWEEN " + Convert.ToInt32(textBox2.Text) + " AND " + Convert.ToInt32(textBox3.Text) + ";";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.ExecuteNonQuery();
                DataTable DT = new DataTable();
                SqlDataAdapter SqlDA = new SqlDataAdapter(sqlCommand);
                SqlDA.Fill(DT);
                наявні_книгиDataGridView.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Change_Pass_Btn_Click(object sender, EventArgs e)
        {
            Change_Pass_Form cpf = new Change_Pass_Form(sqlCon, login, password);
            cpf.ShowDialog();
        }
    }
}
