using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Factura2022
{
    public partial class FrmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }
        FrmMenuProductos frmUsuarios = null;
        FrmMenu frmProducto = null;
        FrmPedido frmFactura = null;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmUsuarios == null)
            {
                frmUsuarios = new FrmMenuProductos();
                frmUsuarios.MdiParent = this;
                frmUsuarios.FormClosed += FrmUsuarios_FormClosed;
                frmUsuarios.Show();
            }
            else
            {
                frmUsuarios.Activate();
            }
        }
        private void FrmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmUsuarios = null;
        }

        private void ListaProductosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
                frmProducto = new FrmMenu();
                frmProducto.MdiParent = this;
                frmProducto.FormClosed += FrmProducto_FormClosed;
                frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducto = null;
        }

        private void NuevaFacturaToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmFactura == null)
            {
                frmFactura = new FrmPedido();
                frmFactura.MdiParent = this;
                frmFactura.FormClosed += FrmFactura_FormClosed;
                frmFactura.Show();
            }
            else
            {
                frmFactura.Activate();
            }
        }

        private void FrmFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFactura = null;
        }

        private void toolStripTabItem1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
