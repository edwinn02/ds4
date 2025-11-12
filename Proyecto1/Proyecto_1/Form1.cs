using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_1
{
    public partial class Form1 : Form
    {
        double valor1 = 0, valor2 = 0, resultado = 0;
        string operacion = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text != "")
            {
                valor1 = double.Parse(txtPantalla.Text);
                operacion = "/";
                txtPantalla.Clear();
            }
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text != "")
            {
                valor1 = double.Parse(txtPantalla.Text);
                operacion = "*";
                txtPantalla.Clear();
            }
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text != "")
            {
                valor1 = double.Parse(txtPantalla.Text);
                operacion = "-";
                txtPantalla.Clear();
            }
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            if (txtPantalla.Text != "")
            {
                valor1 = double.Parse(txtPantalla.Text);
                operacion = "+";
                txtPantalla.Clear();
            }
        }

        private void txtPantalla_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConvbinario_Click(object sender, EventArgs e)
        {

        }

        private void btnCE_Click(object sender, EventArgs e)
        {

        }

        private void btnC_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnConvdecimal_Click(object sender, EventArgs e)
        {

        }

        private void btnRaizcuadrada_Click(object sender, EventArgs e)
        {

        }

        private void btnAlcuadrado_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "8";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "6";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "3";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "0";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "2";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += "1";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPantalla.Text == "")
                    return;

                // Si no hay operación , solo muestra el número
                if (string.IsNullOrEmpty(operacion))
                {
                    txtPantalla.Text = txtPantalla.Text;
                    return;
                }

                valor2 = double.Parse(txtPantalla.Text);

                switch (operacion)
                {
                    case "+":
                        resultado = valor1 + valor2;
                        break;
                    case "-":
                        resultado = valor1 - valor2;
                        break;
                    case "*":
                        resultado = valor1 * valor2;
                        break;
                    case "/":
                        if (valor2 == 0)
                        {
                            MessageBox.Show("No se puede dividir entre cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        resultado = valor1 / valor2;
                        break;
                    default:
                        resultado = valor2;
                        break;
                }

                txtPantalla.Text = resultado.ToString();
                // Reinicia la operación
                operacion = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }

}

