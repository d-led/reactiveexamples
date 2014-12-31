namespace winformsnoevents
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tickerBox = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.wordCountBox = new MetroFramework.Controls.MetroTextBox();
            this.inputBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // tickerBox
            // 
            this.tickerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tickerBox.Enabled = false;
            this.tickerBox.Lines = new string[0];
            this.tickerBox.Location = new System.Drawing.Point(132, 66);
            this.tickerBox.MaxLength = 32767;
            this.tickerBox.Name = "tickerBox";
            this.tickerBox.PasswordChar = '\0';
            this.tickerBox.ReadOnly = true;
            this.tickerBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tickerBox.SelectedText = "";
            this.tickerBox.Size = new System.Drawing.Size(140, 20);
            this.tickerBox.TabIndex = 0;
            this.tickerBox.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background ticker";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Word count";
            // 
            // wordCountBox
            // 
            this.wordCountBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordCountBox.Enabled = false;
            this.wordCountBox.Lines = new string[0];
            this.wordCountBox.Location = new System.Drawing.Point(132, 92);
            this.wordCountBox.MaxLength = 32767;
            this.wordCountBox.Name = "wordCountBox";
            this.wordCountBox.PasswordChar = '\0';
            this.wordCountBox.ReadOnly = true;
            this.wordCountBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.wordCountBox.SelectedText = "";
            this.wordCountBox.Size = new System.Drawing.Size(140, 20);
            this.wordCountBox.TabIndex = 3;
            this.wordCountBox.UseSelectable = true;
            // 
            // inputBox
            // 
            this.inputBox.Lines = new string[0];
            this.inputBox.Location = new System.Drawing.Point(12, 148);
            this.inputBox.Margin = new System.Windows.Forms.Padding(0);
            this.inputBox.MaxLength = 32767;
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.PasswordChar = '\0';
            this.inputBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputBox.SelectedText = "";
            this.inputBox.Size = new System.Drawing.Size(260, 94);
            this.inputBox.TabIndex = 5;
            this.inputBox.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 118);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(100, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Enter some text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.wordCountBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tickerBox);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "Form1";
            this.Text = "Responsive WinForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox tickerBox;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroTextBox wordCountBox;
        private MetroFramework.Controls.MetroTextBox inputBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
