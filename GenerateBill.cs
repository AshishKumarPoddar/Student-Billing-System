using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentBillingSystem
{
    public partial class GenerateBill : Form
    {
        private AddCustomerName _cn;
        private readonly BillingSystemEntities _db;
        public GenerateBill(AddCustomerName cn)
        {
            InitializeComponent();
            _cn = cn;
            _db = new BillingSystemEntities();

            var t = _cn.TotalBill();
            lbltotal.Text = "$" + t.ToString();
            lblCustumoerName.Text = _cn.CustomerName;
            lblDate.Text = _cn.Date;
            Random r = new Random();
            int n = r.Next(9999999);

            lblBillNo.Text = n  + "";

            CustomerDetail cd = new CustomerDetail();
            cd.CustomerName = _cn.CustomerName;
            cd.TotalBill = t;
            _db.CustomerDetails.Add(cd);
            _db.SaveChanges();

            //var bi = new Bill();
            //var z = bi.Item.PriceofItem.Price;
            

        }

        private void GenerateBill_Load(object sender, EventArgs e)
        {
            var cust = _db.Bills.Select(q => new { ItemSelected = q.Item.ItemName,
                Priece = q.Item.PriceofItem.Price,
                Quentity = q.Quantity, 
                TotalPrice = q.Item.PriceofItem.Price * q.Quantity })
                .ToList();
            gvGenerateBill.DataSource = cust; 
        }

        private void GenerateBill_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Bill]");
        }
    }
}
