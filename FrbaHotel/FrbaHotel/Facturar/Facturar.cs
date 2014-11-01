﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Facturar
{
    public partial class Facturar : Form
    {
        Decimal costo_factura, recargo, costo_regimen;
        public Facturar(Decimal costo_fac, Decimal rec, Decimal costo_reg)
        {
            costo_factura = costo_fac;
            recargo = rec;
            costo_regimen = costo_reg;
            InitializeComponent();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            Decimal monto_a_pagar = costo_factura + costo_regimen;
            monto_a_pagar = monto_a_pagar - recargo;

            label2.Text = monto_a_pagar.ToString();
        }
    }
}
