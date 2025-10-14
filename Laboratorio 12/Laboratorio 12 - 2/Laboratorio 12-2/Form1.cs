﻿using System;
using System.Windows.Forms;

namespace Laboratorio_12_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double nota1 = double.Parse(textBox1.Text);
            double nota2 = double.Parse(textBox2.Text);
            double nota3 = double.Parse(textBox3.Text);

            double promedio = (nota1 + nota2 + nota3) / 3;
            textBox4.Text = promedio.ToString("F2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}