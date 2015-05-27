using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCreateBackupPlan.Express;
using AutoCreateBackupPlan.Standart;


namespace AutoCreateBackupPlan
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btExpress_Click(object sender, EventArgs e)
        {
            frmExpress frm = new frmExpress();
            frm.ShowDialog();
        }

        private void btStandart_Click(object sender, EventArgs e)
        {
            frmStandart frm = new frmStandart();
            frm.ShowDialog();
        }
    }
}
