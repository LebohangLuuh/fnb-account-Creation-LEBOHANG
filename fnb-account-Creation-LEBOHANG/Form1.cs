using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace fnb_account_Creation_LEBOHANG
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=sqlserver.dynamicdna.co.za;Initial Catalog=fnb-account-creation-Lebohang;User ID=BBD;Password=123 ");
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBxFName.Clear();
            txtBxEmail.Clear();
            txtPhone.Clear();
            rchTxtBxAddress.Clear();
            dateOfBirth.Value = DateTime.Now;

            txtBxFName.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtBxFName.Text.Length > 0 && txtBxEmail.Text.Length > 0 && rchTxtBxAddress.Text.Length > 0 && txtPhone.Text.Length > 0)
            {


                if (txtBxFName.Text.Length < 3)

                    MessageBox.Show("please enter your full name");

                if (txtBxEmail.Text.Contains(' '))

                    MessageBox.Show("please enter valid email address");

                if (txtPhone.TextLength > 12 || txtPhone.Text.Length < 10)

                    MessageBox.Show("Pleae enter valid phone number");


                if (2022 - dateOfBirth.Value.Year > 17)
                {
                    try
                    {
                        conn.Open();

                        SqlCommand com = new SqlCommand("INSERT INTO Customer VALUES('"+txtBxFName.Text+"','"+txtBxEmail.Text+"','"+ txtPhone.Text+"','"+rchTxtBxAddress.Text+"', '"+dateOfBirth.Value+"') ", conn);

                        try
                        {
                            com.ExecuteNonQuery();
                            MessageBox.Show("Account created successfully!!");

                            txtBxFName.Clear();
                            txtBxEmail.Clear();
                            txtPhone.Clear();
                            rchTxtBxAddress.Clear();
                            dateOfBirth.Value = DateTime.Now;

                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Failed to create an account");
                        }

                        MessageBox.Show("Account created successfully!!");


                        conn.Close();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Failed to connect to Database");
                    }

                   
                }
                else

                    MessageBox.Show("too young to open an account");
            }
            else
            {
               
                MessageBox.Show("Please fill in al the required fields!!");
            }

        }

        private void txtBxEmail_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBxFName_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
