using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_library
{
    public partial class Diagram_Form : Form
    {
        SqlConnection sqlCon;
        public Diagram_Form(SqlConnection SQL)
        {
            sqlCon = SQL;
            InitializeComponent();
            try
            {
                string query = "SELECT COUNT(Оцінка) FROM Наявні_книги WHERE Оцінка = 0";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                int zero = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT COUNT(Оцінка) FROM Наявні_книги WHERE Оцінка = 1";
                sqlCommand = new SqlCommand(query, sqlCon);
                int one = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT COUNT(Оцінка) FROM Наявні_книги WHERE Оцінка = 2";
                sqlCommand = new SqlCommand(query, sqlCon);
                int two = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT COUNT(Оцінка) FROM Наявні_книги WHERE Оцінка = 3";
                sqlCommand = new SqlCommand(query, sqlCon);
                int three = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT COUNT(Оцінка) FROM Наявні_книги WHERE Оцінка = 4";
                sqlCommand = new SqlCommand(query, sqlCon);
                int four = Convert.ToInt32(sqlCommand.ExecuteScalar());


                query = "SELECT COUNT(Оцінка) FROM Наявні_книги WHERE Оцінка = 5";
                sqlCommand = new SqlCommand(query, sqlCon);
                int five = Convert.ToInt32(sqlCommand.ExecuteScalar());

                chart1.Series["Marks"].Points.AddXY("0", zero);
                chart1.Series["Marks"].Points[0].Color = Color.Aqua;
                //chart1.Series["Marks"].Points[0].Label = zero.ToString();

                chart1.Series["Marks"].Points.AddXY("1", one);
                chart1.Series["Marks"].Points[1].Color = Color.LawnGreen;
                //chart1.Series["Marks"].Points[1].Label = one.ToString();

                chart1.Series["Marks"].Points.AddXY("2", two);
                chart1.Series["Marks"].Points[2].Color = Color.Turquoise;
                //chart1.Series["Marks"].Points[2].Label = two.ToString();

                chart1.Series["Marks"].Points.AddXY("3", three);
                chart1.Series["Marks"].Points[3].Color = Color.Orange;
               // chart1.Series["Marks"].Points[3].Label = three.ToString();

                chart1.Series["Marks"].Points.AddXY("4", four);
                chart1.Series["Marks"].Points[4].Color = Color.Violet;
               // chart1.Series["Marks"].Points[4].Label = four.ToString();

                chart1.Series["Marks"].Points.AddXY("5", five);
                chart1.Series["Marks"].Points[5].Color = Color.Coral;
                //  chart1.Series["Marks"].Points[5].Label = five.ToString();

                /*
                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Бойовики%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int boevik = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Бойовики", boevik);
                chart2.Series["Books"].Points[0].Color = Color.Coral;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Детективи%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int detective = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Детективи", detective);
                chart2.Series["Books"].Points[1].Color = Color.BlanchedAlmond;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Дитячі%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int child = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Дитячі", child);
                chart2.Series["Books"].Points[2].Color = Color.Olive;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Документальні%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int doc = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Документальні", doc);
                chart2.Series["Books"].Points[3].Color = Color.GreenYellow;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Гумор%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int humor = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Гумор", humor);
                chart2.Series["Books"].Points[4].Color = Color.Moccasin;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Любовні романи%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int love = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Любовні романи", love);
                chart2.Series["Books"].Points[5].Color = Color.Lavender;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Науково-освітні%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int science = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Науково-освітні", science);
                chart2.Series["Books"].Points[6].Color = Color.Khaki;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Поезія%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int poetry = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Поезія", poetry);
                chart2.Series["Books"].Points[7].Color = Color.Honeydew;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Пригоди%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int adventure = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Пригоди", adventure);
                chart2.Series["Books"].Points[8].Color = Color.Wheat;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Проза%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int proze = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Проза", proze);
                chart2.Series["Books"].Points[9].Color = Color.CadetBlue;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Релігія%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int religion = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Релігія", religion);
                chart2.Series["Books"].Points[10].Color = Color.NavajoWhite;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Фантастика%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int fantasy = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Фантастика", fantasy);
                chart2.Series["Books"].Points[11].Color = Color.Plum;


                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Жанр LIKE N'Економіка%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int eco = Convert.ToInt32(sqlCommand.ExecuteScalar());
                chart2.Series["Books"].Points.AddXY("Економіка", eco);
                chart2.Series["Books"].Points[12].Color = Color.SaddleBrown;
                */
                




                query = "SELECT COUNT(Тип) FROM Наявні_книги WHERE Тип LIKE N'Паперова%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int paper = Convert.ToInt32(sqlCommand.ExecuteScalar());

                query = "SELECT COUNT(Жанр) FROM Наявні_книги WHERE Тип LIKE N'Електронна%'";
                sqlCommand = new SqlCommand(query, sqlCon);
                int electronic = Convert.ToInt32(sqlCommand.ExecuteScalar());

                chart3.Series["Type"].Points.AddXY("Паперові", paper);
                chart3.Series["Type"].Points[0].Color = Color.OrangeRed;
       
                chart3.Series["Type"].Points.AddXY("Електронні", electronic);
                chart3.Series["Type"].Points[1].Color = Color.Aqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
