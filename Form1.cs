using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentBillingSystem
{
    public partial class MainForm : Form
    {
        private readonly BillingSystemEntities _db;
        public MainForm()
        {
            InitializeComponent();
            _db = new BillingSystemEntities();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.Show();
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            AddCustomerName addCustomer = new AddCustomerName();
            
            addCustomer.Show();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Bill]");
        }
    }
}
