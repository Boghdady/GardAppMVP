using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using GardAppUsingMVP.src.views.interfaces;
using GardAppUsingMVP.src.logic.presenters;

namespace GardAppUsingMVP.src.views.forms
{
    public partial class FrmItems : DevExpress.XtraEditors.XtraForm, ItemInterface
    {
        string defaultLang = Properties.Settings.Default.langauge;
        ItemPresenter itemPresenter;

        public FrmItems()
        {
            // set default language 
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(defaultLang);
            InitializeComponent();

            itemPresenter = new ItemPresenter(this);
        }

        public int ID { get => Convert.ToInt32(txtID.Text); set => txtID.Text = value.ToString(); }
        public string ItemName { get => txtItemName.Text; set => txtItemName.Text = value; }
        public decimal ItemQty { get => nudItemQTY.Value; set => nudItemQTY.Value = value; }
        public object DgvDataSource { get => dgvItems.DataSource; set => dgvItems.DataSource = value; }
        public object CbxDataSource { get => cbxTypes.DataSource; set => cbxTypes.DataSource=value; }
        public string DisplayMember { get => cbxTypes.DisplayMember; set => cbxTypes.DisplayMember = value; }
        public string ValueMember { get => cbxTypes.ValueMember; set => cbxTypes.ValueMember = value; }

        private void FrmItems_Load(object sender, EventArgs e)
        {
            itemPresenter.getAllItemsPresenter();
            itemPresenter.FillComboBox();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(itemPresenter.addItem())
            {
               MessageBox.Show("Done");
                itemPresenter.getAllItemsPresenter();
            } else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (itemPresenter.deleteAllItems())
            {
                MessageBox.Show("Done");
                itemPresenter.getAllItemsPresenter();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            itemPresenter.ClearField();
        }
    }


}