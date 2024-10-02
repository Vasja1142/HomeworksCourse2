using LR_3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class SetCalculator : Form
    {
        public SetCalculator()
        {
            InitializeComponent();
        }

        private void enterNum_Click(object sender, EventArgs e)
        {
            String num = NumField.Text;
            NumField.Clear();
        }
    }
}
