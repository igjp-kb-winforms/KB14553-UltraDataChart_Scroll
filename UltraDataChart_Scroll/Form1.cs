using Infragistics.Win.DataVisualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraDataChart_Scroll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var data = new EnergyDataSource();

            var xAxis = new CategoryXAxis
            {
                Label = "Region",
                DataSource = data
            };

            var yAxis1 = new NumericYAxis();
            yAxis1.MinimumValue = 0;
            yAxis1.MaximumValue = 10;

            ColumnSeries series1 = new ColumnSeries();
            series1.XAxis = xAxis;
            series1.YAxis = yAxis1;
            series1.ValueMemberPath = "Value1";
            series1.DataSource = data;

            ultraDataChart1.Axes.Add(xAxis);
            ultraDataChart1.Axes.Add(yAxis1);
            ultraDataChart1.Series.Add(series1);

            ultraDataChart1.HorizontalViewScrollbarMode = SeriesViewerScrollbarMode.Persistent;
            ultraDataChart1.WindowRect = new Infragistics.Win.DataVisualization.Rectangle(0, 0, .2, 1);
        }
    }

    public class EnergyProduction
    {
        public string Region { get; set; }
        public double Value1 { get; set; }
    }

    public class EnergyDataSource : List<EnergyProduction>
    {
        public EnergyDataSource()
        {
            Random rnd = new Random();

            for (int i = 1; i <= 50; i++)
            {
                this.Add(new EnergyProduction { Region = "Region" + i, Value1 = rnd.Next(1, 10) });
            }
        }
    }
}
