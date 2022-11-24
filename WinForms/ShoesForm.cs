using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinForms
{
    public partial class ShoesForm : Form
    {
        protected readonly IRegistered _reg;
        private List<ShoesDTO> _shoes;
        public ShoesForm(IRegistered reg)
        {
            InitializeComponent();
            _reg = reg;
            //RefreshGrid();
        }

        private void ShoesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shoefactoryDataSet.Shoess' table. You can move, or remove it, as needed.
            //this.shoessTableAdapter.Fill(this.shoefactoryDataSet.Shoess);
            _shoes = _reg.GetShoes();
            BindingList<ShoesDTO> bl = new BindingList<ShoesDTO>(_shoes);
            shoessBindingSource.DataSource = bl;

            var currShoes = shoessBindingSource.Current;

            dataGridView1.DataSource = shoessBindingSource;
            bindingNavigator1.BindingSource = shoessBindingSource;

        }
        private void RefreshGrid()
        {
           _shoes = _reg.GetShoes();
            BindingList<ShoesDTO> blOrders = new BindingList<ShoesDTO>(_shoes);
            shoessBindingSource.DataSource = blOrders;

            var currShoes = shoessBindingSource.Current;

            dataGridView1.DataSource = shoessBindingSource;
            bindingNavigator1.BindingSource = shoessBindingSource; 
        }


        private void BuyButton_Click(object sender, EventArgs e)
        {         
            Quantitylabel.Visible = true;
            tbQuantity.Visible = true;
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        { 
            ShoesDTO selectedShoes = shoessBindingSource.Current as ShoesDTO;
            int quantity = Convert.ToInt32(tbQuantity.Text);
            var message = $"Confirm order:  Product: {selectedShoes.Size} Price: {quantity* selectedShoes.Price}";
            var response = MessageBox.Show(message, "Order", MessageBoxButtons.YesNo);         
            if (response == DialogResult.Yes)
            {
                var success = _reg.Buy(selectedShoes.ShoeID,Program.CurrentUserID,quantity, selectedShoes.Price);
                if (success)
                {
                    MessageBox.Show("Order confirmed");               
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error occured");
                }
            }

        }
    }
}
