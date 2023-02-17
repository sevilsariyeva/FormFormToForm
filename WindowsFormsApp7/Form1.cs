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
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();
        public EventHandler<EventArgs> SelectionHandler { get; set; }
        public EventHandler<EventArgs> UpdateHandler { get; set; }
        public Form1()
        {
            InitializeComponent();
            SelectionHandler = new EventHandler<EventArgs>(SelectItem);
            UpdateHandler = new EventHandler<EventArgs>(UpdateItem);
        }

        private void UpdateItem(object sender, EventArgs e)
        {
            var product = form2.SelectedProduct;
            product.ProductName = nameTxtB.Text;
            product.Description = descriptionTxtB.Text;
            product.ProductPrice = decimal.Parse(priceTxtB.Text);
            form2.SelectedProduct = product;
        }

        private void SelectItem(object sender, EventArgs e)
        {
            var product = form2.SelectedProduct;
            nameTxtB.Text = product.ProductName;
            descriptionTxtB.Text = product.Description;
            priceTxtB.Text = product.ProductPrice.ToString();
        }

        Form2 form2 = new Form2();
        private void addBtn_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.ProductName=nameTxtB.Text;
            product.Description = descriptionTxtB.Text;
            product.ProductPrice = decimal.Parse(priceTxtB.Text);
            products.Add(product);
        }
        private void showlistBtn_Click(object sender, EventArgs e)
        {
            form2.List = products;
            form2.SelectionChange = SelectionHandler;
            if (form2.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var product = form2.SelectedProduct;
            UpdateHandler.Invoke(sender, e);
        }
    }
}
