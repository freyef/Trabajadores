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

        private void BUSACAR_Click(object sender, EventArgs e)
        {
            try
            {

               
                using (var bd = new EMPRESAEntities())
                {
                    var trabajador = bd.Trabajadores.First(s => s.Nombre == txtnombre.Text);
                    txtnombre.Text = trabajador.Nombre;
                    txtapellido.Text = trabajador.Apellidos;
                    txtsueldo.Text = trabajador.SueldoBruto.ToString();
                    txtcategoria.Text = trabajador.Categoria;
                    MessageBox.Show("trabajador  encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"trabajador no registrado: {ex.Message}", "trabajador no encontrado");
            }
        }

        private void CALCULAR_Click_1(object sender, EventArgs e)
        {
            try
            {
                decimal sueldoBruto = Convert.ToDecimal(txtsueldo.Text);
                decimal porcentajeAumento = 0;
                decimal montoAumento = 0;
                decimal sueldoNeto = 0;

                if (sueldoBruto >= 999 && sueldoBruto < 1999)
                {
                    porcentajeAumento = 0.10m;
                }
                else if (sueldoBruto >= 1999 && sueldoBruto < 3999)
                {
                    porcentajeAumento = 0.20m;
                }
                else if (sueldoBruto >= 3999)
                {
                    porcentajeAumento = 0.30m;
                }
                else
                {
                    porcentajeAumento = 0.40m;
                }

                montoAumento = porcentajeAumento * sueldoBruto;
                sueldoNeto = sueldoBruto + montoAumento;

                textBox1.Text = montoAumento.ToString("C");
                textBox2.Text = sueldoNeto.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular el sueldo neto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
