using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        private List<Product> list;
        public EventHandler<EventArgs> SelectionChange { get; set; }

        public List<Product> List
        {
            get { return list; }
            set { list = value; SetListBox(value); }
        }
        public Product SelectedProduct { get { return listBox1.SelectedItem as Product; } set { listBox1.SelectedItem = value; } }

        private void SetListBox(List<Product> value)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(List.ToArray());
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var product = listBox1.SelectedItem as Product;
            SelectionChange.Invoke(sender,e);
        }
    }
}
