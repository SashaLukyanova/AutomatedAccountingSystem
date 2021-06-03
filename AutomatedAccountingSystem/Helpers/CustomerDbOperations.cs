using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.AccessoryForms;

namespace AutomatedAccountingSystem.Helpers
{
    public class CustomerDbOperations
    {
        public static DataSet CustomersDataSet = new DataSet();


        public static void AddDataTables()
        {
            if (!CustomersDataSet.Tables.Contains("[WorkDB].[dbo].[Customers]"))
                CustomersDataSet.Tables.Add("[WorkDB].[dbo].[Customers]");
        }

        public static void SelectRecordByIndex(int newRowIndex, DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0 && newRowIndex > 0)
            {
                dtgv.Rows[newRowIndex].Selected = true;
                dtgv.FirstDisplayedScrollingRowIndex = newRowIndex >= 5 ? newRowIndex - 5 : 0;
            }
        }

        public static void AddNewCustomer(Customer customer, DataGridView dtgv)
        {
            if(ParseHelper.CustomerValidate(customer))
                return;
            DBHelper.AddNewCustomer(customer);
            FillCustomersWithActualData(dtgv);
            SelectRecordByIndex(dtgv.Rows.Count - 1, dtgv);
        }
              
        public static void FillCustomersWithActualData(DataGridView dtgv)
        {
            CustomersDataSet.Tables["[WorkDB].[dbo].[Customers]"].Clear();

            DBHelper.FillCustomersWithActualData(CustomersDataSet);
            dtgv.DataSource = CustomersDataSet.Tables["[WorkDB].[dbo].[Customers]"];
        }
        
        public static void DeleteCustomer(DataGridView dtgv)
        {
            var result = MessageBox.Show(@"Вы действительно хотите удалить этот объект?", @"Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (dtgv.CurrentRow == null) return;
            var customerId = dtgv["CustomerId", dtgv.CurrentRow.Index].Value;
            var selectedItemIndex = dtgv.CurrentRow.Index;

            if (customerId == null) return;
            if (string.IsNullOrEmpty(customerId.ToString())) return;
                
            DBHelper.DeleteCustomer((int)customerId);
            FillCustomersWithActualData(dtgv);

            if (selectedItemIndex != -1)
            {
                SelectRecordByIndex(selectedItemIndex - 1, dtgv);
            }
        }

        public static void ChangeCustomerInformation(DataGridView dtgv)
        {
            if (dtgv.CurrentRow == null) return;
            var customerId = dtgv["CustomerId", dtgv.CurrentRow.Index].Value;
            
            var customer = DBHelper.GetCustomerInfoById((int)customerId);
            var changeCustomerInformation = new CustomerViewForm { StartPosition = FormStartPosition.CenterParent };

            var text1 = dtgv["colCustomerName", dtgv.CurrentRow.Index].Value.ToString();
            var text2 = dtgv["colPhone", dtgv.CurrentRow.Index].Value.ToString();
            var richText1 = dtgv["colAddress", dtgv.CurrentRow.Index].Value.ToString();

            changeCustomerInformation.AccessToTextBox(text1, text2, richText1);

            DialogResult result = changeCustomerInformation.ShowDialog();
            if (result == DialogResult.No) return;

            var editedCustomer = changeCustomerInformation.Customer;

            if (customer.CustomerName == editedCustomer.CustomerName && customer.Phone == editedCustomer.Phone &&
                customer.Address == editedCustomer.Address) return;
            
            DBHelper.UpdateDBCustomers((int)customerId, editedCustomer);

            FillCustomersWithActualData(dtgv);

            //var rowIndex = GetRowIndexById((int)customerId, dtgv);

            //if (rowIndex != -1)
            // SelectRecordByIndex(rowIndex, dtgv);
        }
    }
}
