using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Database;
using System.Data.Common;

namespace AAA.IME.WordEditor
{
    public partial class MainForm : Form
    {
        private List<TextBox> _lstComp1;
        private List<TextBox> _lstComp2;

        public MainForm()
        {
            InitializeComponent();
            _lstComp1 = new List<TextBox>();
            _lstComp1.Add(txtComp11);
            _lstComp1.Add(txtComp12);
            _lstComp1.Add(txtComp13);
            _lstComp1.Add(txtComp14);
            _lstComp1.Add(txtComp15);
            _lstComp1.Add(txtComp16);

            _lstComp2 = new List<TextBox>();
            _lstComp2.Add(txtComp21);
            _lstComp2.Add(txtComp22);
            _lstComp2.Add(txtComp23);
            _lstComp2.Add(txtComp24);
            _lstComp2.Add(txtComp25);
            _lstComp2.Add(txtComp26);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Word, Comp1, Comp2
            IDatabase database = null;
            string strInsertSQL = "INSERT INTO word(comp1, comp2, word) VALUES('{0}', '{1}', '{2}')";
            string strUpdateSQL = "UPDATE word SET comp1 = '{0}', comp2 = '{1}' WHERE word = '{2}'";
            string strComp1;
            string strComp2;

            try
            {
                database = new AccessDatabase();
                database.Open(Environment.CurrentDirectory + @"\word.mdb", "admin", "word");
                strComp1 = txtComp11.Text.Trim() + txtComp12.Text.Trim() + txtComp13.Text.Trim() + txtComp14.Text.Trim() + txtComp15.Text.Trim() + txtComp16.Text.Trim();
                strComp2 = txtComp21.Text.Trim() + txtComp22.Text.Trim() + txtComp23.Text.Trim() + txtComp24.Text.Trim() + txtComp25.Text.Trim() + txtComp26.Text.Trim();

                if(database.ExecuteUpdate(strInsertSQL, new string[] {strComp1, strComp2, txtWord.Text.Trim()}) != 1)
                    database.ExecuteUpdate(strUpdateSQL, new string[] { strComp1, strComp2, txtWord.Text.Trim() });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (database != null)
                    database.Close();
            }
        }

        private void txtWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;

            //Word, Comp1, Comp2
            IDatabase database = null;
            DbDataReader dataReader = null;
            string strQuerySQL = "SELECT comp1, comp2 FROM word WHERE word = '{0}'";
            string strComp1 = null;
            string strComp2 = null;

            try
            {
                database = new AccessDatabase();
                database.Open(Environment.CurrentDirectory + @"\word.mdb", "admin", "word");

                dataReader = database.ExecuteQuery(strQuerySQL, new string[] { txtWord.Text.Trim()});

                while (dataReader.Read())
                {
                    strComp1 = dataReader["comp1"].ToString();
                    strComp2 = dataReader["comp2"].ToString();
                }

                for (int i = 0; i < strComp1.Length; i++)
                    _lstComp1[i].Text = strComp1.Substring(i, 1);

                for (int i = 0; i < strComp2.Length; i++)
                    _lstComp2[i].Text = strComp2.Substring(i, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();

                if (database != null)
                    database.Close();
            }

        }
    }
}
