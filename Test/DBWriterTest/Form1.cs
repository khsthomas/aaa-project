using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using AAA.AGS.DataStore.Writer;
using AAA.Base.Util.Reader;

namespace DBWriterTest
{
    public partial class Form1 : Form
    {
        private List<IWriter> _db_writer;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IWriter db_writer;
            try
            {
                IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\config\symbol_list.ini");
                _db_writer = new List<IWriter>();
                foreach (string strSection in iniReader.Section)
                {
                    XmlParser xmlParser = new XmlParser(Environment.CurrentDirectory + @"\config\symbol_list.xml");
                    db_writer = new TickDBWriter(Environment.CurrentDirectory + @"\config\" + xmlParser.GetSingleNode("/symbol-list/bar-data-writer").InnerText, strSection);
                    _db_writer.Add(db_writer);
                    db_writer.Init();
                    db_writer.Start();
                }
            }
            catch (Exception ex) {
                Console.Write(ex.Message.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _db_writer.Count; i++)
            {
                _db_writer[i].Stop();
                _db_writer[i].Close();
            }
        }
    }
}
