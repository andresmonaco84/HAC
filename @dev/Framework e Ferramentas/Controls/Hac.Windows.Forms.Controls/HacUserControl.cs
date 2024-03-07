using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacUserControl : UserControl
    {
        public HacUserControl()
        {
            InitializeComponent();
        }

        private CommonServicesView _commonServices;
        protected CommonServicesView CommonServices
        {
            get
            {
                return _commonServices != null
                           ? _commonServices
                           : _commonServices = new CommonServicesView(FrmBase.DtoPassport);
            }
        }
    }
}
