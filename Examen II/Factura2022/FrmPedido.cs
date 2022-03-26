using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura2022
{
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        ProductoDA productoDA = new ProductoDA();
        Factura factura = new Factura();
        Producto producto;
        FacturaDA facturaDA = new FacturaDA();

        List<Factura> insertarFactura = new List<Factura>();

        decimal subTotal = decimal.Zero;
        decimal isv = decimal.Zero;
        decimal totalAPagar = decimal.Zero;

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            PedidoDataGridView.DataSource = insertarFactura;
        }

        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto();
                producto = productoDA.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionProductoTextBox.Text = producto.Descripcion;
                CantidadTextBox.Focus();
            }
            else
            {
                producto = null;
                DescripcionProductoTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }

        //private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CantidadTextBox.Text))
        //    {
        //        Factura detalleFactura = new Factura();
        //        insertarFactura. = producto.Codigo;
        //        detalleFactura.Descripcion = producto.Descripcion;
        //        detalleFactura.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
        //        detalleFactura.Precio = producto.Precio;
        //        detalleFactura.Total = producto.Precio * Convert.ToInt32(CantidadTextBox.Text);

        //        subTotal += detalleFactura.Total;
        //        isv = subTotal * 0.15M;
        //        totalAPagar = subTotal + isv;

        //        SubTotalTextBox.Text = subTotal.ToString();
        //        ISVTextBox.Text = isv.ToString();
        //        TotalTextBox.Text = totalAPagar.ToString();

        //        detalleFacturaLista.Add(detalleFactura);
        //        DetalleDataGridView.DataSource = null;
        //        DetalleDataGridView.DataSource = detalleFacturaLista;


        //    }
        //}

        //private void GuardarButton_Click(object sender, EventArgs e)
        //{
        //    factura.Fecha = FechaDateTimePicker.Value;
        //    factura.SubTotal = Convert.ToDecimal(SubTotalTextBox.Text);
        //    factura.Impuesto = Convert.ToDecimal(ISVTextBox.Text);
        //    factura.Total = Convert.ToDecimal(TotalTextBox.Text);

        //    int IdPedido = 0;

        //    IdPedido = facturaDA.InsertarFactura(factura);

        //    if (IdPedido != 0)
        //    {
        //        foreach (var item in insertarFactura)
        //        {
        //            item.IdPedido = IdPedido;
        //            facturaDA.InsertarFactura(item);
        //        }
        //    }


        //}


    }

}