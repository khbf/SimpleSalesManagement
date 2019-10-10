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
using System.Configuration;

namespace QL_SaleManagement
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        public static SqlConnection con;
        public static string conString;

        private void Customer_Load(object sender, EventArgs e)
        {
            conString = @"Data Source=.; Initial Catalog=iSaleManagement; Integrated Security=True";
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
            con.Close();
        }
        public void HienThi()                //hiển thị dữ liệu danh sách bảng n_Customer
        {
            string sqlselect = "SELECT * FROM n_Customer";
            SqlCommand cmd = new SqlCommand(sqlselect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsCustomer.DataSource = dt;
        }

        //Thêm Customer mới
        private void button_add_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string sqlInsert = "INSERT INTO n_Customer VALUES (@CustomerID, @PersonID, @StoreID, @TerritoryID, @AccountNumber, @rowguid, @ModifiedDate)";
                SqlCommand cmd = new SqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("CustomerID", textBox.Text);
                cmd.Parameters.AddWithValue("PersonID", textBox1.Text);
                cmd.Parameters.AddWithValue("StoreID", textBox2.Text);
                cmd.Parameters.AddWithValue("TerritoryID", textBox3.Text);
                cmd.Parameters.AddWithValue("AccountNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("rowguid",Guid.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.Parse(dateTimePicker.Text));
                cmd.ExecuteNonQuery();
                HienThi();
                MessageBox.Show("Thêm thành công!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                con.Close();
            }
        }

        //Cập nhật dữ liệu trong bảng Customer
        private void button_update_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string sqlInsert = "UPDATE n_Customer SET PersonID = @PersonID, StoreID = @StoreID, TerritoryID = @TerritoryID, AccountNumber = @AccountNumber, rowguid = @rowguid, ModifiedDate = @ModifiedDate WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("CustomerID", textBox.Text);
                cmd.Parameters.AddWithValue("PersonID", textBox1.Text);
                cmd.Parameters.AddWithValue("StoreID", textBox2.Text);
                cmd.Parameters.AddWithValue("TerritoryID", textBox3.Text);
                cmd.Parameters.AddWithValue("AccountNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("rowguid", textBox6.Text);
                cmd.Parameters.AddWithValue("ModifiedDate", DateTime.Parse(dateTimePicker.Text));
                cmd.ExecuteNonQuery();
                HienThi();
                MessageBox.Show("Cập nhật thành công!");
                con.Close();
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công!");
                con.Close();
            }
        }


    }
}
