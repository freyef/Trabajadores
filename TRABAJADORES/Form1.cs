using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TRABAJADORES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eMPRESADataSet.Trabajadores' Puede moverla o quitarla según sea necesario.
            this.trabajadoresTableAdapter.Fill(this.eMPRESADataSet.Trabajadores);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CALCULAR_Click(object sender, EventArgs e)
        {

        }

        private void txtcategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void AGREGAR_Click(object sender, EventArgs e)
        {
            try
            {
                using (var bd = new EMPRESAEntities()) 
                {
                    var trabajador = new Trabajadores();                 
                    trabajador.Nombre = txtnombre.Text;
                    trabajador.Apellidos = txtapellido.Text;
                    trabajador.SueldoBruto = Convert.ToInt32(txtsueldo.Text);
                    trabajador.Categoria = txtcategoria.Text;

                    bd.Trabajadores.Add(trabajador);
                    bd.SaveChanges();
                    MessageBox.Show("trabajador registrado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar trabajador: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
