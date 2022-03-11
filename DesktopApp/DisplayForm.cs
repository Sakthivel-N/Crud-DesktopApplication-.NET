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
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        

       

        
        private void ShowCustomerRecords()      //Read
        {
            dataGridView1.DataSource = CrudOperations.GetAllCustomers();
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 250;
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            ShowCustomerRecords();
        }
    }
}
