using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.LA_REVANCHA.Clases;
using FrbaHotel.LA_REVANCHA.Repositorios;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class BuscarCliente : Form
    {
        public Cliente cliente { get; set; }

        public BuscarCliente()
        {
            InitializeComponent();
            Popular();

        }

        private void Popular()
        {
            this.tipoIdComboBox.DataSource = new List<String>() { "DUI", "DNI", "CI", "LC" };
            
            this.clienteDataGridView.DataSource = new List<Cliente>();
            this.clienteDataGridView.Refresh();
            this.clienteDataGridView.Columns["departamento"].Visible = false;
            this.clienteDataGridView.Columns["localidad"].Visible = false;
            this.clienteDataGridView.Columns["nacimiento"].Visible = false;
            this.clienteDataGridView.Columns["pais"].Visible = false;
            this.clienteDataGridView.Columns["nacionalidad"].Visible = false;
            this.clienteDataGridView.Columns["telefono"].Visible = false;
            this.clienteDataGridView.Columns["calle"].Visible = false;
            this.clienteDataGridView.Columns["nro_calle"].Visible = false;
            this.clienteDataGridView.Columns["identificador"].Visible = false;
            this.clienteDataGridView.Columns["piso"].Visible = false;
            this.clienteDataGridView.Columns["codigo_usuario"].Visible = false;
        }

        private void CancelarBoton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AceptarBoton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recuerde seleccionar al cliente buscado en caso de encontrarlo.",
                            "Atención", MessageBoxButtons.OK);
            this.DialogResult = DialogResult.OK;
            cliente = (Cliente)this.clienteDataGridView.CurrentRow.DataBoundItem;
            this.Close();
        }

        private void BuscarBoton_Click(object sender, EventArgs e)
        {
            if (!(this.NumeroTextBox.Text == "" & this.mailTextBox.Text == "")
                | this.mailTextBox.Text != "")
            {
                PopularGrillaClientes();
            }
            else
            {
                MessageBox.Show("Debe ingresar un tipo y número de identificación\n" +
                                "o una dirección de mail.", "Atención", MessageBoxButtons.OK);
            }
        }

        private void PopularGrillaClientes()
        {
            Decimal nroId = (NumeroTextBox.Text) != "" ? Decimal.Parse(NumeroTextBox.Text) : 0;
            String tipoID = (tipoIdComboBox.SelectedItem != null) ? tipoIdComboBox.SelectedItem.ToString() : "";

            this.clienteDataGridView.DataSource = RepositorioCliente.Instance.
                    BuscarCliente(nroId, tipoID, mailTextBox.Text);
        }
    }
}
