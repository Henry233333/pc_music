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
            Console.Write(alluse_data.create_net_create);
        }
        string modName = "";
        public void getdata(string info, string lowcasename)
        {
            modName = lowcasename;
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
            string name = "delay-L0";
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
            string name = "delay-L0";
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
        //gain界面方法
        public int set_gain_enable(int enable) {
            IntPtr ins = alluse_data.create_net_create;
            string name = "gain-L0";
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
            string name = "gain-L0";
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
            string name = "gain-L0";
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
        //noisegate界面方法
        public int set_noisegt_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = "ngt-L0";
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
            string name = "ngt-L0";
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_noisegt(ins, name, enable,threshold,att_time,rea_time,avg_time);
                Console.WriteLine(isSet);
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
        //RMS-level界面方法
        //暂无
        //peak-level界面方法
        public int set_peak_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = "peak-L0";
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
            string name = "peak-L0";
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_level(ins, name, enable, att_time, rea_time);
                Console.WriteLine(isSet);
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
        //xover界面方法
        public int set_xover_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = "hpf-L0";
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
            string name = "hpf-L0";
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_xover(ins, name, enable, type, func, fc, slope);
                Console.WriteLine(isSet);
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
        //compr界面方法
        public int set_compr_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = "compr-L0";
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
            string name = "compr-L0";
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_compressor(ins, name, enable, att_time, rea_time, threshold, ratio);
                Console.WriteLine(isSet);
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
        //limiter界面方法
        public int set_limiter_enable(int enable)
        {
            IntPtr ins = alluse_data.create_net_create;
            string name = "lmt-L0";
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
            string name = "lmt-L0";
            if (ins != null)
            {
                int isSet = audioaef_net_dll.net_audioaef_set_limiter(ins, name, enable, att_time, rea_time, threshold);
                Console.WriteLine(isSet);
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
        //ldeq界面方法
        //fir界面方法
        
    }
}
