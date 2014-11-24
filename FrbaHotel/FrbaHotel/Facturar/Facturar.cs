using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;
using FrbaHotel.NINIRODIE.Repositorios;

namespace FrbaHotel.Facturar
{
    public partial class Facturar : Form
    {
        DataRow renglon;
        DataTable tabla = new DataTable();
        List<Escoit> items;

        Decimal costo_factura, recargo, costo_regimen;
        Decimal monto_a_pagar;
        public Facturar(Decimal costo_fac, Decimal rec, Decimal costo_reg, List<Escoit> it)
        {
            items = it;
            costo_factura = costo_fac;
            recargo = rec;
            costo_regimen = costo_reg;
            InitializeComponent();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            tabla.Columns.Add(new DataColumn("Descripcion"));
            tabla.Columns.Add(new DataColumn("Cantidad"));
            tabla.Columns.Add(new DataColumn("Precio Unitario"));

            int n = 0;
            while (n < items.Count)
            {
                Decimal monto = RepositorioConsumibles.Instance.BuscarMonto(items.ElementAt(n).cod_consumible);
                if (items.ElementAt(n).cod_consumible == 2324)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Coca cola";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = monto.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                if (items.ElementAt(n).cod_consumible == 2325)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Whisky";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = monto.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                if (items.ElementAt(n).cod_consumible == 2326)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Bombones";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = monto.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                if (items.ElementAt(n).cod_consumible == 2327)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Agua mineral";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = monto.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                n = n + 1;
            }

            renglon = tabla.NewRow();
            renglon[0] = "Estadia";
            renglon[1] = "1";
            renglon[2] = costo_regimen.ToString();

            tabla.Rows.Add(renglon);
            dataGridView1.DataSource = tabla;

            if (recargo != 0)
            {
                renglon = tabla.NewRow();
                renglon[0] = "Recargo Estadia";
                renglon[1] = "1";
                renglon[2] = recargo.ToString();

                tabla.Rows.Add(renglon);
                dataGridView1.DataSource = tabla;
            }


            this.dataGridView1.Columns["Descripcion"].ReadOnly = true;
            this.dataGridView1.Columns["Cantidad"].ReadOnly = true;
            this.dataGridView1.Columns["Precio Unitario"].ReadOnly = true;

            monto_a_pagar = costo_factura + costo_regimen;
            monto_a_pagar = monto_a_pagar - recargo;

            label2.Text = monto_a_pagar.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estadia est = RepositorioEstadia.Instance.BuscarEstadiaxCod(items.ElementAt(0).cod_estadia);
            Reserva res = RepositorioReserva.Instance.BuscarReserva2(est.codigoReserva);
            Decimal comprador = RepositorioReserva.Instance.BuscarUsuario(res.identificador);

            RepositorioFactura.Instance.GenerarFactura(monto_a_pagar, items.ElementAt(0).cod_estadia, comprador);
            
            int n = 0;
            while (n < items.Count)
            {
                Decimal precio = RepositorioConsumibles.Instance.BuscarMonto(items.ElementAt(n).cod_consumible);
                RepositorioFactura.Instance.InsertarItemAFactura(items.ElementAt(n).cod_estadia, items.ElementAt(n).cod_consumible, items.ElementAt(n).cantidad, precio, items.ElementAt(n).cod_habitacion);
                n = n + 1;
            }

            List<Item> items_factura = new List<Item>();
            items_factura = RepositorioFactura.Instance.BuscarItemsXFac(items.ElementAt(0).cod_estadia);
            n = 0;
            int j = 0;
            while (n < items.Count)
            {
                Decimal precio = RepositorioConsumibles.Instance.BuscarMonto(items.ElementAt(n).cod_consumible);
                j = 0;
                while (j < items_factura.Count)
                {
                    Consumibles consumibl = RepositorioConsumibles.Instance.BuscarConsuUnico(items.ElementAt(n).cod_consumible);
                    if (items_factura.ElementAt(j).precio == consumibl.precio)
                    {
                        RepositorioEscoit.Instance.ActualizarEscoit(items.ElementAt(n).cod_estadia, items.ElementAt(n).cod_consumible, items_factura.ElementAt(j).identificador);
                    }
                    j = j + 1;
                }
                n = n + 1;
            }
            new Pagar(items.ElementAt(0).cod_estadia, monto_a_pagar).ShowDialog(this);
            this.Close();
        }
    }
}
