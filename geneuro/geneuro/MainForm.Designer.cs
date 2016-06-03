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
            this.testsBrowseButton = new System.Windows.Forms.Button();
            this.testEdit = new System.Windows.Forms.TextBox();
            this.dataEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // dataBrowseButton
            // 
            this.dataBrowseButton.Location = new System.Drawing.Point(588, 13);
            this.dataBrowseButton.Name = "dataBrowseButton";
            this.dataBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.dataBrowseButton.TabIndex = 0;
            this.dataBrowseButton.Text = "...";
            this.dataBrowseButton.UseVisualStyleBackColor = true;
            this.dataBrowseButton.Click += new System.EventHandler(this.dataBrowseButton_Click);
            // 
            // testsBrowseButton
            // 
            this.testsBrowseButton.Location = new System.Drawing.Point(588, 43);
            this.testsBrowseButton.Name = "testsBrowseButton";
            this.testsBrowseButton.Size = new System.Drawing.Size(24, 23);
            this.testsBrowseButton.TabIndex = 1;
            this.testsBrowseButton.Text = "...";
            this.testsBrowseButton.UseVisualStyleBackColor = true;
            // 
            // testEdit
            // 
            this.testEdit.Location = new System.Drawing.Point(54, 43);
            this.testEdit.Name = "testEdit";
            this.testEdit.Size = new System.Drawing.Size(528, 20);
            this.testEdit.TabIndex = 3;
            // 
            // dataEdit
            // 
            this.dataEdit.Location = new System.Drawing.Point(54, 13);
            this.dataEdit.Name = "dataEdit";
            this.dataEdit.Size = new System.Drawing.Size(528, 20);
            this.dataEdit.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tests:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Learn";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(174, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Classify";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 101);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(600, 328);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataEdit);
            this.Controls.Add(this.testEdit);
            this.Controls.Add(this.testsBrowseButton);
            this.Controls.Add(this.dataBrowseButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testsBrowseButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dataBrowseButton;
        private System.Windows.Forms.TextBox testEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox dataEdit;
    }
}