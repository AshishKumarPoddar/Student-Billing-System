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
    public partial class AddItem : Form
    {
        private readonly BillingSystemEntities _db;

        public AddItem()
        {
            InitializeComponent();
            _db = new BillingSystemEntities();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            var item = _db.Items.Select(q => new { Id = q.id, Name = q.ItemName }).ToList();
            cbSelectItem.DisplayMember = "Name";
            cbSelectItem.ValueMember = "Id";
            cbSelectItem.DataSource = item;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var additem = new Bill();
            additem.ItemId = (int)cbSelectItem.SelectedValue;
            additem.Quantity = int.Parse(tbSelectQuantity.Text);

            _db.Bills.Add(additem);
            _db.SaveChanges();
            MessageBox.Show($"You added {tbSelectQuantity.Text} no of {cbSelectItem.Text} ");
            this.Close();
        }
    }
}
