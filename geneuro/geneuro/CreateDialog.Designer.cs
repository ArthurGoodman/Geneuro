﻿namespace geneuro {
    partial class CreateDialog {
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
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sizesEdit = new System.Windows.Forms.TextBox();
            this.sizesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(13, 39);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 0;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(94, 39);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // sizesEdit
            // 
            this.sizesEdit.Location = new System.Drawing.Point(54, 13);
            this.sizesEdit.Name = "sizesEdit";
            this.sizesEdit.Size = new System.Drawing.Size(218, 20);
            this.sizesEdit.TabIndex = 2;
            // 
            // sizesLabel
            // 
            this.sizesLabel.AutoSize = true;
            this.sizesLabel.Location = new System.Drawing.Point(13, 13);
            this.sizesLabel.Name = "sizesLabel";
            this.sizesLabel.Size = new System.Drawing.Size(35, 13);
            this.sizesLabel.TabIndex = 3;
            this.sizesLabel.Text = "Sizes:";
            // 
            // CreateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 70);
            this.Controls.Add(this.sizesLabel);
            this.Controls.Add(this.sizesEdit);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Name = "CreateDialog";
            this.Text = "CreateDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox sizesEdit;
        private System.Windows.Forms.Label sizesLabel;
    }
}