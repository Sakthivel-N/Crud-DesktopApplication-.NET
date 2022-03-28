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
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer(); 
            customer.Name = txtName.Text;
            customer.City = cboCity.SelectedItem.ToString();
            customer.PhoneNumber = txtPhno.Text;
            int RowsAffected = CrudOperations.SaveEmployee(customer);

            if (RowsAffected > 0)
                MessageBox.Show("Record Inserted Successfully....","Success");
            else
                MessageBox.Show("Record insertion not successfull","Failure");
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            cboCity.SelectedIndex = -1;
            txtPhno.Text = "";
            txtName.Focus();
        }

        
    }
}
