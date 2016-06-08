using System;
using System.IO;
using System.Windows.Forms;

namespace geneuro {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

            CenterToScreen();

            Engine.Output = new WindowStreamOutput(console);

            dataEdit.Text = Path.GetFullPath(Settings.Instance.DataDirectoryPath);
            networkEdit.Text = Path.GetFullPath(Settings.Instance.NetworkFileName);
        }

        private void dataBrowseButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
                dataEdit.Text = dlg.SelectedPath;
        }

        private void networkBrowseButton_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();

            if (dlg.ShowDialog() == DialogResult.OK)
                networkEdit.Text = dlg.FileName;
        }

        private void createButton_Click(object sender, EventArgs e) {
            Settings.Instance.DataDirectoryPath = dataEdit.Text;
            Settings.Instance.NetworkFileName = networkEdit.Text;

            CreateDialog dlg = new CreateDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
                Engine.Create(dlg.Sizes());
        }

        private void learnButton_Click(object sender, EventArgs e) {
            Settings.Instance.DataDirectoryPath = dataEdit.Text;
            Settings.Instance.NetworkFileName = networkEdit.Text;

            Engine.Learn();
            Engine.Output.WriteLine("");
        }

        private void classifyButton_Click(object sender, EventArgs e) {
            Settings.Instance.DataDirectoryPath = dataEdit.Text;
            Settings.Instance.NetworkFileName = networkEdit.Text;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();

            if (dlg.ShowDialog() == DialogResult.OK) {
                Engine.Classify(dlg.FileName);
                Engine.Output.WriteLine("");
            }
        }

        private void clearButton_Click(object sender, EventArgs e) {
            console.Clear();
        }

        private void saveButton_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            dlg.Filter = "Text files (*.txt)|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
                File.WriteAllText(dlg.FileName, console.Text);
        }

        private void helpButton_Click(object sender, EventArgs e) {
            MessageBox.Show("This is help.", "Help");
        }
    }
}
