using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace QL_SaleManagement
{
    public partial class SalesOrderHeader : Form
    {
        public SalesOrderHeader()
        {
            InitializeComponent();
        }

        public static SqlConnection con;
        public static string conString;

        private void SalesOrderHeader_Load(object sender, EventArgs e)
        {
            conString = @"Data Source=.; Initial Catalog=iSaleManagement; Integrated Security=True";
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
            con.Close();
        }

        //hiển thị dữ liệu danh sách bảng n_SalesOrderHeader
        public void HienThi()             
        {
            string sqlselect = "SELECT * FROM n_SalesOrderHeader";
            SqlCommand cmd = new SqlCommand(sqlselect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsOrderHeader.DataSource = dt;
        }

       // Thêm Sales Order Header mới
        private void button_add_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("InsertSalesOrderHeader", con);
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                ad.SelectCommand.Parameters.Add("@salesOrderID", SqlDbType.Int).Value = int.Parse(textBox_PersonID.Text);
                ad.SelectCommand.Parameters.Add("@revisionNumber", SqlDbType.TinyInt).Value = byte.Parse(textBox1.Text);
                ad.SelectCommand.Parameters.Add("@orderDate", SqlDbType.DateTime).Value = DateTime.Parse(dateTimePicker1.Text);
                ad.SelectCommand.Parameters.Add("@dueDate", SqlDbType.DateTime).Value = DateTime.Parse(dateTimePicker2.Text);
                ad.SelectCommand.Parameters.Add("@shipDate", SqlDbType.DateTime).Value = DateTime.Parse(dateTimePicker3.Text);
                ad.SelectCommand.Parameters.Add("@status", SqlDbType.TinyInt).Value = byte.Parse(textBox5.Text);
                ad.SelectCommand.Parameters.Add("@onlineOrderFlag", SqlDbType.Bit).Value = bool.Parse(textBox6.Text);
                ad.SelectCommand.Parameters.Add("@salesOrderNumber", SqlDbType.VarChar, (50)).Value = textBox14.Text;
                ad.SelectCommand.Parameters.Add("@purchaseOrderNumber", SqlDbType.NVarChar, (25)).Value = textBox7.Text;
                ad.SelectCommand.Parameters.Add("@accountNumber", SqlDbType.NVarChar, (15)).Value = textBox8.Text;
                ad.SelectCommand.Parameters.Add("@customerID", SqlDbType.Int).Value = int.Parse(textBox9.Text);
                ad.SelectCommand.Parameters.Add("@salesPersonID", SqlDbType.Int).Value = int.Parse(textBox10.Text);
                ad.SelectCommand.Parameters.Add("@territoryID", SqlDbType.Int).Value = int.Parse(textBox11.Text);
                ad.SelectCommand.Parameters.Add("@billToAddressID", SqlDbType.Int).Value = int.Parse(textBox12.Text);
                ad.SelectCommand.Parameters.Add("@shipToAddressID", SqlDbType.Int).Value = int.Parse(textBox13.Text);
                ad.SelectCommand.Parameters.Add("@shipMethodID", SqlDbType.Int).Value = int.Parse(textBox15.Text);
                ad.SelectCommand.Parameters.Add("@creditCardID", SqlDbType.Int).Value = int.Parse(textBox16.Text);
                ad.SelectCommand.Parameters.Add("@creditCardApprovalCode", SqlDbType.VarChar, (15)).Value = textBox17.Text;
                ad.SelectCommand.Parameters.Add("@currencyRateID", SqlDbType.Int).Value = int.Parse(textBox18.Text);
                ad.SelectCommand.Parameters.Add("@subTotal", SqlDbType.Money).Value = decimal.Parse(textBox19.Text);
                ad.SelectCommand.Parameters.Add("@taxAmt", SqlDbType.Money).Value = decimal.Parse(textBox20.Text);
                ad.SelectCommand.Parameters.Add("@freight", SqlDbType.Money).Value = decimal.Parse(textBox21.Text);
                ad.SelectCommand.Parameters.Add("@totalDue", SqlDbType.Money).Value = decimal.Parse(textBox22.Text);
                ad.SelectCommand.Parameters.Add("@comment", SqlDbType.NVarChar, (128)).Value = textBox23.Text;
                ad.SelectCommand.Parameters.Add("@rowguid", SqlDbType.UniqueIdentifier).Value = Guid.Parse(textBox24.Text);
                ad.SelectCommand.Parameters.Add("@modifiedDate", SqlDbType.DateTime).Value = DateTime.Parse(dateTimePicker4.Text);
                ad.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công!");
                HienThi();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                con.Close();
            }
          
        }

        //Cập nhật chỉnh sửa dữ liệu bảng
        private void button_update_Click(object sender, EventArgs e)
        {
            con.Open();
           try
            {
                string sqlUpdate = "UPDATE n_SalesOrderHeader SET RevisionNumber = @revisionNumber,OrderDate = @orderDate,DueDate = @dueDate,ShipDate = @shipDate,Status = @status,OnlineOrderFlag = @onlineOrderFlag,SalesOrderNumber = @salesOrderNumber,PurchaseOrderNumber = @purchaseOrderNumber,AccountNumber = @accountNumber,CustomerID = @customerID,SalesPersonID = @salesPersonID,TerritoryID = @territoryID,BillToAddressID = @billToAddressID,ShipToAddressID = @shipToAddressID,ShipMethodID = @shipMethodID,CreditCardID = @creditCardID,CreditCardApprovalCode = @creditCardApprovalCode,CurrencyRateID = @currencyRateID,SubTotal = @subTotal,TaxAmt = @taxAmt,Freight = @freight,TotalDue = @totalDue,Comment = @comment,rowguid = @rowguid,ModifiedDate = @modifiedDate WHERE SalesOrderID = @salesOrderID";
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("SalesOrderID", textBox_PersonID.Text);
                cmd.Parameters.AddWithValue("RevisionNumber", textBox1.Text);
                cmd.Parameters.AddWithValue("OrderDate", Convert.ToDateTime(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("DueDate", Convert.ToDateTime(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("ShipDate", Convert.ToDateTime(dateTimePicker3.Text));
                cmd.Parameters.AddWithValue("Status", textBox5.Text);
                cmd.Parameters.AddWithValue("OnlineOrderFlag", textBox6.Text);
                cmd.Parameters.AddWithValue("SalesOrderNumber", textBox14.Text);
                cmd.Parameters.AddWithValue("PurchaseOrderNumber", textBox7.Text);
                cmd.Parameters.AddWithValue("@accountNumber", textBox8.Text);
                cmd.Parameters.AddWithValue("@customerID", textBox9.Text);
                cmd.Parameters.AddWithValue("@salesPersonID", textBox10.Text);
                cmd.Parameters.AddWithValue("@territoryID", textBox11.Text);
                cmd.Parameters.AddWithValue("@billToAddressID", textBox12.Text);
                cmd.Parameters.AddWithValue("@shipToAddressID", textBox13.Text);
                cmd.Parameters.AddWithValue("@shipMethodID", textBox15.Text);
                cmd.Parameters.AddWithValue("@creditCardID", textBox16.Text);
                cmd.Parameters.AddWithValue("@creditCardApprovalCode", textBox17.Text);
                cmd.Parameters.AddWithValue("@currencyRateID", textBox18.Text);
                cmd.Parameters.AddWithValue("@subTotal", textBox19.Text);
                cmd.Parameters.AddWithValue("@taxAmt", textBox20.Text);
                cmd.Parameters.AddWithValue("@freight", textBox21.Text);
                cmd.Parameters.AddWithValue("@totalDue", textBox22.Text);
                cmd.Parameters.AddWithValue("@comment", textBox23.Text);
                cmd.Parameters.AddWithValue("rowguid", new Guid(textBox24.Text));
                cmd.Parameters.AddWithValue("ModifiedDate", Convert.ToDateTime(dateTimePicker4.Text));
                cmd.ExecuteNonQuery();
                HienThi();
                MessageBox.Show("Cập nhật thành công!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                con.Close();
            }
        }

        //Không cho phép xóa dữ liệu trong bảng

        private void button_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KHÔNG THỂ XÓA DỮ LIỆU TRONG BẢNG NÀY!!!");
        }

        // Tìm kiếm hóa đơn theo personID của khách hàng trong form SalesOrderHeader
        private void button_searchByPersonID_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("TKiemHD_personID_TrongFormSalesOrderHeader", con);
                DataTable dt = new DataTable();
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("@personID", SqlDbType.Int)).Value = int.Parse(textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                dsOrderHeader.DataSource = dt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("PersonID không tồn tại!");
                con.Close();
            }
        }

        //Tìm kiếm hóa đơn theo ngày(từ ngày … đến ngày) trong from form SalesOrderHeader
        private void button_searchByDate_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("TKiemHD_Date_TrongFormSalesOrderHeader", con);
                DataTable dt = new DataTable();
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("@firstday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker6.Text);

                com.Parameters.Add(new SqlParameter("@lastday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker5.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                dsOrderHeader.DataSource = dt;
                con.Close();
            }
            catch 
            {
                MessageBox.Show("Nhập ngày sai!");
                con.Close();
            }
        }

        //Tìm kiếm hóa đơn theo ngày(từ ngày … đến ngày) trong from form SalesOrderHeader
        private void button_searchByPersonID_Date_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("TKiemHoaDon_PersonID_Ngay_TrongFormSalesOrderHeader", con);
                DataTable dt = new DataTable();
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("@personID", SqlDbType.Int)).Value = int.Parse(textBox2.Text);
                com.Parameters.Add(new SqlParameter("@firstday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker6.Text);
                com.Parameters.Add(new SqlParameter("@lastday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker5.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                dsOrderHeader.DataSource = dt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("Nhập sai! Không tìm kiếm được!");
                con.Close();
            }
        }

        private void dsOrderHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dsOrderHeader.Rows[e.RowIndex];

                textBox_PersonID.Text = row.Cells["SalesOrderID"].Value.ToString();

                dateTimePicker1.Text = row.Cells["OrderDate"].Value.ToString();

                textBox1.Text = row.Cells["RevisionNumber"].Value.ToString();

                dateTimePicker2.Text = row.Cells["DueDate"].Value.ToString();

                dateTimePicker3.Text = row.Cells["ShipDate"].Value.ToString();

                textBox5.Text = row.Cells["Status"].Value.ToString();

                textBox18.Text = row.Cells["CurrencyRateID"].Value.ToString();

                textBox19.Text = row.Cells["SubTotal"].Value.ToString();

                textBox7.Text = row.Cells["PurchaseOrderNumber"].Value.ToString();

                textBox9.Text = row.Cells["CustomerID"].Value.ToString();

                textBox10.Text = row.Cells["SalesPersonID"].Value.ToString();

                textBox11.Text = row.Cells["TerritoryID"].Value.ToString();

                textBox12.Text = row.Cells["BillToAddressID"].Value.ToString();

                textBox22.Text = row.Cells["TotalDue"].Value.ToString();

                textBox23.Text = row.Cells["Comment"].Value.ToString();

                textBox6.Text = row.Cells["OnlineOrderFlag"].Value.ToString();

                textBox14.Text = row.Cells["SalesOrderNumber"].Value.ToString();

                textBox24.Text = row.Cells["rowguid"].Value.ToString();

                textBox16.Text = row.Cells["CreditCardID"].Value.ToString();

                textBox17.Text = row.Cells["CreditCardApprovalCode"].Value.ToString();

                textBox8.Text = row.Cells["AccountNumber"].Value.ToString();

                textBox13.Text = row.Cells["ShipToAddressID"].Value.ToString();

                textBox15.Text = row.Cells["ShipMethodID"].Value.ToString();
                dateTimePicker4.Text = row.Cells["ModifiedDate"].Value.ToString();
                textBox20.Text = row.Cells["TaxAmt"].Value.ToString();
                textBox21.Text = row.Cells["Freight"].Value.ToString();
            }
        }
    }
}
