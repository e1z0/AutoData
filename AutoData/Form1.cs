/* Copyright (c) devnull (justinas@res.lt) 2015.12.04) */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.Linq;

namespace AutoData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string basedir = "\\base";
        string baze;

        private void build_list()
        {
            string appPath = Application.StartupPath + basedir;
            baze = appPath;
            var _assembly = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            this.comboBox1.Items.Clear();
            ArrayList folderiai = new ArrayList();
            foreach (string dir in Directory.GetDirectories(appPath))
            {
                
                // kerpam kelia iki paskutinio katalogo
                folderiai.Add(dir.Remove(0, dir.LastIndexOf('\\') + 1));
            }
            this.comboBox1.DataSource = folderiai;
        }

        private void get_drives()
        {
            comboBox2.DataSource = Environment.GetLogicalDrives();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            build_list();
            get_drives();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string elementas = baze + "\\" + comboBox1.Text + "\\info.xml";
            try
            {
                if (File.Exists(elementas)) {
                    textBox1.Text = "File: "+elementas+ "\r\n";           
                    XElement xml = XElement.Load(elementas);
                    var jobs = xml.Descendants("work");
                    foreach (var p in jobs)
                    {
                       var name = p.Element("name").Value;
                       var description = p.Element("description").Value;
                       var job = p.Element("job").Value;
                       var exec = p.Element("exec").Value;
                       var update = p.Element("update").Value;
                       textBox1.Text = textBox1.Text + "Name: " + name +"\r\nDescription: "+description+"\r\nJobs: "+job+"\r\nExec: "+exec+"\r\nUpdate: "+update;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Failas nerastas");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Information file not found!", "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

            private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException(
                "Source directory does not exist or could not be found: "
                + sourceDirName);
        }

        DirectoryInfo[] dirs = dir.GetDirectories();
        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }


        private void button1_Click(object sender, EventArgs e)
        {
            string elementas = baze + "\\" + comboBox1.Text + "\\info.xml";
            string elemdir = baze + "\\" + comboBox1.Text;
            string drive = comboBox2.Text;
            try
            {
                if (File.Exists(elementas))
                {
                    textBox1.Text = "File: " + elementas + "\r\n";
                    XElement xml = XElement.Load(elementas);
                    var jobs = xml.Descendants("work");
                    foreach (var p in jobs)
                    {
                        var name = p.Element("name").Value;
                        var description = p.Element("description").Value;
                        var job = p.Element("job").Value;
                        var todir = p.Element("todir").Value;
                        var exec = p.Element("exec").Value;
                        var update = p.Element("update").Value;
                        elemdir = elemdir + "\\" + job;
                        if (Directory.Exists(elemdir))
                        {
                            DirectoryCopy(elemdir, comboBox2.Text + todir, true);
                        }
                        if (File.Exists(System.IO.Path.GetDirectoryName(elementas)+"\\"+exec))
                            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(elementas)+"\\"+exec, "\""+System.IO.Path.GetDirectoryName(elementas)+"\\"+job+"\" " +comboBox2.Text + " " +todir);
                    }

                }
                else
                {
                    MessageBox.Show("Information file not found", "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Information file is corrupted!", "FAIL!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright (c) devnull (justinas@res.lt) 2015", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string elementas = baze + "\\" + comboBox1.Text + "\\info.xml";
            if (File.Exists(elementas))
            {
                System.Diagnostics.Process.Start("notepad.exe", elementas);
            }
            else
            {
                // darom shablona jeigu nera esamo failo
                using (StreamWriter sw = new StreamWriter(elementas))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sw.WriteLine("<worklist>");
                    sw.WriteLine("<work>");
                    sw.WriteLine("<name><![CDATA[Pavadinimas]]></name>");
                    sw.WriteLine("<description><![CDATA[Produkto aprasymas]]></description>");
                    sw.WriteLine("<job><![CDATA[katalogo pavadinimas]]></job>");
                    sw.WriteLine("<todir><![CDATA[kur\\deti\\katalogo\\failus]]></todir>");
                    sw.WriteLine("<exec><![CDATA[ar leisti exec.cmd]]></exec>");
                    sw.WriteLine("<update><![CDATA[2015.12.04]]></update>");
                    sw.WriteLine("</work>");
                    sw.WriteLine("</worklist>");

                    sw.Close();
                }
                System.Diagnostics.Process.Start("notepad.exe", elementas);
            }

        }


    }
}