using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoData
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string configas;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            XElement xml = XElement.Load(configas);
            var jobs = xml.Descendants("work");
            foreach (var p in jobs)
            {
                textBox1.Text = p.Element("name").Value;
                textBox2.Text = p.Element("description").Value;
                textBox3.Text = p.Element("job").Value;
                textBox4.Text = p.Element("todir").Value;
                textBox5.Text = p.Element("exec").Value;
                textBox6.Text = p.Element("update").Value;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(configas))
            {
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                sw.WriteLine("<worklist>");
                sw.WriteLine("<work>");
                sw.WriteLine("<name><![CDATA["+this.textBox1.Text+"]]></name>");
                sw.WriteLine("<description><![CDATA["+this.textBox2.Text+"]]></description>");
                sw.WriteLine("<job><![CDATA["+this.textBox3.Text+"]]></job>");
                sw.WriteLine("<todir><![CDATA["+this.textBox4.Text+"]]></todir>");
                sw.WriteLine("<exec><![CDATA["+this.textBox5.Text+"]]></exec>");
                sw.WriteLine("<update><![CDATA["+this.textBox6.Text+"]]></update>");
                sw.WriteLine("</work>");
                sw.WriteLine("</worklist>");
                sw.Close();
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
    }
}
