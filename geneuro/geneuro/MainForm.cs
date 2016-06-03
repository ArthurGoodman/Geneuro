using System;
using System.Windows.Forms;

namespace geneuro {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void dataBrowseButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == DialogResult.OK) {
                string path = dlg.SelectedPath;
                dataEdit.Text = path;
            }
        }

        private void testsBrowseButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == DialogResult.OK) {
                string path = dlg.SelectedPath;
                testEdit.Text = path;
            }
        }

        private void createButton_Click(object sender, EventArgs e) {
        }

        private void learnButton_Click(object sender, EventArgs e) {
        }

        private void classifyButton_Click(object sender, EventArgs e) {
        }
    }
}
