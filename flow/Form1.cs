using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;



namespace flow
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]

    public partial class Form1 : Form 
    {
        
        public Form1()
        {
            
            InitializeComponent();

        }
        
        
        private void load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (key != null)
            {
                key.SetValue("flow.exe", 11001, RegistryValueKind.DWord);
                key.SetValue("flow.vshost.exe", 11001, RegistryValueKind.DWord);//调试运行需要加上，否则不起作用
            }

            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (key != null)
            {
                key.SetValue("flow.exe", 11001, RegistryValueKind.DWord);
                key.SetValue("flow.vshost.exe", 11001, RegistryValueKind.DWord);//调试运行需要加上，否则不起作用
            }
            
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index.html"; 
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);  

        }

        private void button2_Click(object sender, EventArgs e)
        {
            out_form form2 = new out_form();
            form2.getdata("out_window\\inter_model.html","inter");
            form2.Show();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index_input.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index_eq.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index_fix.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index_xndy.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index_drc.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\index\\index_output.html";
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);
        }

        
            //winform 调用 js 方法
            //this.webBrowser1.Document.InvokeScript("winform_to_js");

        //js 调用的 winform 方法
        public void out_window(string name,string key)
        {
            string LowCaseName = name.ToLower();
            if (LowCaseName == "input" || LowCaseName == "output" || LowCaseName == "asrc" || LowCaseName == "nlp" || LowCaseName == "mixer" || LowCaseName == "deq" || LowCaseName == "demux" )
            {
                return;
            }
            else if (LowCaseName == "peq")
            {
                eq_form form1 = new eq_form();
                form1.get_eq("out_window\\" + LowCaseName + ".html", key); 
                form1.Show();
            }
            else
            {
                out_form form2 = new out_form();
                form2.getdata("out_window\\" + LowCaseName + ".html", key);
                form2.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void get_eq(string info)
        {

            
            string pageinfo = info;
         
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (key != null)
            {
                key.SetValue("flow.exe", 11001, RegistryValueKind.DWord);
                key.SetValue("flow.vshost.exe", 11001, RegistryValueKind.DWord);//调试运行需要加上，否则不起作用
            }

            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (key != null)
            {
                key.SetValue("flow.exe", 11001, RegistryValueKind.DWord);
                key.SetValue("flow.vshost.exe", 11001, RegistryValueKind.DWord);//调试运行需要加上，否则不起作用
            }
            string pathName = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\" + pageinfo;
            this.webBrowser1.ObjectForScripting = this;
            webBrowser1.Navigate(pathName);

        }
        public String get_dataX()
        {
            String list = "[";

            float[] axisX = new float[2000];

            mydll.effectRespCurv_get_axisX(eq_create, axisX);

            //mydll.effectRespCurv_get_nodeline(eq_create, 0, ResponseMagdB);
            for (int i = 0; i < axisX.Length; i++)
            {
                list += "'" + (double)axisX[i] + "'" + ",";

            }
            list += "]";

            return list;
        }

        public IntPtr eq_create;
        //初始化
        public void eq_creates()
        {
            eq_create = mydll.effectRespCurv_create(8, 2000, 48000, 0);
            mydll.effectRespCurv_add_bqf(eq_create, 0);
            mydll.effectRespCurv_add_bqf(eq_create, 1);
            mydll.effectRespCurv_add_bqf(eq_create, 2);
            mydll.effectRespCurv_add_bqf(eq_create, 3);
            mydll.effectRespCurv_add_bqf(eq_create, 4);
            mydll.effectRespCurv_add_bqf(eq_create, 5);
            mydll.effectRespCurv_add_bqf(eq_create, 6);
            mydll.effectRespCurv_add_bqf(eq_create, 7);

        }
        public String get_dataY()
        {

            String list = "[";
            float[] ResponseMagdB = new float[2000];
            int line = mydll.effectRespCurv_get_line(eq_create, ResponseMagdB);
            for (int i = 0; i < ResponseMagdB.Length; i++)
            {
                list += "'" + (float)ResponseMagdB[i] + "'" + ",";
            }
            list += "]";



            return list;
        }

        public int set_node_dataY(int id, int enable, int type, float gain, float q, float freq)
        {
            try
            {
                mydll.effectRespCurv_set_bqf_enable(eq_create, id, enable);
                mydll.effectRespCurv_set_bqf(eq_create, id, enable, type, gain, q, freq);

            }
            catch (Exception)
            {

                return 0;
            }

            return 1;

        }

        public string get_node_dataY(int id)
        {
            String list = "[";
            float[] ResponseMagdB = new float[2000];
            //int line = mydll.effectRespCurv_get_line(eq_create, ResponseMagdB);
            int line = mydll.effectRespCurv_get_nodeline(eq_create, id, ResponseMagdB);
            for (int i = 0; i < ResponseMagdB.Length; i++)
            {
                list += "'" + (float)ResponseMagdB[i] + "'" + ",";
            }
            list += "]";



            return list;
        }

        public double get_ponitX(float freq)
        {
            double point_x = 0;
            point_x = (Math.Log10(freq) - 1) *  2000 / 3.301;
            
            return point_x;
        }
        //读取配置文件
        public List<string> config_list = new List<string>();
        public void load_config(){
            string fileName = string.Empty; //文件名
            //打开文件
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = "conf";
            dlg.Filter = "Conf Files|*.conf";
            if (dlg.ShowDialog() == DialogResult.OK)
                fileName = dlg.FileName;
            if (fileName == null || fileName=="")   
                return;
            //读取文件内容
            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
            String ls_input = sr.ReadToEnd().TrimStart();
            if (!string.IsNullOrEmpty(ls_input)) {
               
                string[] ContentLines = ls_input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ContentLines.Length; i++)
                {
                    if (ContentLines[i].Substring(0,1) == "#") {
                        continue;
                    }
                    config_list.Add(ContentLines[i]);
                }
            } 
            sr.Close();
            alluse_data.flow_config_list = config_list;
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mydll.effectRespCurv_destroy(eq_create);
        }

        public string get_index_flow_item() {
            return alluse_data.flow_item();
        }
        public string get_index_flow_line()
        {
            return alluse_data.flow_line();
        }

    }
}

