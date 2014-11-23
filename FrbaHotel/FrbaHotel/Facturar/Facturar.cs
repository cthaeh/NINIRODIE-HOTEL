using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.NINIRODIE.Clases;

namespace FrbaHotel.Facturar
{
    public partial class Facturar : Form
    {
        DataRow renglon;
        DataTable tabla = new DataTable();
        List<Item> items;

        Decimal costo_factura, recargo, costo_regimen, bandera;
        Decimal monto_a_pagar;
        public Facturar(Decimal costo_fac, Decimal rec, Decimal costo_reg, Decimal band, List<Item> it)
        {
            items = it;
            bandera = band;
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
                if (items.ElementAt(n).codigo_consumible == 2324)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Coca cola";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = items.ElementAt(n).precio.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                if (items.ElementAt(n).codigo_consumible == 2325)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Whisky";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = items.ElementAt(n).precio.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                if (items.ElementAt(n).codigo_consumible == 2326)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Bombones";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = items.ElementAt(n).precio.ToString();

                    tabla.Rows.Add(renglon);
                    dataGridView1.DataSource = tabla;
                }
                if (items.ElementAt(n).codigo_consumible == 2327)
                {
                    renglon = tabla.NewRow();
                    renglon[0] = "Agua mineral";
                    renglon[1] = items.ElementAt(n).cantidad.ToString();
                    renglon[2] = items.ElementAt(n).precio.ToString();

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
            new Pagar(bandera, monto_a_pagar).ShowDialog(this);
            this.Close();
        }
    }
}
