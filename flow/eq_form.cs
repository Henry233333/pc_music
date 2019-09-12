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
    public partial class eq_form : Form
    {
        public eq_form()
        {
            InitializeComponent();
        }
        public IntPtr eq_create;
        private void eq_form_Load(object sender, EventArgs e)
        {
             eq_create = mydll.effectRespCurv_create(8, 2000, 48000, 0);
        }
        
        public void get_eq(string info, string pagekey)
        {

            Console.WriteLine(info);
            string pageinfo = info;
            string pagekeys = pagekey;
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
        public String get_dataY(float gain, float q, float freq)
        {
           
            String list= "[";
            float[] ResponseMagdB = new float[2000];
            mydll.effectRespCurv_add_bqf(eq_create, 0);
            mydll.effectRespCurv_set_bqf_enable(eq_create, 0,1);
            mydll.effectRespCurv_set_bqf(eq_create, 0, 1, 9, gain, q, freq);  
            int line =   mydll.effectRespCurv_get_line(eq_create, ResponseMagdB);
           
            //mydll.effectRespCurv_get_nodeline(eq_create, 0, ResponseMagdB);
            for (int i = 0; i < ResponseMagdB.Length; i++)
            {  
                list += "'" + (float)ResponseMagdB[i] + "'" + ",";
            }
            list += "]";

            
            
            return list;
        }


        private void eq_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            mydll.effectRespCurv_destroy(eq_create);
        }
        public double get_ponitX(float freq)
        { 
            double point_x = 0;
            point_x = (Math.Log10(freq) - 1) * 2000 / 3.301;
            Console.Write(point_x);
            return point_x;
        }
    }
}
