using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESWJ
{
    public partial class FlashChildFrm : Form
    {
        private string _strFlashVars;
        private string _strMovie;

        public string FlashVars
        {
            get { return _strFlashVars; }
            set { _strFlashVars = value;
                  axShockwaveFlash1.FlashVars = value;
            }
        }

        public string Movie
        {
            get { return _strMovie; }
            set { _strMovie = value;
                  axShockwaveFlash1.Movie = value;
            }
        }

        public FlashChildFrm()
        {
            InitializeComponent();
        }
    }
}
