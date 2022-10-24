﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

public Form1()
        {
            InitializeComponent();
            combo();
        }
        Connection Connection = new Connection();
        private void FinBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Connection.conectar();
            DateTime now = DateTime.Now;
            try
            {
                var command = Connection.conn.CreateCommand();
                command.CommandText = "insert into categoria (`descr`) values ('" + textBox2.Text + "')";
                command.ExecuteNonQuery();
            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        //string[] itens;

        //Traduz de descrição para id;
        private int tradcat (string categoria)
        {
            //    for(int c = 0; c <= itens.Length; c++) { if (categoria == itens[c]) { return c; }}

            Connection.conectar();
            var command = Connection.conn.CreateCommand();
            command.CommandText = "select IDCategoria from categoria where descr = '"+categoria+"'";
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32("IDCategoria");
            Connection.conn.Close();

        }
        private void combo() {
            Connection.conectar();
            var command = Connection.conn.CreateCommand();
            command.CommandText = "select descr from categoria";
            command.ExecuteNonQuery();
            MySqlDataReader reader = command.ExecuteReader();
            
            //List<string> termsList = new List<string>();
            while (reader.Read())
            {
                //termsList.Add(reader.GetString(0));
                comboBox2.Items.Add(reader.GetString(0));
            }
            //itens = termsList.ToArray();
            //comboBox2.Items.AddRange(itens);
            Connection.conn.Close();   
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = tradcat(comboBox2.SelectedItem.ToString());
            MessageBox.Show(a.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.conectar();
            if (!textBox3.Text.Equals(""))
            {
                var command = Connection.conn.CreateCommand();
                command.CommandText = "insert into categoria (`descr`) values ('" + textBox3.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Sucesso");
                Connection.conn.Close();
            }
            else { MessageBox.Show("Campo descrição em branco"); Connection.conn.Close(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection.conectar();
            if (!textBox3.Text.Equals(""))
            {
                var command = Connection.conn.CreateCommand();
                command.CommandText = "delete from categoria where descr = '" + textBox3.Text + "'";
                command.ExecuteNonQuery();
                MessageBox.Show("Sucesso");
                Connection.conn.Close();
            }
            else
            {
                MessageBox.Show("Campo descrição em branco");
                Connection.conn.Close();
            }
        }

        
    }
}
