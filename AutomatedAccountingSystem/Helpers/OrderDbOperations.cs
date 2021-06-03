using System.Windows.Forms;
using System.Data;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.AccessoryForms;

namespace AutomatedAccountingSystem.Helpers
{
    public class OrderDbOperations
    {
        public static DataSet OrdersDataSet = new DataSet();


        public static void AddDataTables()
        {
            if (!OrdersDataSet.Tables.Contains("[WorkDB].[dbo].[Orders]"))
                OrdersDataSet.Tables.Add("[WorkDB].[dbo].[Orders]");
        }

        public static void SelectRecordByIndex(int newRowIndex, DataGridView dtgv)
        {
            if (dtgv.Rows.Count <= 0 || newRowIndex <= 0) return;
            dtgv.Rows[newRowIndex].Selected = true;
            dtgv.FirstDisplayedScrollingRowIndex = newRowIndex >= 5 ? newRowIndex - 5 : 0;
        }
        public static int GetRowIndexById(int id, DataGridView dtgv)
        {
            foreach (DataGridViewRow row in dtgv.Rows)
            {
                if ((int)row.Cells[0].Value == id)
                    return row.Index;
            }

            return -1;
        }
        public static void Change(DataGridView dtgv)
        {
            for (int i = 0; i < dtgv.RowCount - 1; i++)
            {
                var st = dtgv["Product", i].Value;

            }
        }
        public static void FillOrdersWithActualData(DataGridView dtgv)
        {
            OrdersDataSet.Tables["[WorkDB].[dbo].[Orders]"].Clear();

            DBHelper.FillOrdersWithActualData(OrdersDataSet);
            dtgv.DataSource = OrdersDataSet.Tables["[WorkDB].[dbo].[Orders]"];

            Change(dtgv);
        }
        public static void AddNewOrder(Order order, DataGridView dtgv)
        {
            DBHelper.AddNewOrder(order);
            FillOrdersWithActualData(dtgv);
            SelectRecordByIndex(dtgv.Rows.Count - 1, dtgv);
        }

        public static void DeleteOrder(DataGridView dtgv)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить абоенента и все его книги?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (dtgv.CurrentRow == null) return;
            var orderId = dtgv["OrderId", dtgv.CurrentRow.Index].Value;
            var selectedItemIndex = dtgv.CurrentRow.Index;

            if (string.IsNullOrEmpty(orderId.ToString())) return;

            DBHelper.DeleteOrder((int)orderId);
            FillOrdersWithActualData(dtgv);

            if (selectedItemIndex != -1)
            {
                SelectRecordByIndex(selectedItemIndex - 1, dtgv);
            }
        } 

        public static void ChangeOrderInformation(DataGridView dtgv)
        {
            if (dtgv.CurrentRow == null) return;
            var orderId = dtgv["OrderId", dtgv.CurrentRow.Index].Value;

            var order = DBHelper.GetOrderInfoById((int)orderId);
            var changeOrderInformation = new TTMilkForm {StartPosition = FormStartPosition.CenterParent};
            
            var text2 = dtgv["colTransportOwner", dtgv.CurrentRow.Index].Value.ToString();
            var text3 = dtgv["colAuto", dtgv.CurrentRow.Index].Value.ToString();
            var text4 = dtgv["colWaybill", dtgv.CurrentRow.Index].Value.ToString();
            var text5 = dtgv["colDriver", dtgv.CurrentRow.Index].Value.ToString();
            var text6 = dtgv["colTypeTransporation", dtgv.CurrentRow.Index].Value.ToString();
            var text8 = dtgv["colShipper", dtgv.CurrentRow.Index].Value.ToString();
            var text9 = dtgv["colConsignee", dtgv.CurrentRow.Index].Value.ToString();
            var text10 = dtgv["colLoadingPoint", dtgv.CurrentRow.Index].Value.ToString();
            var text11 = dtgv["colShippingPoint", dtgv.CurrentRow.Index].Value.ToString();
            var text12 = dtgv["colRoute", dtgv.CurrentRow.Index].Value.ToString();
            var text13 = dtgv["colContract", dtgv.CurrentRow.Index].Value.ToString();
            var text14 = dtgv["colTrailer", dtgv.CurrentRow.Index].Value.ToString();
            var text15 = dtgv["colGarage", dtgv.CurrentRow.Index].Value.ToString();
            var text16 = dtgv["colRate", dtgv.CurrentRow.Index].Value.ToString();
            var dateTime1 = dtgv["colDateContract", dtgv.CurrentRow.Index].Value.ToString();
            var dateTime2 = dtgv["colDateShipping", dtgv.CurrentRow.Index].Value.ToString();
            //var comboBox3 = dtgv["colCustomer", dtgv.CurrentRow.Index].Value.ToString();
            //var comboBox = dtgv["Product", dtgv.CurrentRow.Index].Value.ToString();

            changeOrderInformation.AccessToTextBox(text2, text3, text4, text5, text6, text8, text9, text10, text11, text12, text13, text14, text15, text16, dateTime1, dateTime1);//, comboBox, comboBox3);
            
            DialogResult result = changeOrderInformation.ShowDialog();
            if (result == DialogResult.No) return;
            
            var editedOrder = changeOrderInformation.Order;
            
            if (order.Auto == editedOrder.Auto && order.Consignee == editedOrder.Consignee && order.Contract == editedOrder.Contract && order.DateContract == editedOrder.DateContract &&
                    order.DateShipping == editedOrder.DateShipping && order.Driver == editedOrder.Driver && order.Garage == editedOrder.Garage && order.LoadingPoint == editedOrder.LoadingPoint &&
                    order.Rate == editedOrder.Rate && order.Route == editedOrder.Route && order.Shipper == editedOrder.Shipper && order.ShippingPoint == editedOrder.ShippingPoint &&
                    order.Trailer == editedOrder.Trailer && order.TransportOwner == editedOrder.TransportOwner && order.TypeTransporation == editedOrder.TypeTransporation &&
                    order.Waybill == editedOrder.Waybill) return;// && order.Customer == editedOrder.Customer && order.Product == editedOrder.Product) return;
            
            DBHelper.UpdateDBOrders((int)orderId, editedOrder);

            FillOrdersWithActualData(dtgv);
             
        }
    }
}    
