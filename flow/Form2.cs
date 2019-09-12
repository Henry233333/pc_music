using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebKit;

namespace flow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WebKit.WebKitBrowser browser = new WebKitBrowser();
            browser.Dock = DockStyle.Fill;
           
            this.panel1.Controls.Add(browser);
            browser.Navigate("http://www.baidu.com");
        }
    }
}
