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
        //save flow
        public int saveFlow(string flowtext) {
            string[] ContentLines = flowtext.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string newS = "";
            for (int i = 0; i < ContentLines.Length; i++)
            {
                newS += new System.Text.RegularExpressions.Regex("[\\s]+").Replace(ContentLines[i], " ")+"\r\n";
            }
            
            //生成flow.config
            // 利用SaveFileDialog，让用户指定文件的路径名
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Conf Files|*.conf";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                // 创建文件，将textBox1中的内容保存到文件中
                // saveDlg.FileName 是用户指定的文件路径
                FileStream fs = File.Open(saveDlg.FileName,
                    FileMode.Create,
                    FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                // 保存textBox1中所有内容（所有行）
                sw.WriteLine(newS);

                //关闭文件
                sw.Flush();
                sw.Close();
                fs.Close();
                // 提示用户：文件保存的位置和文件名
                return 1;
            }
            return 0;
            
        }

        //save parms
        public int saveParms(string title_list)
        {
            string[] strArray = title_list.Split(',');
            string parms_text = " "+"\r\n";
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == "") {
                    continue;
                }
                string[] title_name = strArray[i].Split('/');
                string ss = title_name[1].ToLower();
                if (ss == "input")
                {
                    string last = title_name[0].Substring(title_name[0].Length - 1, 1);
                    if (last == "0") {
                        parms_text += title_name[0] + " ON system-in-left" + "\r\n";
                    }
                    else if (last == "1")
                    {
                        parms_text += title_name[0] + " ON system-in-right" + "\r\n";
                    }
                    else {
                        parms_text += title_name[0] + " ON" + "\r\n";
                    }
                }
                else if (ss == "output")
                {
                    string last = title_name[0].Substring(title_name[0].Length - 1, 1);
                    if (last == "0")
                    {
                        parms_text += title_name[0] + " ON system-out-left" + "\r\n";
                        parms_text += "\r\n";
                    }
                    else if (last == "1")
                    {
                        parms_text += title_name[0] + " ON system-out-right" + "\r\n";
                        parms_text += "\r\n";
                    }
                    else {
                        parms_text += title_name[0] + " ON" + "\r\n";
                        parms_text += "\r\n";
                    }
                }
                else {
                    string parms_itmes = get_parms_text(ss, title_name[0]);
                    parms_text += parms_itmes + "\r\n";
                }
            }
           
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Conf Files|*.conf";
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.Open(saveDlg.FileName,
                    FileMode.Create,
                    FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(parms_text);
                sw.Flush();
                sw.Close();
                fs.Close();
                return 1;
            }
            return 0;
        }

        private string get_parms_text(string item,string modname){
            IntPtr ins = alluse_data.create_net_create;
            if (ins == null) {
                return "";
            }
            if (item == "noisegate")
            {
                int enable = 0;
                float threshold = 0, att_time = 0, rea_time = 0, avg_time = 0;
                int isSet = audioaef_net_dll.net_audioaef_get_noisegt(ins, modname, ref enable, ref att_time, ref rea_time, ref threshold, ref avg_time);
                if (isSet == 0)
                {
                    string ret_text = modname + " ";
                    if (enable == 1) { ret_text += "NO "; } else { ret_text += "OFF "; };
                    ret_text += att_time + " " + rea_time + " "+threshold + " " + avg_time;
                    return ret_text;
                }
                else {
                    return "";
                }
            }
            if (item == "gain")
            {
                int enable = 0;
                float gaindB = 0;
                int mute = 0;
                int isSet = audioaef_net_dll.net_audioaef_get_gain(ins, modname, ref enable, ref gaindB, ref mute);
                if (isSet == 0)
                {
                    string ret_text = modname + " ";
                    if (enable == 1) { ret_text += "NO "; } else { ret_text += "OFF "; };
                    ret_text += gaindB + " ";
                    if (mute == 1) { ret_text += "NO -90 0"; } else { ret_text += "OFF -90 0"; }
                    return ret_text;
                }
                else {
                    return "";
                }
            }
            if (item == "peq")
            {
                int eq_item_num = 8;
                string ret_text ="";
                for (int i = 0; i < eq_item_num; i++)
                {
                    int  enable =0 ,type=0;
                    float gain=0,q=0,freq=0;   
                    int isget = audioaef_net_dll.net_audioaef_get_peq_bqf(ins, modname, i, ref enable, ref type, ref gain, ref q, ref freq);
                    if (isget == 0)
                    {
                        ret_text += modname + " " + i + " ";
                        if (type == 0) { ret_text += "AP1 "; }
                        else if (type == 1) { ret_text += "LP1 "; }
                        else if (type == 2) { ret_text += "HP1 "; }
                        else if (type == 3) { ret_text += "LS1 "; }
                        else if (type == 4) { ret_text += "HS1 "; }
                        else if (type == 5) { ret_text += "LP2 "; }
                        else if (type == 6) { ret_text += "HP2 "; }
                        else if (type == 7) { ret_text += "LS2 "; }
                        else if (type == 8) { ret_text += "HS2 "; }
                        else if (type == 9) { ret_text += "PEAK "; }
                        else if (type == 10) { ret_text += "NOTCH "; }
                        else if (type == 11) { ret_text += "AP2 "; }
                        else if (type == 12) { ret_text += "BP2 "; }
                        else if (type == 13) { ret_text += "BP2_0GAIN "; }
                        ret_text += gain + " " + q + " " + freq+"\r\n";
                    }
                }
                return ret_text;

            }
            if (item == "ldeq")
            {
                int enable = 0;
                string type = "";
                float time = 0;
                int isSet = audioaef_net_dll.net_audioaef_get_loudeq(ins, modname,ref enable, ref type, ref time);
                if (isSet == 0)
                {
                    string ret_text = modname + " ";
                    if (enable == 1) { ret_text += "NO "; } else { ret_text += "OFF "; };
                    ret_text += type + " " + time;
                    return ret_text;
                }
                else
                {
                    return "";
                }
            }
            if (item == "xover")
            {
                int enable = 0;
                int type = 0;
                int func = 0;
                float fc = 0;
                int slope = 0;
                int isSet = audioaef_net_dll.net_audioaef_get_xover(ins, modname, ref enable, ref type, ref func, ref fc, ref slope);
                if (isSet == 0)
                {
                    string ret_text = modname + " ";
                    if (enable == 1) { ret_text += "NO "; } else { ret_text += "OFF "; };
                    if (type == 0) { ret_text += "LP "; } else { ret_text += "HP "; };
                    ret_text +=fc+ " ";
                    if (func == 0) { ret_text += "BUTTERWOTH "; } else { ret_text += "LINKREILY "; };
                    if (slope == 0) { ret_text += "SLOPE_6 "; }
                    else if (slope == 1) { ret_text += "SLOPE_12 "; }
                    else if (slope == 2) { ret_text += "SLOPE_18 "; }
                    else if (slope == 3) { ret_text += "SLOPE_24 "; }
                    else if (slope == 4) { ret_text += "SLOPE_30 "; }
                    else if (slope == 5) { ret_text += "SLOPE_36 "; }
                    else if (slope == 6) { ret_text += "SLOPE_48 "; }        
                    return ret_text;

                }
                else {
                    return "";
                }
            }
            if (item == "compr")
            {
                int enable = 0;
                float att_time = 0, rea_time = 0, threshold = 0, ratio = 0;
                int isSet = audioaef_net_dll.net_audioaef_get_compressor(ins, modname, ref enable, ref att_time, ref rea_time, ref threshold, ref ratio);
                if (isSet == 0)
                {
                    string ret_text = modname + " ";
                    if (enable == 1) { ret_text += "NO "; } else { ret_text += "OFF "; };
                    ret_text += att_time + " " + rea_time + " " + threshold + " " + ratio;
                    return ret_text;
                }
                else
                {
                    return "";
                }
            }
            if (item == "limiter")
            {
                int enable = 0;
                float att_time = 0, rea_time = 0, threshold = 0;
                int isSet = audioaef_net_dll.net_audioaef_get_limiter(ins, modname, ref enable, ref att_time, ref rea_time, ref threshold);
                if (isSet == 0)
                {
                    string ret_text = modname + " ";
                    if (enable == 1) { ret_text += "NO "; } else { ret_text += "OFF "; };
                    ret_text += att_time + " " + rea_time + " " + threshold;
                    return ret_text;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }

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

        public string get_config_end_text() {
            string endText = alluse_data.flow_config_text_end();
            return endText;
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
       
        //读取配置文件
        
        public void load_config(){
             List<string> config_list = new List<string>();
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
            
        }

        public string get_index_flow_item() {
            return alluse_data.flow_item();
        }
        public string get_index_flow_line()
        {
            return alluse_data.flow_line();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.comboBox1.Text;
            if (text == "48k") {
                alluse_data.caiyang = 48000;
            }
            else if (text == "44.1k") {
                alluse_data.caiyang = 44100;
            }
        }
        //index_eq方法
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

            IntPtr ins = alluse_data.create_net_create;
            
           

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



        public IntPtr eq_create;
        //初始化
        public void distory_creates()
        {
            mydll.effectRespCurv_destroy(eq_create);
            IntPtr ins = alluse_data.create_net_create;
           
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
        public void eq_creates()
        {
            int caryang = alluse_data.caiyang;
            eq_create = mydll.effectRespCurv_create(8, 2000, caryang, 0);
            mydll.effectRespCurv_add_bqf(eq_create, 0);
            mydll.effectRespCurv_add_bqf(eq_create, 1);
            mydll.effectRespCurv_add_bqf(eq_create, 2);
            mydll.effectRespCurv_add_bqf(eq_create, 3);
            mydll.effectRespCurv_add_bqf(eq_create, 4);
            mydll.effectRespCurv_add_bqf(eq_create, 5);
            mydll.effectRespCurv_add_bqf(eq_create, 6);
            mydll.effectRespCurv_add_bqf(eq_create, 7);
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

    }
}

