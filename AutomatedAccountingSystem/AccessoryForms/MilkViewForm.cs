using System;
using System.Windows.Forms;
using AutomatedAccountingSystem.Helpers;
using AutomatedAccountingSystem.BusinessObjects;

namespace AutomatedAccountingSystem.AccessoryForms
{
    public partial class MilkViewForm : Form
    {
        public MilkViewForm()
        {
            InitializeComponent();
        }

        public Milk Milk
        {
            get
            {
                return new Milk
                {
                    Acidity = textBox3.Text.ParseToFloat(),
                    BaseMass = textBox10.Text.ParseToFloat(),
                    Bucterial = textBox11.Text,
                    Class = textBox1.Text,
                    Density = textBox5.Text,
                    FatContent = textBox2.Text.ParseToFloat(),
                    Grossmass = textBox8.Text.ParseToFloat(),
                    GroupPurity = textBox12.Text,
                    NetMass = textBox13.Text.ParseToFloat(),
                    Packing = textBox6.Text,
                    Seats = textBox7.Text.ParseToInt(),
                    TareMass = textBox9.Text.ParseToFloat(),
                    Temperature = textBox4.Text.ParseToFloat(),
                    Price = textBox15.Text.ParseToFloat()
                };
            }
        }

        public void AccessToTextBox(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11, string text12, string text13, string text15)
        {
            this.textBox1.Text = text1;
            this.textBox2.Text = text2;
            this.textBox3.Text = text3;
            this.textBox4.Text = text4;
            this.textBox5.Text = text5;
            this.textBox6.Text = text6;
            this.textBox7.Text = text7;
            this.textBox8.Text = text8;
            this.textBox9.Text = text9;
            this.textBox10.Text = text10;
            this.textBox11.Text = text11;
            this.textBox12.Text = text12;
            this.textBox13.Text = text13;
            this.textBox15.Text = text15;
        }

        public void ActiveSaveButton()
        {
            this.button1.Click += new System.EventHandler(this.saveButton_Click);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            MilkDbOperations.AddNewMilk(this.Milk, mainForm.GetMilkGrid());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
