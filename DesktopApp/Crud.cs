using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class Crud : Form
    {
        public Crud()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateForm createForm = new CreateForm();
            createForm.ShowDialog();
            this.Hide();
            Crud crudForms = new Crud();
            crudForms.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DisplayForm createForm = new DisplayForm();
            createForm.ShowDialog();
            this.Hide();
            Crud crudForms = new Crud();
            crudForms.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();
            this.Hide();
            Crud crudForms = new Crud();
            crudForms.ShowDialog();
            this.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DeleteForm deleteForm = new DeleteForm();
            deleteForm.ShowDialog();
            this.Hide();
            Crud crudForms = new Crud();
            crudForms.ShowDialog();
            this.Close();

        }
    }
}
