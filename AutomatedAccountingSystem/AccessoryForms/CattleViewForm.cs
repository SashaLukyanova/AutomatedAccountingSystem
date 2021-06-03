using System;
using System.Windows.Forms;
using AutomatedAccountingSystem.Helpers;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.AccessoryForms;

namespace AutomatedAccountingSystem.AccessoryForms
{
    public partial class CattleViewForm : Form
    {
        public CattleViewForm()
        {
            InitializeComponent();
        }
        public Cattle Cattle
        {
            get
            {
                return new Cattle
                {
                    ObjectsGroup = textBox3.Text,
                    LiveWeight = textBox1.Text.ParseToFloat(),
                    Age = textBox2.Text.ParseToFloat(),
                    Fatness = textBox5.Text,
                    InventoryNum = textBox4.Text.ParseToFloat(),
                    Number = textBox6.Text.ParseToInt(),
                    Price = textBox7.Text.ParseToFloat()
                };
            }
        }

        public void AccessToTextBox(string text1, string text2, string text3, string text4, string text5, string text6, string text7)
        {
            this.textBox1.Text = text1;
            this.textBox2.Text = text2;
            this.textBox3.Text = text3;
            this.textBox4.Text = text4;
            this.textBox5.Text = text5;
            this.textBox6.Text = text6;
            this.textBox7.Text = text7;            
        }

        public void ActiveSaveButton()
        {
            this.button1.Click += new System.EventHandler(this.saveButton_Click);            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            CattleDbOperations.AddNewCattle(this.Cattle, mainForm.GetCattleGrid());
            this.Close();
        }
              
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
