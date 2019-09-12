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
        public void out_window(string name, string pagekey)
        {
            Console.WriteLine(name);
            string LowCaseName = name.ToLower();
            if (LowCaseName == "input" || LowCaseName == "output" || LowCaseName == "asrc" || LowCaseName == "nlp" || LowCaseName == "mixer" || LowCaseName == "deq" || LowCaseName == "demux" )
            {
                return;
            }
            else if (LowCaseName == "peq")
            {
                eq_form form1 = new eq_form();
                form1.get_eq("out_window\\" + LowCaseName + ".html", pagekey);
                form1.Show();
            }
            else
            {
                out_form form2 = new out_form();
                form2.getdata("out_window\\" + LowCaseName + ".html", pagekey);
                form2.Show();
            }
        } 
       
       
    }
}

