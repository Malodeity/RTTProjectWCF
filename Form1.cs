using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTTProjectWCF.ServiceReference1;
using System.IO;

namespace RTTProjectWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Employee p = new Employee();
            p.name = txtName.Text;
            p.surname = txtSurname.Text;
            p.email = txtEmail.Text;
            p.resAddress = txtResAddress.Text;
            p.workAddress = txtWoAddress.Text;
            p.postAddress = txtPosAddress.Text;
            p.cellNum = txtCellNum.Text;
            p.workNum = txtWorkNum.Text;
           

            Service1Client service = new Service1Client();

           if(service.InsertEmployee(p) == 1)
            {
                MessageBox.Show("Employee was added successfully");
                txtName.Clear();
                txtSurname.Clear();
                txtEmail.Clear();
                txtResAddress.Clear();
                txtWoAddress.Clear();
                txtPosAddress.Clear();
                txtCellNum.Clear();
                txtWorkNum.Clear();

            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void btnView_Click(object sender, EventArgs p)
        {


            //List<Employee> GetEmployee = new List<Employee>();
            Service1Client service = new Service1Client();
            dgvEmployees.DataSource = service.GetEmployee();

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //======WRITING TO FILE===============
            TextWriter writer = new StreamWriter(@"C:\Users\User\Desktop\Final\Text.txt");
            for(int m = 0; m < dgvEmployees.Rows.Count; m++)
            {
                for(int j = 0; j < dgvEmployees.Columns.Count-2; j++)
                {
                    writer.Write(""+dgvEmployees.Rows[m].Cells[j].Value.ToString()+""+", ");

                }
           
                writer.WriteLine("");
                writer.WriteLine("-------------------------------RTT EMPLOYEES------------------------");
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Data was successfully exported");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
