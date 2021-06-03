using System;
using System.Linq;
using System.Windows.Forms;
using AutomatedAccountingSystem.BusinessObjects;

namespace AutomatedAccountingSystem.Helpers
{
    public static class ParseHelper
    {
        public static int? ParseToInt(this string txtNumber)
        {
            return string.IsNullOrEmpty(txtNumber) ? (int?)null : int.Parse(txtNumber);
        }
        public static float? ParseToFloat(this string txtNumber)
        {
            return string.IsNullOrEmpty(txtNumber) ? (float?)null : float.Parse(txtNumber);
        }
        public static string CorrectDateTime(DateTime target)
        {
            return string.Format("{0:yyyy-MM-dd}", target);
        }
        public static string ReplacementPoint(float? target)
        {
            const string nullObject = "0,00";
            var st = target.ToString();

            if (string.IsNullOrEmpty(st) || st == nullObject)
                return "NULL";

            if (!st.Contains(","))
                return st;

            return st.Replace(',', '.');
        }

        public static bool CustomerValidate(Customer customer)
        {
            if (customer.CustomerName.Any(t => t >= '0' && t <= '9') || string.IsNullOrEmpty(customer.CustomerName))
            {
                MessageBox.Show(@"Имя пользователя не должно содержать цифры", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            if (customer.Phone.Any(char.IsLetter))
            {
                MessageBox.Show(@"Номер телефона не должен содержать буквы", @"Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }
    }
}
