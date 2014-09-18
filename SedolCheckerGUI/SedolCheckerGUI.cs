using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SedolCheckerGUI
{
    public partial class SedolCheckerGUI : Form, IView
    {
        private Presenter ViewPresenter { get; set; }

        public SedolCheckerGUI()
        {
            InitializeComponent();
            ViewPresenter = new Presenter(this);
        }

        public bool IsValid
        {
            set { this.checkBoxIsValid.Checked = value; }
        }

        public bool IsUserDefined
        {
            set { this.checkBoxUserDefined.Checked = value; }
        }

        public string ValidationDetails
        {
            set { this.textBoxValidationDetails.Text = value; }
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            ViewPresenter.OnValidate();
        }
    
        public string  InputSedol
        {
	        get { return this.textBoxInput.Text; }
        }
    }
}
