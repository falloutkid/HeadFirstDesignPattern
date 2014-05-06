using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MVC.View
{
    public partial class ViewClass : Form
    {
        ViewCurrentBPM bpm_form;
        Thread bpm_form_thread;
        public ViewClass()
        {
            InitializeComponent();
        }

        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bpm_form = new ViewCurrentBPM();

            bpm_form_thread = new Thread(new ThreadStart(startSubForm));

            bpm_form_thread.Start();

            停止ToolStripMenuItem.Enabled = true;
            開始ToolStripMenuItem.Enabled = false;
        }

        private void startSubForm()
        {
            bpm_form.ShowDialog();
        }

        // BmpFormを閉じるInvokeメソッドで使用するデリゲート
        private delegate void DisposeBpmForm();
        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dispose_bpm_form_function();
        }

        private void dispose_bpm_form_function()
        {
            DisposeBpmForm delegate_dispose_bpm_form = new DisposeBpmForm(bpm_form.DisposeThisForm);
            this.Invoke(delegate_dispose_bpm_form);

            bpm_form_thread.Abort();

            bpm_form_thread.Join();

            停止ToolStripMenuItem.Enabled = false;
            開始ToolStripMenuItem.Enabled = true;
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bpm_form_thread.IsAlive)
                dispose_bpm_form_function();
            this.Dispose();
        }

        private void ViewClass_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bpm_form_thread != null)
            {
                if (bpm_form_thread.IsAlive)
                    dispose_bpm_form_function();
            }
        }
    }
}
