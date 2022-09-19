using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 센서값따로받기
{
    public partial class 드라세나산데리아 : Form
    {
        SerialPort sPort;
        private static double xCount = 200;

        public 드라세나산데리아()
        {
            InitializeComponent();
            chartsetting();
        }

        private void chartsetting()
        {
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add("draw");
            chart1.ChartAreas["draw"].AxisX.Minimum = 0;
            chart1.ChartAreas["draw"].AxisX.Maximum = xCount;
            chart1.ChartAreas["draw"].AxisX.Interval = 20;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].AxisY.Minimum = 0;
            chart1.ChartAreas["draw"].AxisY.Maximum = 1050;
            chart1.ChartAreas["draw"].AxisY.Interval = 150;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
            chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas["draw"].BackColor = Color.Navy;

            chart1.ChartAreas["draw"].CursorX.AutoScroll = true;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;

            chart1.Series.Clear();
            chart1.Series.Add("s[1]");
            chart1.Series["s[1]"].ChartType = SeriesChartType.Line;
            chart1.Series["s[1]"].Color = Color.Red;
            chart1.Series["s[1]"].BorderWidth = 3;
            if (chart1.Legends.Count > 0)
                chart1.Legends.RemoveAt(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            sPort = new SerialPort(cb.SelectedItem.ToString());
            //serialPort1.PortName = "COM3";
            //serialPort1.DataReceived += sPort_DataReceived;

        }

        private void sPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string d1 = serialPort1.ReadLine();
                string d2 = serialPort1.ReadLine();
                listBox1.Invoke(new MethodInvoker(delegate { listBox1.Items.Add(d2); }));
            }
        }



        private void 드라세나산데리아_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
            //chartsetting();
            comboBox1.Items.Add("COM3");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = "COM3";
            //if (sPort.IsOpen == NULL) { return; }
            //if (sPort.IsOpen == null) return;
            if (serialPort1.IsOpen)
            {
                //이미 오픈이 되어있으면...
                //아무것도 안함
            }
            else
            {
                //연결이 안되어있으면 연결한다.
                serialPort1.Open();
                serialPort1.DataReceived += sPort_DataReceived;
            }
            //serialPort1.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //이미 오픈이 되어있으면...
                //종료함
                serialPort1.Close();

            }
        }

        
    }
}
