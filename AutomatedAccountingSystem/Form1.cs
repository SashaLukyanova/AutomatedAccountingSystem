using System;
using System.Drawing;
using System.Windows.Forms;
using AutomatedAccountingSystem.Helpers;
using AutomatedAccountingSystem.BusinessObjects;
using System.Collections.Generic;

namespace AutomatedAccountingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.dtgvCattle.Visible = false;
            this.dtgvOrder.Visible = false;
            this.dtgvCustomer.Visible = false;
            this.dtgvMilk.Visible = false;
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.toolStrip.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;

            toolStrip.Location = new Point(203, 0);
            //FormHelper.SetStartButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
            //FormHelper.SetStartViewer(cattleTTReportViewer, milkTTReportViewer, milkReportViewer, orderReportViewer, cattleReportViewer, customerReportViewer);

            AddCustomerGridViewColumns();
            AddMilkGridViewColumns();
            AddCattleGridViewColumns();
            AddOrderGridViewColumns();

            DBHelper.OpenConnectToDataBase();
        }

        public DataGridView GetCustomerGrid()
        {
            return dtgvCustomer;
        }

        public DataGridView GetMilkGrid()
        {
            return dtgvMilk;
        }

        public DataGridView GetCattleGrid()
        {
            return dtgvCattle;
        }

        public DataGridView GetOrderGrid()
        {
            return dtgvOrder;
        }

        public List<Customer> GetCustomerList()
        {
            var list = new List<Customer>();
            var customer = new Customer();
            for (int i = 0; i < dtgvCustomer.RowCount - 1; i++)
            {
                customer.CustomerId = Convert.ToInt32(dtgvCustomer["CustomerId", i].Value);
                customer.CustomerName = dtgvCustomer["colCustomerName", i].Value.ToString();
                list.Add(customer);
            }
            return list;
        }
        public List<Cattle> GetCattleList()
        {
            var list = new List<Cattle>();
            var cattle = new Cattle();
            for (int i = 0; i < dtgvCustomer.RowCount - 1; i++)
            {
                cattle.CattleId = Convert.ToInt32(dtgvCattle["CattleId", i].Value);
                cattle.ObjectsGroup = dtgvCattle["colObjectsGroup", i].Value.ToString();
                list.Add(cattle);
            }
            return list;
        }
        
        
        #region Buttons actions
        private void CustomersButton_Click(object sender, EventArgs e)
        {
            this.dtgvCattle.Visible = false;
            this.dtgvMilk.Visible = false;
            this.dtgvOrder.Visible = false;
            this.dtgvCustomer.Visible = true;
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;
            //FormHelper.HideReportChildButtons(cattleTTButton, milkTTBatton, milkReportButton, 
            //    orderReportButton, cattleReportButton, customerReportButton);
 
            //FormHelper.SetStartButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
            this.toolStrip.Visible = true;
            this.nameLabel.Text = CustomersButton.Text;
            
            CustomerDbOperations.AddDataTables();
            CustomerDbOperations.FillCustomersWithActualData(this.dtgvCustomer);

            foreach (var row in this.dtgvCustomer.Columns)
            {
                var column = row as DataGridViewColumn;
                if (column.Name == "CustomerId")
                    column.Visible = false;
            }
        }
                
        private void ProductsButton_Click(object sender, EventArgs e)
        {
            this.dtgvCattle.Visible = false;
            this.dtgvMilk.Visible = false;
            this.dtgvOrder.Visible = false;
            this.dtgvCustomer.Visible = false;
            this.toolStrip.Visible = false;
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;
            //FormHelper.HideReportChildButtons(cattleTTButton, milkTTBatton, milkReportButton, 
            //    orderReportButton, cattleReportButton, customerReportButton);

            if (this.dtgvMilk.Visible || this.dtgvCattle.Visible)
            {
                //FormHelper.SetStartButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
                this.toolStrip.Visible = true;
                return;
            }

            //FormHelper.SetProductsButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
            
        }

        private void OrdersButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;
            this.dtgvCattle.Visible = false;
            this.dtgvOrder.Visible = true;
            this.dtgvCustomer.Visible = false;
            this.dtgvMilk.Visible = false;            

            this.toolStrip.Visible = true;
            this.nameLabel.Text = OrdersButton.Text;
            
            //FormHelper.HideReportChildButtons(cattleTTButton, milkTTBatton, milkReportButton, 
            //    orderReportButton, cattleReportButton, customerReportButton);

            //FormHelper.SetOrdersButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
                    
            OrderDbOperations.AddDataTables();
            OrderDbOperations.FillOrdersWithActualData(this.dtgvOrder);

            foreach (var row in this.dtgvOrder.Columns)
            {
                var column = row as DataGridViewColumn;
                if (column.Name == "OrderId" || column.Name == "Product" || column.Name == "colCustomer")
                    column.Visible = false;
            }
        }

        private void CattleButton_Click(object sender, EventArgs e)
        {
            this.dtgvCattle.Visible = true;
            this.dtgvOrder.Visible = false;
            this.dtgvCustomer.Visible = false;
            this.dtgvMilk.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;
             
            this.toolStrip.Visible = true;
            this.nameLabel.Text = CattleButton.Text;

            CattleDbOperations.AddDataTables();
            CattleDbOperations.FillCattlesWithActualData(this.dtgvCattle);

            foreach (var row in this.dtgvCattle.Columns)
            {
                var column = row as DataGridViewColumn;
                if (column.Name == "CattleId")
                    column.Visible = false;
            }
        }

        private void MilkButton_Click(object sender, EventArgs e)
        {
            this.dtgvCattle.Visible = false;
            this.dtgvOrder.Visible = false;
            this.dtgvCustomer.Visible = false;
            this.dtgvMilk.Visible = true;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;

            this.toolStrip.Visible = true;
            this.nameLabel.Text = MilkButton.Text;

            MilkDbOperations.AddDataTables();
            MilkDbOperations.FillMilkWithActualData(this.dtgvMilk);

            foreach (var row in this.dtgvMilk.Columns)
            {
                var column = row as DataGridViewColumn;
                if (column.Name == "MilkId")
                    column.Visible = false;
            }
        }

        private void allReportsButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            this.dtgvCattle.Visible = false;
            this.dtgvMilk.Visible = false;
            this.dtgvOrder.Visible = false;
            this.dtgvCustomer.Visible = false;
            this.toolStrip.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;

            //if (cattleReportButton.Visible)
            //{
            //    FormHelper.HideReportChildButtons(cattleTTButton, milkTTBatton, milkReportButton,
            //    orderReportButton, cattleReportButton, customerReportButton);
            //    FormHelper.SetStartButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
            //    return;
            //}

            //FormHelper.ShowReportChildButtons(cattleTTButton, milkTTBatton, milkReportButton, 
            //    orderReportButton, cattleReportButton, customerReportButton);
            //FormHelper.SetStartButtons(CustomersButton, ProductsButton, OrdersButton, MilkButton, CattleButton, allReportsButton);
            
        }

        private void cattleTTButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = true;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = true;

            //this.ReportsLabel.Text = "КРС";

            //this.ReportsComboBox.DataSource = this.cattlesReportBindingSource;
            //this.ReportsComboBox.DisplayMember = "ObjectsGroup";
            //this.ReportsComboBox.ValueMember = "CattleId";

            //this.ReportsLabel.Visible = true;
            //this.ReportsComboBox.Visible = true;            
        }
        private void cattleReportButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = true;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;
        }
        private void milkTTBatton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = true;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = true;

            //this.ReportsLabel.Text = "Молоко";
            //this.ReportsComboBox.DataSource = this.milkReportBindingSource;
            //this.ReportsComboBox.DisplayMember = "Class";
            //this.ReportsComboBox.ValueMember = "MilkId";

            //this.ReportsLabel.Visible = true;
            //this.ReportsComboBox.Visible = true;
        }
        private void milkReportButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = true;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = false;
            //this.ReportsLabel.Visible = false;
            //this.ReportsComboBox.Visible = false;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = false;
        }
        private void orderReportButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = true;
            //this.customerReportViewer.Visible = false;
            //this.ReportDateTimePicker1.Visible = true;
            //this.ReportDateTimePicker2.Visible = true;
            //this.ReportLabelPo.Visible = true;
            //this.ReportOkButton.Visible = true;

            //this.ReportsLabel.Text = "Период дат с";
            //this.ReportsLabel.Visible = true;
            //this.ReportsComboBox.Visible = false;
        }
        private void customerReportButton_Click(object sender, EventArgs e)
        {
            //this.cattleTTReportViewer.Visible = false;
            //this.cattleReportViewer.Visible = false;
            //this.milkTTReportViewer.Visible = false;
            //this.milkReportViewer.Visible = false;
            //this.orderReportViewer.Visible = false;
            //this.customerReportViewer.Visible = true;
            //this.ReportDateTimePicker1.Visible = false;
            //this.ReportDateTimePicker2.Visible = false;
            //this.ReportLabelPo.Visible = false;
            //this.ReportOkButton.Visible = true;

            //this.ReportsLabel.Text = "Заказчик";

            //this.ReportsComboBox.DataSource = this.customersReportBindingSource;
            //this.ReportsComboBox.DisplayMember = "CustomerName";
            //this.ReportsComboBox.ValueMember = "CustomerId";

            //this.ReportsLabel.Visible = true;
            //this.ReportsComboBox.Visible = true;
        }
        
        private void newToolButton_Click(object sender, EventArgs e)
        {
            if (dtgvCustomer.Visible)
            {
                var newCustomer = new AccessoryForms.CustomerViewForm {Visible = true};
                newCustomer.ActiveSaveButton();                
            }

            if (dtgvMilk.Visible)
            {
                var newMilk = new AccessoryForms.MilkViewForm { Visible = true };
                newMilk.ActiveSaveButton();                
            }

            if (dtgvCattle.Visible)
            {
                var newCattle = new AccessoryForms.CattleViewForm { Visible = true };
                newCattle.ActiveSaveButton();
            }

            if (dtgvOrder.Visible)
            {
                var newTT1 = new AccessoryForms.TTMilkForm { Visible = true };
                newTT1.ActiveSaveButton();
                
            }
            
        }
        
        private void editToolButton_Click(object sender, EventArgs e)
        {
            if(dtgvCustomer.Visible)
            {
                editToolButton.Enabled = true;
                CustomerDbOperations.ChangeCustomerInformation(this.dtgvCustomer);
            }

            if (dtgvMilk.Visible)
            {               
                MilkDbOperations.ChangeMilkInformation(this.dtgvMilk);
            }

            if (dtgvCattle.Visible)
            {
                CattleDbOperations.ChangeCattleInformation(this.dtgvCattle);                
            }

            if (dtgvOrder.Visible)
            {
                OrderDbOperations.ChangeOrderInformation(this.dtgvOrder);
            }
                        
        }
        
        private void deleteToolButton_Click(object sender, EventArgs e)
        {
            if (this.dtgvCustomer.Visible)
                CustomerDbOperations.DeleteCustomer(dtgvCustomer);

            if (this.dtgvCattle.Visible)
                CattleDbOperations.DeleteCattle(dtgvCattle);

            if (this.dtgvMilk.Visible)
                MilkDbOperations.DeleteMilk(dtgvMilk);

            if (this.dtgvOrder.Visible)
                OrderDbOperations.DeleteOrder(dtgvOrder);
        }
        #endregion

        private void AddCustomerGridViewColumns()
        {
            var colCustomerName = new DataGridViewTextBoxColumn();
            var colPhone = new DataGridViewTextBoxColumn();
            var colAddress = new DataGridViewTextBoxColumn();
            // 
            // colCustomerName
            // 
            colCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colCustomerName.DataPropertyName = "CustomerName";
            colCustomerName.HeaderText = "Имя";
            colCustomerName.Name = "colCustomerName";
            colCustomerName.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "Телефон";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colAddress.DataPropertyName = "Address";
            colAddress.HeaderText = "Адрес";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;

            this.dtgvCustomer.Columns.AddRange(new DataGridViewColumn[] {
            colCustomerName,
            colPhone,
            colAddress});
        }

        private void AddCattleGridViewColumns()
        {
            var colObjectsGroup = new DataGridViewTextBoxColumn();
            var colLiveWeight = new DataGridViewTextBoxColumn();
            var colAge = new DataGridViewTextBoxColumn();
            var colFatness = new DataGridViewTextBoxColumn();
            var colInventoryNum = new DataGridViewTextBoxColumn();
            var colNumber = new DataGridViewTextBoxColumn();
            var colPrice = new DataGridViewTextBoxColumn();            
            // 
            // colObjectsGroup
            // 
            colObjectsGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colObjectsGroup.DataPropertyName = "ObjectsGroup";
            colObjectsGroup.HeaderText = "Вид животных и птиц";
            colObjectsGroup.Name = "colObjectsGroup";
            colObjectsGroup.ReadOnly = true;
            // 
            // colLiveWeight
            // 
            colLiveWeight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colLiveWeight.DataPropertyName = "LiveWeight";
            colLiveWeight.HeaderText = "Живая масса, кг";
            colLiveWeight.Name = "colLiveWeight";
            colLiveWeight.ReadOnly = true;
            // 
            // colAge
            // 
            colAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colAge.DataPropertyName = "Age";
            colAge.HeaderText = "Возраст";
            colAge.Name = "colAge";
            colAge.ReadOnly = true;
            // 
            // colFatness
            // 
            colFatness.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colFatness.DataPropertyName = "Fatness";
            colFatness.HeaderText = "Упитанность";
            colFatness.Name = "colFatness";
            colFatness.ReadOnly = true;
            // 
            // colInventoryNum
            // 
            colInventoryNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colInventoryNum.DataPropertyName = "InventoryNum";
            colInventoryNum.HeaderText = "Инвентарный номер";
            colInventoryNum.Name = "colInventoryNum";
            colInventoryNum.ReadOnly = true;
            // 
            // colNumber
            // 
            colNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colNumber.DataPropertyName = "Number";
            colNumber.HeaderText = "Число голов";
            colNumber.Name = "colNumber";
            colNumber.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Цена, тыс.руб";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;

            this.dtgvCattle.Columns.AddRange(new DataGridViewColumn[] {
            colObjectsGroup,
            colLiveWeight,
            colAge,
            colFatness,
            colInventoryNum,
            colNumber,
            colPrice});
            
        }

        private void AddOrderGridViewColumns()
        {
            var colRate = new DataGridViewTextBoxColumn();
            var colTransportOwner = new DataGridViewTextBoxColumn();
            var colWaybill = new DataGridViewTextBoxColumn();
            var colDriver = new DataGridViewTextBoxColumn();
            var colClient = new DataGridViewTextBoxColumn();
            var colShipper = new DataGridViewTextBoxColumn();
            var colContract = new DataGridViewTextBoxColumn();
            var colDateContract = new DataGridViewTextBoxColumn();
            var colDateShipping = new DataGridViewTextBoxColumn();
            var colCustomer = new DataGridViewTextBoxColumn();
            var colAuto = new DataGridViewTextBoxColumn();
            var colTypeTransporation = new DataGridViewTextBoxColumn();
            var colConsignee = new DataGridViewTextBoxColumn();
            var colLoadingPoint = new DataGridViewTextBoxColumn();
            var colShippingPoint = new DataGridViewTextBoxColumn();
            var colTrailer = new DataGridViewTextBoxColumn();
            var colGarage = new DataGridViewTextBoxColumn();
            var colRoute = new DataGridViewTextBoxColumn();
            var colProduct = new DataGridViewTextBoxColumn();
            // 
            // colProduct
            // 
            colProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colProduct.DataPropertyName = "Product";
            colProduct.HeaderText = "Продукт";
            colProduct.Name = "colProduct";
            colProduct.ReadOnly = true;
            // 
            // colRate
            // 
            colRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colRate.DataPropertyName = "Rate";
            colRate.HeaderText = "Ставка НДС, %";
            colRate.Name = "colRate";
            colRate.ReadOnly = true;
            // 
            // colTransportOwner
            // 
            colTransportOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colTransportOwner.DataPropertyName = "TransportOwner";
            colTransportOwner.HeaderText = "Владелец транспорта";
            colTransportOwner.Name = "colTransportOwner";
            colTransportOwner.ReadOnly = true;
            colTransportOwner.Visible = false;
            // 
            // colWaybill
            // 
            colWaybill.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colWaybill.DataPropertyName = "Waybill";
            colWaybill.HeaderText = "Путевой лист";
            colWaybill.Name = "colWaybill";
            colWaybill.ReadOnly = true;
            // 
            // colDriver
            // 
            colDriver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colDriver.DataPropertyName = "Driver";
            colDriver.HeaderText = "Водитель";
            colDriver.Name = "colDriver";
            colDriver.ReadOnly = true;
            colDriver.Visible = false;
            // 
            // colClient
            // 
            colClient.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colClient.DataPropertyName = "Client";
            colClient.HeaderText = "Заказчик(плательщик)";
            colClient.Name = "colClient";
            colClient.ReadOnly = true;
            colClient.Visible = false;
            // 
            // colShipper
            // 
            colShipper.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colShipper.DataPropertyName = "Shipper";
            colShipper.HeaderText = "Грузоотправитель";
            colShipper.Name = "colShipper";
            colShipper.ReadOnly = true;
            // 
            // colContract
            // 
            colContract.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colContract.DataPropertyName = "Contract";
            colContract.HeaderText = "Договор";
            colContract.Name = "colContract";
            colContract.ReadOnly = true;
            colContract.Visible = false;
            // 
            // colDateContract
            // 
            colDateContract.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colDateContract.DataPropertyName = "DateContract";
            colDateContract.HeaderText = "Дата договора";
            colDateContract.Name = "colDateContract";
            colDateContract.ReadOnly = true;
            // 
            // colDateShipping
            // 
            colDateShipping.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colDateShipping.DataPropertyName = "DateShipping";
            colDateShipping.HeaderText = "Дата отгрузки";
            colDateShipping.Name = "colDateShipping";
            colDateShipping.ReadOnly = true;
            colDateShipping.Visible = false;
            // 
            // colCustomer
            // 
            colCustomer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colCustomer.DataPropertyName = "Customer";
            colCustomer.HeaderText = "Заказчик";
            colCustomer.Name = "colCustomer";
            colCustomer.ReadOnly = true;
            colCustomer.Visible = true;
            // 
            // colAuto
            // 
            colAuto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colAuto.DataPropertyName = "Auto";
            colAuto.HeaderText = "Автомобиль";
            colAuto.Name = "colAuto";
            colAuto.ReadOnly = true;
            colAuto.Visible = false;
            // 
            // colTypeTransporation
            // 
            colTypeTransporation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colTypeTransporation.DataPropertyName = "TypeTransporation";
            colTypeTransporation.HeaderText = "Вид перевозки";
            colTypeTransporation.Name = "colTypeTransporation";
            colTypeTransporation.ReadOnly = true;
            colTypeTransporation.Visible = false;
            // 
            // colConsignee
            // 
            colConsignee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colConsignee.DataPropertyName = "Consignee";
            colConsignee.HeaderText = "Грузополучатель";
            colConsignee.Name = "colConsignee";
            colConsignee.ReadOnly = true;
            // 
            // colLoadingPoint
            // 
            colLoadingPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colLoadingPoint.DataPropertyName = "LoadingPoint";
            colLoadingPoint.HeaderText = "Пункт погрузки";
            colLoadingPoint.Name = "colLoadingPoint";
            colLoadingPoint.ReadOnly = true;
            // 
            // colShippingPoint
            // 
            colShippingPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colShippingPoint.DataPropertyName = "ShippingPoint";
            colShippingPoint.HeaderText = "Пункт разгрузки";
            colShippingPoint.Name = "colShippingPoint";
            colShippingPoint.ReadOnly = true;
            // 
            // colTrailer
            // 
            colTrailer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colTrailer.DataPropertyName = "Trailer";
            colTrailer.HeaderText = "Прицеп";
            colTrailer.Name = "colTrailer";
            colTrailer.ReadOnly = true;
            // 
            // colGarage
            // 
            colGarage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colGarage.DataPropertyName = "Garage";
            colGarage.HeaderText = "Гар.№";
            colGarage.Name = "colGarage";
            colGarage.ReadOnly = true;
            // 
            // colRoute
            // 
            colRoute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colRoute.DataPropertyName = "Route";
            colRoute.HeaderText = "Маршрут";
            colRoute.Name = "colRoute";
            colRoute.ReadOnly = true;


            this.dtgvOrder.Columns.AddRange(new DataGridViewColumn[] {            
            //colOrderId,
            colRate,
            colTransportOwner,
            colWaybill,
            colDriver,
            colClient,
            colShipper,
            colContract,
            colDateContract,
            colDateShipping,
            colCustomer,
            colAuto,
            colTypeTransporation,
            colConsignee,
            colLoadingPoint,
            colShippingPoint,
            colTrailer,
            colGarage,
            colRoute });
        }

        private void AddMilkGridViewColumns()
        {
            var colClass = new DataGridViewTextBoxColumn();
            var colDensity = new DataGridViewTextBoxColumn();
            var colFatContent = new DataGridViewTextBoxColumn();
            var colAcidity = new DataGridViewTextBoxColumn();
            var colTemperature = new DataGridViewTextBoxColumn();
            var colPacking = new DataGridViewTextBoxColumn();
            var colSeats = new DataGridViewTextBoxColumn();
            var colGrossmass = new DataGridViewTextBoxColumn();
            var colNetMass = new DataGridViewTextBoxColumn();
            var colTareMass = new DataGridViewTextBoxColumn();
            var colBucterial = new DataGridViewTextBoxColumn();
            var colBaseMass = new DataGridViewTextBoxColumn();
            var colPrice = new DataGridViewTextBoxColumn();
            var colGroupPurity = new DataGridViewTextBoxColumn();
            // 
            // colClass
            // 
            colClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colClass.DataPropertyName = "Class";
            colClass.HeaderText = "Сорт";
            colClass.Name = "colClass";
            colClass.ReadOnly = true;
            // 
            // colDensity
            // 
            colDensity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colDensity.DataPropertyName = "Density";
            colDensity.HeaderText = "Плотность";
            colDensity.Name = "colDensity";
            colDensity.ReadOnly = true;
            // 
            // colFatContent
            // 
            colFatContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colFatContent.DataPropertyName = "FatContent";
            colFatContent.HeaderText = "Содержание жира, %";
            colFatContent.Name = "colFatContent";
            colFatContent.ReadOnly = true;
            // 
            // colAcidity
            // 
            colAcidity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colAcidity.DataPropertyName = "Acidity";
            colAcidity.HeaderText = "Кислотность, градусов";
            colAcidity.Name = "colAcidity";
            colAcidity.ReadOnly = true;
            // 
            // colTemperature
            // 
            colTemperature.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colTemperature.DataPropertyName = "Temperature";
            colTemperature.HeaderText = "Температура, градусов";
            colTemperature.Name = "colTemperature";
            colTemperature.ReadOnly = true;
            colTemperature.Visible = false;
            // 
            // colPacking
            // 
            colPacking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colPacking.DataPropertyName = "Packing";
            colPacking.HeaderText = "Вид упаковки";
            colPacking.Name = "colPacking";
            colPacking.ReadOnly = true;
            // 
            // colSeats
            // 
            colSeats.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colSeats.DataPropertyName = "Seats";
            colSeats.HeaderText = "Количество мест";
            colSeats.Name = "colSeats";
            colSeats.ReadOnly = true;
            colSeats.Visible = false;
            // 
            // colGrossmass
            // 
            colGrossmass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colGrossmass.DataPropertyName = "Grossmass";
            colGrossmass.HeaderText = "Брутто";
            colGrossmass.Name = "colGrossmass";
            colGrossmass.ReadOnly = true;
            colGrossmass.Visible = false;
            // 
            // colNetMass
            // 
            colNetMass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colNetMass.DataPropertyName = "NetMass";
            colNetMass.HeaderText = "Нетто";
            colNetMass.Name = "colNetMass";
            colNetMass.ReadOnly = false;
            colNetMass.Visible = false;
            // 
            // colTareMass
            // 
            colTareMass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colTareMass.DataPropertyName = "TareMass";
            colTareMass.HeaderText = "Тара";
            colTareMass.Name = "colTareMass";
            colTareMass.ReadOnly = true;
            colTareMass.Visible = false;
            // 
            // colBucterial
            // 
            colBucterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colBucterial.DataPropertyName = "Bucterial";
            colBucterial.HeaderText = "Бактериальная обсемененность";
            colBucterial.Name = "colBucterial";
            colBucterial.ReadOnly = true;
            colBucterial.Visible = false;
            // 
            // colBaseMass
            // 
            colBaseMass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colBaseMass.DataPropertyName = "BaseMass";
            colBaseMass.HeaderText = "Масса при базисной жирности, кг";
            colBaseMass.Name = "colBaseMass";
            colBaseMass.ReadOnly = true;
            colBaseMass.Visible = false;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Цена";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            colPrice.Visible = false;
            // 
            // colGroupPurity
            // 
            colGroupPurity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            colGroupPurity.DataPropertyName = "GroupPurity";
            colGroupPurity.HeaderText = "Группа чистоты";
            colGroupPurity.Name = "colGroupPurity";
            colGroupPurity.ReadOnly = true;

            this.dtgvMilk.Columns.AddRange(new DataGridViewColumn[] {            
                colClass ,
                colDensity,
                colFatContent,
                colAcidity,
                colTemperature,
                colPacking,
                colSeats,
                colGrossmass,
                colNetMass,
                colTareMass,
                colBucterial,
                colBaseMass,
                colPrice,
                colGroupPurity
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //comboBox
            //this.milkReportTableAdapter.Fill(this.milkReportWorkDBDataSet.Milk);
            //this.customersReportTableAdapter.Fill(this.customerReportWorkDBDataSet.Customers);
            //this.cattlesReportTableAdapter.Fill(this.cattleReportWorkDBDataSet.Cattles);
            //milkReportViewer                    
            this.MilkTableAdapter.Fill(this.MilkDataSet.Milk);
            //this.milkReportViewer.RefreshReport();
            //orderReportViewer
            this.OrdersTableAdapter.Fill(this.OrderDataSet.Orders);
            //this.orderReportViewer.RefreshReport();
            //cattleRepoptViewer
            this.CattlesTableAdapter.Fill(this.CattleDataSet.Cattles);
            //this.cattleReportViewer.RefreshReport();
            //customerReportViewer
            //this.customerReportViewer.RefreshReport();
            //this.milkTTReportViewer.RefreshReport();
            //this.cattleTTReportViewer.RefreshReport();

            //FormHelper.SetStartViewer(cattleTTReportViewer, milkTTReportViewer, milkReportViewer, orderReportViewer, cattleReportViewer, customerReportViewer);
            
        }

        private void ReportOkButton_Click(object sender, EventArgs e)
        {
            //if (this.orderReportViewer.Visible)
            //{
            //    var date1 = DateTime.Parse(this.ReportDateTimePicker1.Text);
            //    var date2 = DateTime.Parse(this.ReportDateTimePicker2.Text);
            //    var date3 = ParseHelper.CorrectDateTime(date1);
            //    var date4 = ParseHelper.CorrectDateTime(date2);
            //    if (date1 > date2)
            //    {
            //        MessageBox.Show(@"Неправильно задан промежуток времени.", @"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    this.OrdersTableAdapter.FillDate(this.OrderDataSet.Orders, date3, date4);
            //    this.orderReportViewer.RefreshReport();
            //}

            //if (this.customerReportViewer.Visible)
            //{
            //    var data = (int)ReportsComboBox.SelectedValue;
                
            //    this.OrdersTableAdapter.FillCustomerId(this.OrderDataSet.Orders, data);
            //    this.customerReportViewer.RefreshReport();
            //}

            //if (this.milkTTReportViewer.Visible)
            //{
            //    var data = (int)ReportsComboBox.SelectedValue;

            //    this.MilkTableAdapter.FillById(this.MilkDataSet.Milk, data);
            //    this.milkTTReportViewer.RefreshReport();
            //}

            //if (this.cattleTTReportViewer.Visible)
            //{
            //    var data = (int)ReportsComboBox.SelectedValue;

            //    this.CattlesTableAdapter.FillById(this.CattleDataSet.Cattles, data);
            //    this.cattleTTReportViewer.RefreshReport();
            //}
        }
               
    }
}
