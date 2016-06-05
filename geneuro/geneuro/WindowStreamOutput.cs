using System;
using System.Windows.Forms;

namespace geneuro {
    class WindowStreamOutput : IStreamOutput {
        private RichTextBox textBox;

        public WindowStreamOutput(RichTextBox textBox) {
            this.textBox = textBox;
        }

        public void Write(object str) {
            textBox.Text += str.ToString();
            textBox.Update();
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }

        public void WriteLine(object str) {
            textBox.Text += str.ToString() + Environment.NewLine;
            textBox.Update();
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
        }
    }
}
