using System.Windows.Forms;

namespace geneuro {
    public partial class CreateDialog : Form {
        public CreateDialog() {
            InitializeComponent();

            CenterToParent();

            AcceptButton = createButton;
            CancelButton = cancelButton;
        }

        public int[] Sizes() {
            string[] args = sizesEdit.Text.Split(' ');

            int[] layersSizes = new int[args.Length];

            for (int i = 0; i < layersSizes.Length; i++)
                if (args[i].Length > 0)
                    layersSizes[i] = int.Parse(args[i]);

            return layersSizes;
        }

        private void createButton_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.OK;
        }
    }
}
