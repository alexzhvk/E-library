using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace E_library
{
    public partial class View_Form : Form
    {
        public View_Form(string file)
        {
            InitializeComponent();
            try
            {
                axAcroPDF1.src = file;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
