using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinForms
{
    public partial class OrdersForm : Form
    {
        protected readonly IRegistered _reg;

        private List<OrderDTO> _orders;
        public OrdersForm(IRegistered reg)
        {
            InitializeComponent();
            _reg = reg;
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            _orders = _reg.GetUserOrders(Program.CurrentUserID);
            BindingList<OrderDTO> blOrders = new BindingList<OrderDTO>(_orders);
            ordersBindingSource.DataSource = blOrders;

            var currOrder = ordersBindingSource.Current;

            dataGridView1.DataSource = ordersBindingSource;
            bindingNavigator1.BindingSource = ordersBindingSource;
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shoefactoryDataSet.Orders' table. You can move, or remove it, as needed.
           //this.ordersTableAdapter.Fill(this.shoefactoryDataSet.Orders);
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OrderDTO selectedOrder = ordersBindingSource.Current as OrderDTO;

            var message = $"Confirm order: Price: {selectedOrder.Price} Quantity: {selectedOrder.Quantity}";
            var response = MessageBox.Show(message, "Order", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                var success = _reg.CreateOrder(selectedOrder);

                RefreshGrid();
            }

        }
    }
}

