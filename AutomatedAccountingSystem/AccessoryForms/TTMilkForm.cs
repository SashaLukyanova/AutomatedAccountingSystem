using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AutomatedAccountingSystem.Helpers;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.AccessoryForms;
//using System.ComponentModel;

namespace AutomatedAccountingSystem.AccessoryForms
{
    public partial class TTMilkForm : Form
    {
        public TTMilkForm()
        {
            InitializeComponent();

            this.comboBox1.Enabled = true;
            this.comboBox2.Enabled = true;
            this.comboBox3.Enabled = true;
        }

        public OrderMilk OrderMilk
        {
            get
            {
                return new OrderMilk
                {
                    OrderId = Order.OrderId,
                    MilkId = (int)comboBox1.SelectedValue
                };
            }
        }

        public OrderCattle OrderCattle
        {
            get
            {
                return new OrderCattle
                {
                    OrderId = Order.OrderId,
                    CattleId = (int)comboBox2.SelectedValue
                };
            }
        }

        public Order Order
        {
            get
            {
                var order = new Order
                {
                    TransportOwner = textBox2.Text,
                    Auto = textBox3.Text,
                    Waybill = textBox4.Text,
                    Driver = textBox5.Text,
                    TypeTransporation = textBox6.Text,
                    Shipper = textBox8.Text,
                    Consignee = textBox9.Text,
                    LoadingPoint = textBox10.Text,
                    ShippingPoint = textBox11.Text,
                    Route = textBox12.Text,
                    Contract = textBox13.Text,
                    Trailer = textBox14.Text,
                    Garage = textBox15.Text,
                    Rate = textBox16.Text.ParseToFloat(),
                    DateContract = DateTime.Parse(dateTimePicker1.Text),
                    DateShipping = DateTime.Parse(dateTimePicker2.Text)
                };

                order.Customer = (int)comboBox3.SelectedValue;
                if(checkBox1.Checked)
                    order.Product = (int)comboBox1.SelectedValue;
                if (checkBox2.Checked)
                    order.Product = (int)comboBox2.SelectedValue;
                
                return order;
            }
        }

        public void AccessToTextBox(string text2, string text3, string text4, string text5, string text6, 
            string text8, string text9, string text10, string text11, string text12, string text13, string text14,
            string text15, string text16, string dateTime1, string dateTime2)//, string comboBox, string comboBox3)
        {    
            this.textBox2.Text = text2;
            this.textBox3.Text = text3;
            this.textBox4.Text = text4;
            this.textBox5.Text = text5;
            this.textBox6.Text = text6;
            this.textBox8.Text = text8;
            this.textBox9.Text = text9;
            this.textBox10.Text = text10;
            this.textBox11.Text = text11;
            this.textBox12.Text = text12;
            this.textBox13.Text = text13;
            this.textBox14.Text = text14;
            this.textBox15.Text = text15;
            this.textBox16.Text = text16;
            this.dateTimePicker1.Text = dateTime1;
            this.dateTimePicker2.Text = dateTime2;
            this.comboBox1.Enabled = false;
            this.comboBox2.Enabled = false;
            this.comboBox3.Enabled = false;
            //this.comboBox3.Text = comboBox3;
            //if(this.checkBox1.Checked)
            //this.comboBox1.Text = comboBox;
            //if (this.checkBox2.Checked)
            //this.comboBox2.Text = comboBox;            
        }

        public void ActiveSaveButton()
        {
            this.button1.Click += new System.EventHandler(this.saveButton_Click);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            OrderDbOperations.AddNewOrder(this.Order, mainForm.GetOrderGrid());

            if (this.checkBox1.Checked)
                DBHelper.AddNewOrderMilk(this.OrderMilk);
            if (this.checkBox2.Checked)
                DBHelper.AddNewOrderCattle(this.OrderCattle);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TTMilkForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'customerMainWorkDBDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersMainTableAdapter.Fill(this.customerMainWorkDBDataSet.Customers);
            // TODO: This line of code loads data into the 'cattleMainWorkDBDataSet.Cattles' table. You can move, or remove it, as needed.
            this.cattlesMainTableAdapter.Fill(this.cattleMainWorkDBDataSet.Cattles);
            // TODO: This line of code loads data into the 'milkMainWorkDBDataSet.Milk' table. You can move, or remove it, as needed.
            this.milkMainTableAdapter.Fill(this.milkMainWorkDBDataSet.Milk);
                        
        }
        
        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.CheckState = CheckState.Unchecked;
            checkBox1.CheckState = CheckState.Checked;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.CheckState = CheckState.Unchecked;
            checkBox2.CheckState = CheckState.Checked;
        }

    }
}
