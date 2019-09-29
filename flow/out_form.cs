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
using System.Runtime.InteropServices;


namespace flow
{

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]
    
    public partial class out_form : Form
    {
        public out_form()
        {
            InitializeComponent();
        }


        
        private void out_form_Load(object sender, EventArgs e)
        {
            
        }
        string modName = "";
        public void getdata(string info, string key_name)
        {
            modName = key_name;
           
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
        //connect界面方法获取IP创建公共连接
        public int getDevice(string ip) {
            int isSet = alluse_data.create_net_audioaef(ip);
           
            if (isSet == 0) {
                return 0;
            }
            return 1;
        }
        //delay界面方法
        public int set_delay_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_delay_enable(ins, name, enable);
                if (isSet == 0)
               {
                   return 1;
               }
               else {
                   return 0;
               }
            }
            return 0;
        }
        public int set_delay_time(float time)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_delay_time(ins, name, time);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_delay()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            int enable = 0;
            float time = 0;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_get_delay(ins, name,ref enable,ref time);
                if (isSet == 0)
                {
                    data += "'" + enable + "'" + ",";
                    data += "'" + time + "'";
                    data += "]";
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        //gain界面方法
        public int set_gain_enable(int enable) {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_gain_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_gain_value(float value) {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_gain_gain(ins, name, value);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_gain_mute(int mute) {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_gain_mute(ins, name, mute);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_gain()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            int enable = 0;
            float gaindB = 0;
            int mute = 0;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_get_gain(ins, name, ref enable, ref gaindB, ref mute);
                if (isSet == 0)
                {
                    data += "'" + enable + "'" + ",";
                    data += "'" + gaindB + "'" + ",";
                    data += "'" + mute + "'";
                    data += "]";
                    
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }   
        //noisegate界面方法
        public int set_noisegt_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_noisegt_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_noisegt_value(int enable,float threshold, float att_time, float rea_time, float avg_time)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_noisegt(ins, name, enable,threshold,att_time,rea_time,avg_time);
               
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_noisegt()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            int enable = 0;
            float threshold = 0, att_time = 0, rea_time = 0, avg_time = 0;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_get_noisegt(ins, name, ref enable, ref att_time, ref rea_time, ref threshold, ref avg_time);          
                if (isSet == 0)
                {
                    data += "'" + enable + "'" + ",";
                    data += "'" + threshold + "'" + ",";
                    data += "'" + att_time + "'" + ",";
                    data += "'" + rea_time + "'" + ",";
                    data += "'" + avg_time + "'";
                    data += "]";
                   
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        //RMS-level界面方法
        //暂无
        //peak-level界面方法
        public int set_peak_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_level_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_peak_value(int enable, float att_time, float rea_time)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_level(ins, name, enable, att_time, rea_time);
               
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_peak()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            int enable = 0;
            float att_time = 0, rea_time = 0;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_get_levelConfig(ins, name, ref enable, ref att_time, ref rea_time);
                if (isSet == 0)
                {
                    data += "'" + enable + "'" + ",";         
                    data += "'" + att_time + "'" + ",";
                    data += "'" + rea_time + "'";
                    data += "]";
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        //xover界面方法
        public int set_xover_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                
                int isSet = audioaef_net_dll.net_audioaef_set_xover_enable(ins, name, enable);

                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_xover_value(int enable,int type, int func, float fc, int slope)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_xover(ins, name, enable, type, func, fc, slope);
               
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_xover_value()
        {
            IntPtr ins = alluse_data.create_net_create;
            
            string name = modName;
            string xover_data = "[";
            int enable = 0;
            int type=0;
            int func=0;
            float fc=0;
            int slope=0;
            if (ins != null)
            {
                
                int isSet = audioaef_net_dll.net_audioaef_get_xover(ins, name, ref enable, ref type, ref func, ref fc, ref slope);
                
                if (isSet == 0)
                {
                    xover_data += "'" + enable + "'" + ",";
                    xover_data += "'" + type + "'" + ",";
                    xover_data += "'" + func + "'" + ",";
                    xover_data += "'" + fc + "'" + ",";
                    xover_data += "'" + slope + "'";
                    xover_data += "]";
                    return xover_data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        //compr界面方法
        public int set_compr_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_compressor_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_compr_value(int enable, float att_time, float rea_time, float threshold, float ratio)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null) 
            {
                int isSet = audioaef_net_dll.net_audioaef_set_compressor(ins, name, enable, att_time, rea_time, threshold, ratio);
               
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_compr()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            int enable = 0;
            float att_time = 0, rea_time = 0, threshold = 0, ratio = 0;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_get_compressor(ins, name, ref enable, ref att_time, ref rea_time, ref threshold, ref ratio);
                if (isSet == 0)
                {
                    data += "'" + enable + "'" + ",";
                    data += "'" + att_time + "'" + ",";
                    data += "'" + rea_time + "'" + ",";
                    data += "'" + threshold + "'" + ",";
                    data += "'" + ratio + "'";
                    data += "]";
                   
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        //limiter界面方法
        public int set_limiter_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_limiter_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int set_limiter_value(int enable, float att_time, float rea_time, float threshold)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_limiter(ins, name, enable, att_time, rea_time, threshold);
               
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public string get_limiter()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            int enable = 0;
            float att_time = 0, rea_time = 0, threshold = 0;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_get_limiter(ins, name, ref enable, ref att_time, ref rea_time, ref threshold);
                if (isSet == 0)
                {
                    data += "'" + enable + "'" + ",";
                    data += "'" + att_time + "'" + ",";
                    data += "'" + rea_time + "'" + ",";
                    data += "'" + threshold + "'";
                    data += "]";
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }
        
        //ldeq界面方法
        public int set_ldeq_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_loudeq_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }


        public string get_ldeq_options()
        {
            IntPtr ins = alluse_data.create_net_create;
            Console.WriteLine(ins);
            string name = modName;
            string data = "[";
            String  options = "";
            
            if (ins != null)
            {   
                int isGet = audioaef_net_dll.net_audioaef_get_loudeq_option(ins, ref options);
                Console.WriteLine(isGet);
                if (isGet == 0)
                {
                    Console.WriteLine(options);
                    
                    //for (int i = 0; i < options.Length; i++)
                    //{
                    //    if (i == options.Length - 1) {
                    //        Console.WriteLine(options[i]);
                    //        data += "'" + options[i] + "'";
                    //    }
                    //    data += "'" + options[i] + "'" + ",";
                    //} 
                    data += "]";
                    
                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }

        public string get_ldeq() {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            
            string type = "";
            int enable = 0;
            float time = 0;
            string data = "[";
            int isSet = audioaef_net_dll.net_audioaef_get_loudeq(ins, name,ref enable, ref type, ref time);
            if (isSet == 0)
            {
                data += "'" + enable + "'" + ",";
                data += "'" + type + "'" + ",";
                data += "'" + time + "'";
                data += "]";
                return data;
            }
            else
            {
                return "";
            }
        }
        //fir界面方法
        public int set_fir_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_fir_enable(ins, name, enable);
                if (isSet == 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public string get_fir_options()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string data = "[";
            string[] options = new string[20];

            if (ins != null)
            {
                int isGet = audioaef_net_dll.net_audioaef_get_fir_type_option(ins, ref options);

                if (isGet == 0)
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == options.Length - 1)
                        {
                            data += "'" + options[i] + "'";
                        }
                        data += "'" + options[i] + "'" + ",";
                    }
                    data += "]";

                    return data;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }

        public string get_fir()
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = modName;
            string type = "";
            int enable = 0;
            string data = "[";
            int isSet = audioaef_net_dll.net_audioaef_get_fir(ins, name, ref enable, ref type);
            if (isSet == 0)
            {
                data += "'" + enable + "'" + ",";
                data += "'" + type + "'";
                data += "]";
                return data;
            }
            else
            {
                return "";
            }
        }




        private void out_form_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }

}
