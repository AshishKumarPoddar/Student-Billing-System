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
    public partial class AddCustomerName : Form
    {
        private readonly BillingSystemEntities _db;
        public string CustomerName;
        public string Date;
      
        public AddCustomerName()
        {
            InitializeComponent();
            _db = new BillingSystemEntities();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
           
            CustomerName = tbCustomerName.Text;
            Date = dtDate.Text;
            GenerateBill generateBill = new GenerateBill(this);
            generateBill.Show();
            this.Close();

           
          
        }

        public decimal TotalBill()
        {
            decimal sum = 0;
           var bill = _db.Bills.Select(q => new {Price = q.Item.PriceofItem.Price , Quentity = q.Quantity}).ToList();
           
            
            foreach(var b in bill)
              {
                
                sum = sum +b.Price *b.Quentity;
              }
            
            
            return sum;
        }
    }
}
