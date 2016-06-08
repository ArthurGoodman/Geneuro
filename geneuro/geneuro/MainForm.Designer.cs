namespace geneuro {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataBrowseButton = new System.Windows.Forms.Button();
            this.dataEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.RichTextBox();
            this.networkEdit = new System.Windows.Forms.TextBox();
            this.networkLabel = new System.Windows.Forms.Label();
            this.networkBrowseButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataBrowseButton
            // 
            this.dataBrowseButton.Location = new System.Drawing.Point(588, 36);
            this.dataBrowseButton.Name = "dataBrowseButton";
            this.dataBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.dataBrowseButton.TabIndex = 0;
            this.dataBrowseButton.Text = "...";
            this.dataBrowseButton.UseVisualStyleBackColor = true;
            this.dataBrowseButton.Click += new System.EventHandler(this.dataBrowseButton_Click);
            // 
            // dataEdit
            // 
            this.dataEdit.Location = new System.Drawing.Point(65, 35);
            this.dataEdit.Name = "dataEdit";
            this.dataEdit.Size = new System.Drawing.Size(517, 20);
            this.dataEdit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Learn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.learnButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Classify";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseCaptureChanged += new System.EventHandler(this.classifyButton_Click);
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(12, 90);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(600, 339);
            this.console.TabIndex = 10;
            this.console.Text = "";
            // 
            // networkEdit
            // 
            this.networkEdit.Location = new System.Drawing.Point(65, 9);
            this.networkEdit.Name = "networkEdit";
            this.networkEdit.Size = new System.Drawing.Size(517, 20);
            this.networkEdit.TabIndex = 11;
            // 
            // networkLabel
            // 
            this.networkLabel.AutoSize = true;
            this.networkLabel.Location = new System.Drawing.Point(9, 9);
            this.networkLabel.Name = "networkLabel";
            this.networkLabel.Size = new System.Drawing.Size(50, 13);
            this.networkLabel.TabIndex = 12;
            this.networkLabel.Text = "Network:";
            // 
            // networkBrowseButton
            // 
            this.networkBrowseButton.Location = new System.Drawing.Point(588, 7);
            this.networkBrowseButton.Name = "networkBrowseButton";
            this.networkBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.networkBrowseButton.TabIndex = 13;
            this.networkBrowseButton.Text = "...";
            this.networkBrowseButton.UseVisualStyleBackColor = true;
            this.networkBrowseButton.Click += new System.EventHandler(this.networkBrowseButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(456, 61);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 14;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(375, 61);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(537, 61);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 16;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.networkBrowseButton);
            this.Controls.Add(this.networkLabel);
            this.Controls.Add(this.networkEdit);
            this.Controls.Add(this.console);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataEdit);
            this.Controls.Add(this.dataBrowseButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dataBrowseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.TextBox dataEdit;
        private System.Windows.Forms.TextBox networkEdit;
        private System.Windows.Forms.Label networkLabel;
        private System.Windows.Forms.Button networkBrowseButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button helpButton;
    }
}