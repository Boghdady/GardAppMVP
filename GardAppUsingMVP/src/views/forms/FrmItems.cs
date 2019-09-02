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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(itemPresenter.addItem())
            {
               MessageBox.Show("Done");
            } else
            {
                MessageBox.Show("Error");
            }
        }
    }


}