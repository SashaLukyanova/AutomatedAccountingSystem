using System.Drawing;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace AutomatedAccountingSystem
{
    public class FormHelper
    {
        public static void SetStartButtons(Button customersButton, Button productsButton, Button ordersButton, Button milkButton, Button cowButton, Button allReportsButton)
        {
            customersButton.Location = new Point(0, 34);
            productsButton.Location = new Point(0, 118);
            ordersButton.Location = new Point(0, 202);
            allReportsButton.Location = new Point(0, 286);

            milkButton.Visible = false;
            cowButton.Visible = false;           
        }

        public static void SetProductsButtons(Button customersButton, Button productsButton, Button ordersButton, Button milkButton, Button cowButton, Button allReportsButton)
        {
            customersButton.Location = new Point(0, 34);     
            productsButton.Location = new Point(0, 118);
            milkButton.Location = new Point(0, 202);
            cowButton.Location = new Point(0, 257);
            ordersButton.Location = new Point(0, 312);
            allReportsButton.Location = new Point(0, 396);

            milkButton.Visible = true;
            cowButton.Visible = true;
        }

        public static void SetOrdersButtons(Button customersButton, Button productsButton, Button ordersButton, Button milkButton, Button cowButton, Button allReportsButton)
        {
            customersButton.Location = new Point(0, 34);
            productsButton.Location = new Point(0, 118);
            ordersButton.Location = new Point(0, 202);
            allReportsButton.Location = new Point(0, 286);

            milkButton.Visible = false;
            cowButton.Visible = false;
        }
        public static void HideReportChildButtons(Button button1, Button button2, Button button3, Button button4, Button button5, Button button6)
        { 
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }
        public static void ShowReportChildButtons(Button button1, Button button2, Button button3, Button button4, Button button5, Button button6)
        {
            button1.Location = new Point(0, 370);
            button2.Location = new Point(0, 425);
            button3.Location = new Point(0, 480);
            button4.Location = new Point(0, 535);
            button5.Location = new Point(0, 590);
            button6.Location = new Point(0, 645);

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }

        public static void SetStartViewer(ReportViewer cattleTTReportViewer, ReportViewer milkTTReportViewer, ReportViewer milkReportViewer, ReportViewer orderReportViewer, ReportViewer cattleReportViewer, ReportViewer customerReportViewer)
        {
            var point = new Point(203, 37);
            var size1 = new Size(868, 752);
            var size2 = new Size(868, 715);
            cattleTTReportViewer.Location = point;
            cattleTTReportViewer.Size = size2;
            milkTTReportViewer.Location = point;
            milkTTReportViewer.Size = size2;
            orderReportViewer.Location = point;
            orderReportViewer.Size = size2;
            customerReportViewer.Location = point;
            customerReportViewer.Size = size2;
            milkReportViewer.Location = new Point(203, 0);
            milkReportViewer.Size = size1;
            cattleReportViewer.Location = new Point(203, 0);
            cattleReportViewer.Size = size1;
        }
              
    }
}
