using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMS
{
    public partial class HomePage : Form
    {
        const string cwbAPI = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-063?Authorization=CWB-B0D98AF2-68FB-4F37-B601-17A669CED731&locationName=大安區&elementName=MinT,MaxT,PoP12h,Wx";
        //const string cwbAPI = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?&Authorization=CWB-B0D98AF2-68FB-4F37-B601-17A669CED731";
        JArray jsondata = getJson(cwbAPI);

        public HomePage()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.tabControl1.DrawItem += this.tabControl1_DrawItem;
            //tabControl改側邊 > Alignment:Left > SizeMode:Fixed > 修改 ItemSize
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //LoadWeather(jsondata);//
        }

        string[] time = new string[3]; //時間區段
        string[] weathdescrible = new string[3]; //天氣狀況
        string[] pop = new string[3]; //降雨機率
        string[] mintemperature = new string[3]; //最低溫度
        string[] maxtemperature = new string[3]; //最高溫度
        private void LoadWeather(JArray jsondata)
        {
            foreach (JObject data in jsondata)
            {
                for (int i = 0; i <5 ; i++)
                {
                    time[i] = (string)data["weatherElement"][0]["time"][i]["startTime"] + "-" + ((string)data["weatherElement"][0]["time"][i]["endTime"]).Substring(11);
                    //time[i] = (string)data["weatherElement"][0]["time"][i]["startTime"] + "-" + ((string)data["weatherElement"][0]["time"][i]["endTime"]).Substring(11);
                    //weathdescrible[i] = (string)data["weatherElement"][0]["time"][i]["parameter"]["parameterName"];
                    //pop[i] = (string)data["weatherElement"][1]["time"][i]["parameter"]["parameterName"];
                    //mintemperature[i] = (string)data["weatherElement"][2]["time"][i]["parameter"]["parameterName"];
                    //maxtemperature[i] = (string)data["weatherElement"][4]["time"][i]["parameter"]["parameterName"];
                    //
                }                
            }
            for (int i = 0; i < 3; i++) //顯示 3 個時段天氣資料
            {
                //this.textBox1.Text += time[i] + " 天氣:" + weathdescrible[i].PadRight(8, '　') + " 溫度:" + mintemperature[i] + "°c-" + maxtemperature[i] + "°c 降雨機率:" + pop[i] + "%" + Environment.NewLine;
                this.textBox1.Text += time[i] + Environment.NewLine;
            }
            this.textBox1.Text += Environment.NewLine;
        }

        static public JArray getJson(string uri) //向中央氣象局取得 36 小時天氣資料
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri); //request請求
            req.Timeout = 10000; //request逾時時間
            req.Method = "GET"; //request方式
            HttpWebResponse respone = (HttpWebResponse)req.GetResponse(); //接收respone
            StreamReader streamReader = new StreamReader(respone.GetResponseStream(), Encoding.UTF8); //讀取respone資料
            string result = streamReader.ReadToEnd(); //讀取到最後一行
            respone.Close();
            streamReader.Close();
            JObject jsondata = JsonConvert.DeserializeObject<JObject>(result); //將資料轉為json物件
            return (JArray)jsondata["records"]["location"]; //回傳json陣列
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);
            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Visible = false;
            lg.ShowDialog();
            this.Dispose();
            this.Close();
        }
    }
}
