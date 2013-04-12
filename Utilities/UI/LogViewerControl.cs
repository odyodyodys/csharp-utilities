using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilities.UI
{
    public partial class LogViewerControl : UserControl
    {
	    #region Constructors
        public LogViewerControl()
        {
            InitializeComponent();
        }
	    #endregion

		#region Methods
        public void SetLogMessage(string message)
        {
            if (String.IsNullOrEmpty(LogTextBox.Text))
            {
                LogTextBox.Text = message;
            }
            else
            {
                LogTextBox.Text += Environment.NewLine + message;
            }
        }

        public void ClearLog()
        {
            LogTextBox.Clear();
        }
		#endregion

		#region Events
        private void LogTextBox_TextChanged(object sender, EventArgs e)
        {
            // scroll to end
            LogTextBox.SelectionStart = LogTextBox.TextLength;
            LogTextBox.ScrollToCaret();
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogTextBox.Text = string.Empty;
        }
		
		#endregion

    }
}
