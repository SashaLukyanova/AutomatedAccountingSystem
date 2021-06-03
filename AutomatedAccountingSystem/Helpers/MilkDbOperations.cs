using System.Windows.Forms;
using System.Data;
using AutomatedAccountingSystem.BusinessObjects;
using AutomatedAccountingSystem.AccessoryForms;

namespace AutomatedAccountingSystem.Helpers
{
    public class MilkDbOperations
    {
        public static DataSet MilkDataSet = new DataSet();


        public static void AddDataTables()
        {
            if (!MilkDataSet.Tables.Contains("[WorkDB].[dbo].[Milk]"))
                MilkDataSet.Tables.Add("[WorkDB].[dbo].[Milk]");
        }

        public static void SelectRecordByIndex(int newRowIndex, DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0 && newRowIndex > 0)
            {
                dtgv.Rows[newRowIndex].Selected = true;
                dtgv.FirstDisplayedScrollingRowIndex = newRowIndex >= 5 ? newRowIndex - 5 : 0;
            }
        }
        
        public static void FillMilkWithActualData(DataGridView dtgv)
        {
            MilkDataSet.Tables["[WorkDB].[dbo].[Milk]"].Clear();

            DBHelper.FillMilkWithActualData(MilkDataSet);
            dtgv.DataSource = MilkDataSet.Tables["[WorkDB].[dbo].[Milk]"];
        }
        public static void AddNewMilk(Milk milk, DataGridView dtgv)
        {
            DBHelper.AddNewMilk(milk);
            FillMilkWithActualData(dtgv);
            SelectRecordByIndex(dtgv.Rows.Count - 1, dtgv);
        }

        public static void DeleteMilk(DataGridView dtgv)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить этот объект?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;
            if (dtgv.CurrentRow == null) return;
            var milkId = dtgv["MilkId", dtgv.CurrentRow.Index].Value;
            int selectedItemIndex = dtgv.CurrentRow.Index;

            if (milkId == null) return;
            if(string.IsNullOrEmpty(milkId.ToString())) return;   
 
            DBHelper.DeleteMilk((int)milkId);
            FillMilkWithActualData(dtgv);

            if (selectedItemIndex != -1)
            {
                SelectRecordByIndex(selectedItemIndex - 1, dtgv);
            }
        }

        public static void ChangeMilkInformation(DataGridView dtgv)
        {
            if (dtgv.CurrentRow == null) return;
            var milkId = dtgv["MilkId", dtgv.CurrentRow.Index].Value;

            var milk = DBHelper.GetMilkInfoById((int)milkId);
            var changeMilkInformation = new MilkViewForm {StartPosition = FormStartPosition.CenterParent};            

            var text1 = dtgv["colClass", dtgv.CurrentRow.Index].Value.ToString();
            var text2 = dtgv["colFatContent", dtgv.CurrentRow.Index].Value.ToString();
            var text3 = dtgv["colAcidity", dtgv.CurrentRow.Index].Value.ToString();
            var text4 = dtgv["colTemperature", dtgv.CurrentRow.Index].Value.ToString();
            var text5 = dtgv["colDensity", dtgv.CurrentRow.Index].Value.ToString();
            var text6 = dtgv["colPacking", dtgv.CurrentRow.Index].Value.ToString();
            var text7 = dtgv["colSeats", dtgv.CurrentRow.Index].Value.ToString();
            var text8 = dtgv["colGrossmass", dtgv.CurrentRow.Index].Value.ToString();
            var text9 = dtgv["colTareMass", dtgv.CurrentRow.Index].Value.ToString();
            var text10 = dtgv["colBaseMass", dtgv.CurrentRow.Index].Value.ToString();
            var text11 = dtgv["colBucterial", dtgv.CurrentRow.Index].Value.ToString();
            var text12 = dtgv["colGroupPurity", dtgv.CurrentRow.Index].Value.ToString();
            var text13 = dtgv["colNetMass", dtgv.CurrentRow.Index].Value.ToString();
            var text15 = dtgv["colPrice", dtgv.CurrentRow.Index].Value.ToString();

            changeMilkInformation.AccessToTextBox(text1, text2, text3, text4, text5, text6, text7, text8, text9, text10, text11, text12, text13, text15 );
            
            DialogResult result = changeMilkInformation.ShowDialog();
            if (result == DialogResult.No) return;
            
            var editedMilk = changeMilkInformation.Milk;
            
            if (milk.Bucterial == editedMilk.Bucterial && milk.Acidity == editedMilk.Acidity && milk.BaseMass == editedMilk.BaseMass &&
                    milk.Class == editedMilk.Class && milk.Density == editedMilk.Density && milk.FatContent == editedMilk.FatContent &&
                    milk.Grossmass == editedMilk.Grossmass && milk.GroupPurity == editedMilk.GroupPurity && milk.NetMass == editedMilk.NetMass &&
                    milk.Packing == editedMilk.Packing && milk.Price == editedMilk.Price && milk.Seats == editedMilk.Seats &&
                    milk.TareMass == editedMilk.TareMass && milk.Temperature == editedMilk.Temperature) return;
            
            DBHelper.UpdateDBMilk((int)milkId, editedMilk);

            FillMilkWithActualData(dtgv);
        }
    }
}
