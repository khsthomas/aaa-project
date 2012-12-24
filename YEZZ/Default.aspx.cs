using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YEZZ
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            mpeCalculator.Show();            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            txtFormula.Text = calculator.FormulaText;
            txtFormulaValue.Text = calculator.FormulaValue;
            mpeCalculator.Hide();
        }


    }
}
