using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DInvoice
    {
        static string StringConnect = "Data Source=LAPTOP-ENASFBPJ\\SQLEXPRESS;Initial Catalog=Facturas;User ID = tecsup; Password=123456";

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = new List<Invoice>();
            using (SqlConnection conn = new SqlConnection(StringConnect))
            {
                conn.Open();
                string query = "GetInvoices";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                invoices.Add(new Invoice
                                {
                                    Invoice_id = Convert.ToInt32(reader["invoice_id"]),
                                    Customer_id = Convert.ToInt32(reader["customer_id"]),
                                    Date = Convert.ToDateTime(reader["date"]),
                                    Total = Convert.ToDecimal(reader["total"]),
                                    Active = Convert.ToBoolean(reader["active"])
                                });
                            }
                        }
                    }
                }
                conn.Close();
            }
            return invoices;
        }

        public void InsertInvoice(int customer_id, DateTime date, decimal total) 
        {
            using (SqlConnection conn = new SqlConnection(StringConnect))
            {
                conn.Open();
                string query = "InsertInvoice";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                    cmd.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal));

                    cmd.Parameters["@customer_id"].Value = customer_id;
                    cmd.Parameters["@date"].Value = date;
                    cmd.Parameters["@total"].Value = total;

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void DeleteInvoice(int id)
        {
            using (SqlConnection conn = new SqlConnection(StringConnect))
            {
                conn.Open();
                string query = "DeleteInvoice";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@invoice_id", SqlDbType.Int));
                    cmd.Parameters["@invoice_id"].Value = id;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }

   
}
