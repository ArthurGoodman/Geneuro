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
            OpenFileDialog dlg = new OpenFileDialog();
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
            MessageBox.Show("Руководство пользователя." + "\n\n"

                + "Кнопка Create. При нажатии на кнопку 'Create' откроется диалоговое окно куда вы внесёте параметры нейронной сети и нажмите кнопку 'Create' находящейся ниже. После данной операции в папке с самой программой создасться файл под названием netwok. Например: 300 600 10. 300 - это входной вектор изображений(размер изображения); 600 - это любое число(скрытый слой) нейросети; 10 - это выходной слой, т.е. колличество распознаваемых элементов." + "\n\n"
                + "Кнопка Learn. Перед тем как использовать кнопку 'Learn' выберите в первой строке путь к файлу 'network', который вы создали на предыдущем этапе. После нажатия кнопки 'Learn' начнеться обучение нейронной сети. Данные обучения будут выводиться на экран." + "\n\n"
                + "Кнопка Classify. При нажатии откроется диалоговое окно для выбора файла классификации. После того как файл булет выбран и будет нажата кнопка 'Открыть' в главной форме появится нужный вам результат." + "\n\n"
                + "Кнопка Save. При нажатии кнопки 'save' откроется диалоговое окно в котором можно будет задать путь и название для сохранениея выведенных данных." + "\n\n"
                + "Кнопка Clear. При нажатии кнопки 'Clear' выведенные данные стираються." + "\n\n" 
                + "Разработчик: студент группы ИМ-22 Сивоглаз А.И.", "Help");


        }
    }
}
