using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Store.Pages.Admin
{
    public partial class WebsiteTraffic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] xPoints = new int[24];
            for (int i = 0; i < xPoints.Count(); i++)
            {
                xPoints[i] = i;
            }
            Chart1.Series[0].Points.DataBindXY(xPoints,
                "hours",
                Global.VisiterCounter,
                "visiterCounter");
            Chart1.Titles.Add("График распределения посещаемости сайта");
            Chart1.Titles[0].Font = new Font("Utopia", 16);
            Chart1.ChartAreas[0].AxisX.Title = "Время[ч]";
            Chart1.ChartAreas[0].AxisY.Title = "Количество посетителей[чел]";
            Chart1.ChartAreas[0].AxisX.TitleFont = new Font("Utopia", 14);
            Chart1.ChartAreas[0].AxisY.TitleFont = new Font("Utopia", 14);
            Chart1.ChartAreas[0].AxisX.Maximum = 24;
            Chart1.ChartAreas[0].AxisX.Minimum = 0;
            Chart1.ChartAreas[0].AxisX.Interval = 2;
            Chart1.Width = 700;
            Chart1.Height = 500;
        }

        protected string GetSiteVisitorsPerDay()
        {
            int counter = Global.VisiterCounter.Sum();
            if (counter > 2 && counter < 4)
            {
                return counter + " человека";
            }
            return counter + " человек";
        }
    }
}