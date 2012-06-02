using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Momentum.Strategy;
using AAA.DesignPattern.Observer;
using Momentum.Strategy.Meta;

namespace Momentum.Test
{
    public partial class MainForm : Form, IObserver
    {
        private IQuoteClient _quoteClient;
        private List<IIndicator> _lstIndicator;

        public MainForm()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            LibraryLoader loader = new LibraryLoader();
            _lstIndicator = loader.LoadIndicator(Environment.CurrentDirectory + @"\Signals");

            _quoteClient = new DefaultQuoteClient();
            foreach (IIndicator indicator in _lstIndicator)
            {
//                _quoteClient.Attach(indicator);
//                indicator.Attach(this);
                chkIndicator.Items.Add(indicator.DisplayName);
            }

        }

        #region IObserver Members

        public void Update(object oSource, IMessageInfo miMessage)
        {
            lstMessage.Items.Add(((IIndicator)oSource).DisplayName + "," + ((ISignalInfo)miMessage.Message).Value);
            Application.DoEvents();
        }

        #endregion

        private void btnStart_Click(object sender, EventArgs e)
        {
            _quoteClient.StartQuote();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            foreach (IIndicator indicator in _lstIndicator)
                _quoteClient.Detach(indicator);
            for(int i = 0; i < chkIndicator.Items.Count; i++)
                if (chkIndicator.GetItemChecked(i))
                {
                    _quoteClient.Attach(_lstIndicator[i]);
                    _lstIndicator[i].Attach(this);
                }
        }
    }
}
