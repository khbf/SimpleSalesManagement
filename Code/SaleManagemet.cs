using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_SaleManagement
{
    public partial class SaleManagemet : Form
    {
       
        public SaleManagemet()
        {
            InitializeComponent();
        }

       // private void SaleManagemet_FormClosed(object sender, FormClosedEventArgs e)
      //  {
      //      Application.Exit();
      //  }

        private void salesOrderHeaderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalesOrderHeader salesorderheader = new SalesOrderHeader();
            salesorderheader.StartPosition = FormStartPosition.CenterScreen;
            salesorderheader.Show();
        }

        private void salesOrderDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesOrderDetail salesorderdetail = new SalesOrderDetail();
            salesorderdetail.StartPosition = FormStartPosition.CenterScreen;
            salesorderdetail.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.StartPosition = FormStartPosition.CenterScreen;
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.StartPosition = FormStartPosition.CenterScreen;
            customer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesOrderHeader salesorderheader = new SalesOrderHeader();
            salesorderheader.StartPosition = FormStartPosition.CenterScreen;
            salesorderheader.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalesOrderDetail salesorderdetail = new SalesOrderDetail();
            salesorderdetail.StartPosition = FormStartPosition.CenterScreen;
            salesorderdetail.Show();
        }

      
    }
}
