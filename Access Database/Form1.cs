﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//agregamos esta libreria

namespace Access_Database
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection
            (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Alumno\Downloads\DbPersona.accdb");
        public Form1()
        {
            InitializeComponent();
        }
        void LlenarGrid()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from TablaPersona order by Id", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            //textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into TablaPersona(Nombre, Edad)values('" + textBox2.Text + "'," + textBox3.Text + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro exitosamente guardado.");
            limpiarTexto();
            LlenarGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void limpiarTexto()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("delete from TablaPersona where Id=" + textBox1.Text + " ", conn);
            cmd.ExecuteNonQuery();
            conn. Close();
            MessageBox.Show("Registro eliminado.");
            limpiarTexto();
            LlenarGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("update TablaPersona set Nombre='" + textBox2.Text + "', Edad=" + textBox3.Text + " where Id=" + textBox1.Text + " ", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro actualizado.");
            limpiarTexto();
            LlenarGrid();

        }
    }
}
