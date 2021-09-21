using System;
using System.Windows.Forms;

namespace PIIVaultDemoApp.Forms
{
    public partial class FormDemoMain : Form
    {
        public FormDemoMain()
        {
            InitializeComponent();
        }

        private void bPassThrough_Click(object sender, EventArgs e)
        {
            FormPassThrough passThroughForm = new FormPassThrough();
            passThroughForm.SetMode(FormPassThrough.WindowModeAnonymization);
            passThroughForm.Show();
        }

        private void bMatching_Click(object sender, EventArgs e)
        {
            FormMatching matchForm = new FormMatching();
            matchForm.Show();
        }

        private void bMasking_Click(object sender, EventArgs e)
        {
            FormPassThrough passThroughForm = new FormPassThrough();
            passThroughForm.SetMode(FormPassThrough.WindowModeMasking);
            passThroughForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormPassThrough passThroughForm = new FormPassThrough();
            passThroughForm.SetMode(FormPassThrough.WindowModeAnonymization);
            passThroughForm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormMatching matchForm = new FormMatching();
            matchForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormPassThrough passThroughForm = new FormPassThrough();
            passThroughForm.SetMode(FormPassThrough.WindowModeMasking);
            passThroughForm.Show();
        }
    }
}
