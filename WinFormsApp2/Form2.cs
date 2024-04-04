using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private ErrorProvider errorProvider;
        internal Book NewBook { get; private set; }
        public Form2()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider.SetError(textBox1, "Title is required");
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider.SetError(textBox2, "Author is required");
                return;
            }
            if (!int.TryParse(textBox3.Text, out int noOfPages)||noOfPages<=0)
            {
                errorProvider.SetError(textBox3, "No of pages must be a number");
                return;
            }
            NewBook = new Book(textBox1.Text, textBox2.Text, noOfPages);
            DialogResult = DialogResult.OK;
        }
    }
}
