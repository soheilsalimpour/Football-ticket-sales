using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("بخش خرید بلیت");
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("نام کاربر : Admin");
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            MessageBox.Show("هنوز بلیتی خریداری نشده است");
        }
    }
}
