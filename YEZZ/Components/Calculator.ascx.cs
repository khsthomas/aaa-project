using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YEZZ.Components
{
    public partial class Calculator : System.Web.UI.UserControl
    {
        private static readonly string[] AREA_TEXT = { "全國", "分區", "縣市" };
        private static readonly string[] AREA_VALUE = { "None", "HOSPITAL_AREA", "HOSPITAL_COUNTY"};

        private static readonly string[] VALUE_TYPE_TEXT = { "參與院所數", "全部院所數" };
        private static readonly string[] VALUE_TYPE_VALUE = { "PROJECT", "ALL" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBuilder.FillDropDownList(ddlArea, 
                                             AREA_TEXT, 
                                             AREA_VALUE);
                DataBuilder.FillDropDownList(ddlValueType,
                                             VALUE_TYPE_TEXT,
                                             VALUE_TYPE_VALUE);
            }
        }

        public string FormulaText
        {
            get { return txtFormula.Text; }
        }

        public string FormulaValue
        {
            get { return ParseFormula(FormulaText); }
        }

        private string ParseFormula(string strFormula)
        {
            for(int i = 0; i < AREA_TEXT.Length; i++)
                strFormula = strFormula.Replace(AREA_TEXT[i], AREA_VALUE[i]);
            for(int i = 0; i < VALUE_TYPE_TEXT.Length; i++)
                strFormula = strFormula.Replace(VALUE_TYPE_TEXT[i], VALUE_TYPE_VALUE[i]);
            return strFormula;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string strInsertValue = "[" + ddlArea.SelectedItem.Text + "," + ddlValueType.SelectedItem.Text + "]";            
            txtFormula.Text += strInsertValue;
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            txtFormula.Text += "+";
        }

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            txtFormula.Text += "-";
        }

        protected void btnMultiple_Click(object sender, EventArgs e)
        {
            txtFormula.Text += "*";
        }

        protected void btnDivide_Click(object sender, EventArgs e)
        {
            txtFormula.Text += "/";
        }
    }
}