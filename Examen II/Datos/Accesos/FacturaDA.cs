using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos
{
    public class FacturaDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=golosina; Uid=root; Pwd=1234;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public int InsertarFactura(Factura factura)
        {
            int IdFactura = 0;
            try
            {
                string sql = "INSERT INTO pedido (IdPedido, Cliente, Fecha, SubTotal, Impuesto, Total) VALUES (@IdPedido, @Cliente, @Fecha, @SubTotal, @Impuesto, @Total); select last_insert_id();";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdPedido", factura.IdPedido);
                cmd.Parameters.AddWithValue("@Cliente", factura.Cliente);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@SubTotal", factura.SubTotal);
                cmd.Parameters.AddWithValue("@Impuesto", factura.Impuesto);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                IdFactura = Convert.ToInt32(cmd.ExecuteScalar());


                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return IdFactura;
        }

        public DataTable ListarPedido()
        {
            DataTable listaPedido = new DataTable();

            try
            {
                string sql = "SELECT * FROM pedido;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listaPedido.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
            }
            return listaPedido;
        }



    }
}
