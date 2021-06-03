using System;
using System.Windows.Forms;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.Helpers;
using AutomatedAccountingSystem;

namespace AutomatedAccountingSystem.AccessoryForms
{
    public partial class CustomerViewForm : Form
    {
        public Customer Customer
        {
            get
            {
                return new Customer
                {
                    CustomerName = textBox1.Text,
                    Phone = textBox2.Text,
                    Address = richTextBox1.Text
                };
            }
        }
        public CustomerViewForm()
        {
            InitializeComponent();
        }
        
        public void AccessToTextBox(string text1, string text2, string richText1)
        {
            this.textBox1.Text = text1;
            this.textBox2.Text = text2;
            this.richTextBox1.Text = richText1;
        }

        public void ActiveSaveButton()
        {
            this.saveButton.Click += new System.EventHandler(this.saveCustomerButton_Click);
        }

        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            CustomerDbOperations.AddNewCustomer(this.Customer, mainForm.GetCustomerGrid());
            this.Close();
        }
        
        //private void saveButton_Click(object sender, EventArgs e)
        //{
        //    this.StartPosition = FormStartPosition.CenterParent;
            

        //    if (!ValidateInputInfo())
        //    {
        //        DialogResult = DialogResult.OK;
        //        DBHelper.AddNewCustomer(this.Customer);
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Введите корректные данные.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        ////для SetError вместо textBox1 нужно завести окошко
        //private bool ValidateInputInfo()
        //{
        //    if (!string.IsNullOrEmpty(textBox1.Text)) return false;
        //    MessageBox.Show("Для сохранения введите данные клиента.");
        //    return true;
        //}

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
