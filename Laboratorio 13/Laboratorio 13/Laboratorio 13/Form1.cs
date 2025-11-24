using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Laboratorio_13
{
    public partial class Form1 : Form
    {
        // Cadena de conexión correcta para tu servidor e instancia
        private string connectionString =
            @"Server=DESKTOP-SMNNS8P\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);

            try
            {
                conexion.Open();
                MessageBox.Show("Conexión abierta.");

                string query = "SELECT ProductName FROM [dbo].[Products]";
                SqlCommand cmd = new SqlCommand(query, conexion);
                SqlDataReader reader = cmd.ExecuteReader();

                listBox1.Items.Clear();

                while (reader.Read())
                {
                    listBox1.Items.Add(reader["ProductName"].ToString());
                }

                reader.Close();
                conexion.Close();
                MessageBox.Show("Conexión cerrada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
