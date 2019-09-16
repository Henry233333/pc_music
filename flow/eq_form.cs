﻿using System;
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
       
        private void eq_form_Load(object sender, EventArgs e)
        {
            eq_creates();
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

        public IntPtr eq_create;
        //初始化
        private void eq_creates()
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
           
            String list= "[";
            float[] ResponseMagdB = new float[2000];         
            int line =   mydll.effectRespCurv_get_line(eq_create, ResponseMagdB);  
            for (int i = 0; i < ResponseMagdB.Length; i++)
            {  
                list += "'" + (float)ResponseMagdB[i] + "'" + ",";
            }
            list += "]";

            
            
            return list;
        }

        public int set_node_dataY(int id,int enable,int type , float gain, float q, float freq)
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
