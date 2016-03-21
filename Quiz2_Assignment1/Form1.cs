using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Quiz2_Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
            private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text) | string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("provide User Name and Password");
            }
 
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Select User Type");
            }
            
 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=pc101;Initial Catalog=SMS;User ID=sa;Password=mike";
            conn.Open();
 
            string UserName = textBox1.Text;
            string Password = textBox2.Text;
            string UserType = textBox3.Text;

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbluser WHERE username = '" + textBox1.Text + "' and usertype = '" + textBox3.Text + "' and mypassword = '" + textBox2.Text + "'", conn);
 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
 
            System.Data.SqlClient.SqlDataReader dr = null;
            dr = cmd.ExecuteReader();
         
            
                if (this.textBox3.Text == dr["UserType"].ToString() & this.textBox1.Text == dr["UserName"].ToString() & this.textBox2.Text == dr["mypassword"].ToString() & this.textBox3.Text == "Data Entry Clerk")
                 {
                     MessageBox.Show("*** Login Successful ***");
                     Form1 f = new Form1();
                     f.Show();
                    // f.CreateUserAccountToolStripMenuItem.Enabled = false;
                     this.Hide();
                 }

                else if (this.textBox3.Text == dr["UserType"].ToString() & this.textBox1.Text == dr["UserName"].ToString() & this.textBox2.Text == dr["mypassword"].ToString())
                 {
                     MessageBox.Show("*** Login Successful ***");
                     Form1 g = new Form1();
                     g.Show();
                     this.Hide();
                 }
 
                 else
                 {
                    MessageBox.Show("Invalid UserName or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     MessageBox.Show("Access Denied!!");
                   
                 }          
            
        }

            private void button1_Click_1(object sender, EventArgs e)
            {

            }
        }
    }

