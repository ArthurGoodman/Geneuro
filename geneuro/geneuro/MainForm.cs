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
            MessageBox.Show(
                  "CREATE." + "\n\n" 
                + "При натисканні на кнопку 'Create' відкриється діалогове вікно 'CreateDialog'  куди ви внесете параметри НМ і натисніть кнопку 'Create', яка знаходиться нижче. Після даної операції в папці з самою програмою створиться файл під назвою netwok, який буде мати шлях вказаний в полі 'Network'. Приклад задання параметрів НМ: 300 600 10. 300 - це вхідний вектор зображень(розмір зображення в пікселях); 600 - це будь - яке число(прихований шар) нейронної мережі; 10 - це вихідний шар, тобто кількість розпізнаваних елементів." + "\n\n"
                + "LEARN." + "\n\n"
                + "Перед тим як використовувати кнопку 'Learn' виберіть в першому рядку шлях до файлу 'network', який ви створили на попередньому етапі. Після натискання кнопки 'Learn' почнеться навчання нейронної мережі. Дані навчання будуть виводитися на екран." + "\n\n"
                + "CLASSIFY." + "\n\n"
                + "При натисканні відкриється діалогове вікно для вибору файлу класифікації. Після того як файл буде обраний і буде натиснута кнопка 'Відкрити' в головній формі з'явиться потрібний вам результат." + "\n\n"
                + "SAVE." + "\n\n"
                + "При натисканні кнопки 'Save' відкриється діалогове вікно в якому можна буде задати шлях і назву для збереження виведених даних." + "\n\n"
                + "CLEAR." + "\n\n" 
                + "При натисканні кнопки 'Clear' виведені дані видаляються." + "\n\n" 
                + "Розробник: студент групи ІМ-22 Сивоглаз А.І.", "Інструкція користувача");
        }
    }
}
