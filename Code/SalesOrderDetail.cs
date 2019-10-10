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
    public partial class SalesOrderDetail : Form
    {
        public SalesOrderDetail()
        {
            InitializeComponent();
        }
        public static SqlConnection con;
        public static string conString;

        //SqlConnection con;
        private void SalesOrderDetail_Load(object sender, EventArgs e)
        {
            conString = @"Data Source=.; Initial Catalog=iSaleManagement; Integrated Security=True";
            con = new SqlConnection(conString);
            con.Open();
            HienThi();
            con.Close();
        }

        //hiển thị dữ liệu danh sách bảng n_SalesOrderDetail
        public void HienThi()                
        {
            string sqlselect = "SELECT * FROM n_SalesOrderDetail";
            SqlCommand cmd = new SqlCommand(sqlselect, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dsOrderDetail.DataSource = dt;
        }

        // Thêm Sales Order Detail mới
        private void button_add_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlDataAdapter ad = new SqlDataAdapter("InsertSalesOrderDetail", con);
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                ad.SelectCommand.Parameters.Add("@SalesOrderID", SqlDbType.Int).Value = int.Parse(textBox51.Text);
                ad.SelectCommand.Parameters.Add("@SalesOrderDetailID", SqlDbType.Int).Value = int.Parse(textBox50.Text);
                ad.SelectCommand.Parameters.Add("@CarrierTrackingNumber", SqlDbType.NVarChar, (25)).Value = textBox49.Text;
                ad.SelectCommand.Parameters.Add("@OrderQty", SqlDbType.SmallInt).Value = short.Parse(textBox48.Text);
                ad.SelectCommand.Parameters.Add("@ProductID", SqlDbType.Int).Value = int.Parse(textBox47.Text);
                ad.SelectCommand.Parameters.Add("@SpecialOfferID", SqlDbType.Int).Value = int.Parse(textBox46.Text);
                ad.SelectCommand.Parameters.Add("@UnitPrice", SqlDbType.Money).Value = Decimal.Parse(textBox45.Text);
                ad.SelectCommand.Parameters.Add("@UnitPriceDiscount", SqlDbType.Money).Value = Decimal.Parse(textBox37.Text);
                ad.SelectCommand.Parameters.Add("@LineTotal", SqlDbType.Decimal).Value = textBox27.Text;
                ad.SelectCommand.Parameters.Add("@rowguid", SqlDbType.UniqueIdentifier).Value = Guid.Parse(textBox44.Text);
                ad.SelectCommand.Parameters.Add("@ModifiedDate", SqlDbType.DateTime).Value = DateTime.Parse(dateTimePicker5.Text);
                ad.SelectCommand.ExecuteNonQuery();
          //    con.Close();
                MessageBox.Show("Thêm thành công!");
                HienThi();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                con.Close();
            }
            /*    try
                {
                    string sqlInsert = "INSERT INTO n_SalesOrderDetail VALUES (@SalesOrderID, @SalesOrderDetailID, @CarrierTrackingNumber, @OrderQty, @ProductID, @SpecialOfferID, @UnitPrice, @UnitPriceDiscount, @LineTotal, @rowguid, @ModifiedDate)";
                    SqlCommand cmd = new SqlCommand(sqlInsert, con);
                    cmd.Parameters.AddWithValue("SalesOrderID", textBox51.Text);
                    cmd.Parameters.AddWithValue("SalesOrderDetailID", textBox50.Text);
                    cmd.Parameters.AddWithValue("CarrierTrackingNumber", textBox49.Text);
                    cmd.Parameters.AddWithValue("OrderQty", textBox48.Text);
                    cmd.Parameters.AddWithValue("ProductID", textBox47.Text);
                    cmd.Parameters.AddWithValue("SpecialOfferID", textBox46.Text);
                    cmd.Parameters.AddWithValue("UnitPrice", textBox45.Text);
                    cmd.Parameters.AddWithValue("UnitPriceDiscount", textBox37.Text);
                    cmd.Parameters.AddWithValue("LineTotal", textBox27.Text);
                    cmd.Parameters.AddWithValue("rowguid", textBox44.Text);
                    cmd.Parameters.AddWithValue("ModifiedDate", Convert.ToDateTime(dateTimePicker5.Text));
                    cmd.ExecuteNonQuery();
                    HienThi();
               }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }*/

        }

        //Cập nhật chỉnh sửa dữ liệu trong bảng SalesOrderDrtail
        private void button_update_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string sqlUpdate = "UPDATE n_SalesOrderDetail SET CarrierTrackingNumber = @CarrierTrackingNumber,OrderQty = @OrderQty, ProductID = @ProductID, SpecialOfferID = @SpecialOfferID,UnitPrice = @UnitPrice, UnitPriceDiscount = @UnitPriceDiscount, LineTotal = @LineTotal, rowguid = @rowguid, ModifiedDate = @ModifiedDate WHERE SalesOrderID = @SalesOrderID and SalesOrderDetailID = @SalesOrderDetailID ";
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("SalesOrderID", textBox51.Text);
                cmd.Parameters.AddWithValue("SalesOrderDetailID", textBox50.Text);
                cmd.Parameters.AddWithValue("CarrierTrackingNumber", textBox49.Text);
                cmd.Parameters.AddWithValue("OrderQty", textBox48.Text);
                cmd.Parameters.AddWithValue("ProductID", textBox47.Text);
                cmd.Parameters.AddWithValue("SpecialOfferID", textBox46.Text);
                cmd.Parameters.AddWithValue("UnitPrice", textBox45.Text);
                cmd.Parameters.AddWithValue("UnitPriceDiscount", textBox37.Text);
                cmd.Parameters.AddWithValue("LineTotal", textBox27.Text);
                cmd.Parameters.AddWithValue("rowguid", Guid.Parse(textBox44.Text));
                cmd.Parameters.AddWithValue("ModifiedDate", Convert.ToDateTime(dateTimePicker5.Text));
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

        //Không cho phép xóa dữ liệu trong bảng
        private void button_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("KHÔNG THỂ XÓA DỮ LIỆU TRONG BẢNG NÀY!!!");
        }

        // Tìm kiếm hóa đơn theo personID của khách hàng trong form SalesOrderDetail
        private void button_searchByPersonID_Click(object sender, EventArgs e)
        {
            con.Open();   
            try
            {
                SqlCommand com = new SqlCommand("TKiemHD_personID_TrongFormSalesOrderDetail", con);
                DataTable dt = new DataTable();
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("@personID", SqlDbType.Int)).Value = int.Parse(textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                dsOrderDetail.DataSource = dt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("PersonID không tồn tại!");
                con.Close();
            }
        }

       //Tìm kiếm hóa đơn theo ngày(từ ngày … đến ngày) trong from form SalesOrderDetail
        private void button_searchByDate_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("TKiemHD_Date_TrongFormSalesOrderDetail", con);
                DataTable dt = new DataTable();
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("@firstday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker1.Text);

                com.Parameters.Add(new SqlParameter("@lastday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker2.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                dsOrderDetail.DataSource = dt;
                con.Close();
            }
            catch 
            {
                MessageBox.Show("Nhập ngày sai!");
                con.Close();
            }
        }

        //Tìm kiếm hóa đơn theo ngày(từ ngày … đến ngày) trong from form SalesOrderDetail
        private void button_searchByPersonID_Date_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand com = new SqlCommand("TKiemHoaDon_PersonID_Ngay_TrongFormSalesOrderDetail", con);
                DataTable dt = new DataTable();
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.Add(new SqlParameter("@personID", SqlDbType.Int)).Value = int.Parse(textBox1.Text);
                com.Parameters.Add(new SqlParameter("@firstday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker1.Text);
                com.Parameters.Add(new SqlParameter("@lastday", SqlDbType.DateTime)).Value = DateTime.Parse(dateTimePicker2.Text);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
                dsOrderDetail.DataSource = dt;
                con.Close();
            }
            catch
            {
                MessageBox.Show("Nhập sai! Không tìm kiếm được!");
                con.Close();
            }
        }
    }
}
