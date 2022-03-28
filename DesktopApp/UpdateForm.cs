using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CustomerObjects;
using DataAccessLayer;

namespace DesktopApp
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.ID = int.Parse(txtIdval.Text);
            customer.Name = txtName.Text;
            customer.City = txtCity.Text;
            customer.PhoneNumber = txtPhno.Text;
            int RowsAffected = DataAccessLayer.CrudOperations.UpdateCustomer(customer);

            if (RowsAffected > 0)
            {
                lblAck.Text = "Successsfully";
                MessageBox.Show("Record Inserted Successfully....", "Success");

            }

            else
            {
                lblAck.Text = "UnSuccesssfully";

                MessageBox.Show("Record insertion not successfull", "Failure");
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtIdval.Text = "";
            txtName.Text = "";
            txtCity.Text = "";
            txtPhno.Text = "";
            txtIdval.Focus();
        }
    }
}
