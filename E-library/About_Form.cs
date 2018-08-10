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
    public partial class About_Form : Form
    {
        public About_Form()
        {
            InitializeComponent();
            MaximumSize = MinimumSize;
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
