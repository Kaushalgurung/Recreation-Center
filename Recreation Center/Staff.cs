﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recreation_Center
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }


        private void StaffLogoutbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to logout?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login lf = new Login();
                lf.Show();
            }
        }
        public void clear()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currenttimelbl.Text = DateTime.Now.ToLongTimeString();
            this.checkin.Text = DateTime.Now.ToString("hh:mm");
        }
        protected override void OnClosed(EventArgs e)
        {
            if (MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login lf = new Login();
                lf.Show();
            }
        }  

        private void getprice_Click(object sender, EventArgs e)
        {
            try
            {
                InsertValuesToTable();
                MessageBox.Show("Price Data Exported!", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Coudn't get price information !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InsertValuesToTable()                          // Enters  price data to Table
        {
            Price p = new Price();
            List<Price> Pricelist = p.List();
            DataTable dataTable = Tools.ToTable(Pricelist);
            pricedataGridView.DataSource = dataTable;                                       // Source is given as datatable which contains all the price rate
        }

        private void InsertVisitorsValueToTable()
        {
            Visitors v = new Visitors();
            List<Visitors> listVisitors = v.List();
            DataTable dataTable = Tools.ToTable(listVisitors);
            VisitordataGridView.DataSource = dataTable;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (indivisualcheck.Checked)
            {
                this.grouptxt.Text = "0";
                grouptxt.ReadOnly = true;
            }
            else
            {
                this.grouptxt.Text = "";
                grouptxt.ReadOnly = false;
            }
        }
    }
}
