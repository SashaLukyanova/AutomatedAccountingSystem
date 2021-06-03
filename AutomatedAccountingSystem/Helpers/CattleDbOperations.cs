using System;
using System.Windows.Forms;
using System.Data;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.AccessoryForms;

namespace AutomatedAccountingSystem.Helpers
{
    public class CattleDbOperations
    {
        public static DataSet CattlesDataSet = new DataSet();


        public static void AddDataTables()
        {
            if (!CattlesDataSet.Tables.Contains("[WorkDB].[dbo].[Cattles]"))
                CattlesDataSet.Tables.Add("[WorkDB].[dbo].[Cattles]");
        }

        public static void SelectRecordByIndex(int newRowIndex, DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0 && newRowIndex > 0)
            {
                dtgv.Rows[newRowIndex].Selected = true;
                dtgv.FirstDisplayedScrollingRowIndex = newRowIndex >= 5 ? newRowIndex - 5 : 0;
            }
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
       
        public static void FillCattlesWithActualData(DataGridView dtgv)
        {
            CattlesDataSet.Tables["[WorkDB].[dbo].[Cattles]"].Clear();

            DBHelper.FillCattlesWithActualData(CattlesDataSet);
            
            dtgv.DataSource = CattlesDataSet.Tables["[WorkDB].[dbo].[Cattles]"];
        }
        public static void AddNewCattle(Cattle cattle, DataGridView dtgv)
        {
            DBHelper.AddNewCattle(cattle);
            FillCattlesWithActualData(dtgv);
            SelectRecordByIndex(dtgv.Rows.Count - 1, dtgv);
        }

        public static void DeleteCattle(DataGridView dtgv)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить объект?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (dtgv.CurrentRow == null) return;

            var cattleId = dtgv["CattleId", dtgv.CurrentRow.Index].Value;

            if (cattleId == null ||string.IsNullOrEmpty(cattleId.ToString())) return;
            
            DBHelper.DeleteCattle((int)cattleId);
            int selectedItemIndex = dtgv.CurrentRow.Index;
            FillCattlesWithActualData(dtgv);

            if (selectedItemIndex != -1)
            {
                SelectRecordByIndex(selectedItemIndex - 1, dtgv);
            }
        }

        public static void ChangeCattleInformation(DataGridView dtgv)
        {           
            if (dtgv.CurrentRow == null) return;
            var cattleId = dtgv["CattleId", dtgv.CurrentRow.Index].Value;

            var cattle = DBHelper.GetCattleInfoById((int)cattleId);
            var changeCattleInformation = new CattleViewForm {StartPosition = FormStartPosition.CenterParent};
            
            var text1 = dtgv["colLiveWeight", dtgv.CurrentRow.Index].Value.ToString();
            var text2 = dtgv["colAge", dtgv.CurrentRow.Index].Value.ToString();
            var text3 = dtgv["colObjectsGroup", dtgv.CurrentRow.Index].Value.ToString();
            var text4 = dtgv["colInventoryNum", dtgv.CurrentRow.Index].Value.ToString();
            var text5 = dtgv["colFatness", dtgv.CurrentRow.Index].Value.ToString();
            var text6 = dtgv["colNumber", dtgv.CurrentRow.Index].Value.ToString();
            var text7 = dtgv["colPrice", dtgv.CurrentRow.Index].Value.ToString();

            changeCattleInformation.AccessToTextBox(text1, text2, text3, text4, text5, text6, text7);
            
            DialogResult result = changeCattleInformation.ShowDialog();
            if (result == DialogResult.No) return;

            var editedCattle = changeCattleInformation.Cattle;

            if (cattle.Age == editedCattle.Age && cattle.Fatness == editedCattle.Fatness && cattle.InventoryNum == editedCattle.InventoryNum &&
                cattle.LiveWeight == editedCattle.LiveWeight && cattle.Number == editedCattle.Number && cattle.ObjectsGroup == editedCattle.ObjectsGroup &&
                cattle.Price == editedCattle.Price) return;
                
            DBHelper.UpdateDBCattles((int)cattleId, editedCattle);

            FillCattlesWithActualData(dtgv);

                    //var rowIndex = GetRowIndexById((int)cattleId, dtgv);

                    //if (rowIndex != -1)
                    //    SelectRecordByIndex(rowIndex, dtgv);               
            
        }        
    }
}
