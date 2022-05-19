
namespace FoldersHW
{
    partial class Form_Folders
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Browse = new System.Windows.Forms.Button();
            this.listBox_Folders = new System.Windows.Forms.ListBox();
            this.listBox_Files = new System.Windows.Forms.ListBox();
            this.label_Folders = new System.Windows.Forms.Label();
            this.label_Files = new System.Windows.Forms.Label();
            this.checkBox_Include = new System.Windows.Forms.CheckBox();
            this.checkBox_Exclude = new System.Windows.Forms.CheckBox();
            this.listBox_Filter = new System.Windows.Forms.ListBox();
            this.label_Filter = new System.Windows.Forms.Label();
            this.textBox_Filter = new System.Windows.Forms.TextBox();
            this.button_AddToFilter = new System.Windows.Forms.Button();
            this.button_ClearFilter = new System.Windows.Forms.Button();
            this.listBox_Logs = new System.Windows.Forms.ListBox();
            this.label_Status = new System.Windows.Forms.Label();
            this.button_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(22, 22);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(137, 37);
            this.button_Browse.TabIndex = 0;
            this.button_Browse.Text = "Browse";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.UseWaitCursor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // listBox_Folders
            // 
            this.listBox_Folders.FormattingEnabled = true;
            this.listBox_Folders.ItemHeight = 25;
            this.listBox_Folders.Location = new System.Drawing.Point(738, 62);
            this.listBox_Folders.Name = "listBox_Folders";
            this.listBox_Folders.Size = new System.Drawing.Size(320, 254);
            this.listBox_Folders.TabIndex = 1;
            this.listBox_Folders.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Folders_MouseDoubleClick);
            // 
            // listBox_Files
            // 
            this.listBox_Files.FormattingEnabled = true;
            this.listBox_Files.ItemHeight = 25;
            this.listBox_Files.Location = new System.Drawing.Point(1092, 62);
            this.listBox_Files.Name = "listBox_Files";
            this.listBox_Files.Size = new System.Drawing.Size(328, 254);
            this.listBox_Files.TabIndex = 2;
            this.listBox_Files.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_Files_MouseDoubleClick);
            // 
            // label_Folders
            // 
            this.label_Folders.AutoSize = true;
            this.label_Folders.Location = new System.Drawing.Point(738, 34);
            this.label_Folders.Name = "label_Folders";
            this.label_Folders.Size = new System.Drawing.Size(74, 25);
            this.label_Folders.TabIndex = 3;
            this.label_Folders.Text = "Folders:";
            // 
            // label_Files
            // 
            this.label_Files.AutoSize = true;
            this.label_Files.Location = new System.Drawing.Point(1092, 34);
            this.label_Files.Name = "label_Files";
            this.label_Files.Size = new System.Drawing.Size(50, 25);
            this.label_Files.TabIndex = 4;
            this.label_Files.Text = "Files:";
            // 
            // checkBox_Include
            // 
            this.checkBox_Include.AutoSize = true;
            this.checkBox_Include.Location = new System.Drawing.Point(22, 81);
            this.checkBox_Include.Name = "checkBox_Include";
            this.checkBox_Include.Size = new System.Drawing.Size(95, 29);
            this.checkBox_Include.TabIndex = 5;
            this.checkBox_Include.Text = "Include";
            this.checkBox_Include.UseVisualStyleBackColor = true;
            this.checkBox_Include.CheckedChanged += new System.EventHandler(this.checkBox_Include_CheckedChanged);
            // 
            // checkBox_Exclude
            // 
            this.checkBox_Exclude.AutoSize = true;
            this.checkBox_Exclude.Location = new System.Drawing.Point(22, 126);
            this.checkBox_Exclude.Name = "checkBox_Exclude";
            this.checkBox_Exclude.Size = new System.Drawing.Size(97, 29);
            this.checkBox_Exclude.TabIndex = 6;
            this.checkBox_Exclude.Text = "Exclude";
            this.checkBox_Exclude.UseVisualStyleBackColor = true;
            this.checkBox_Exclude.CheckedChanged += new System.EventHandler(this.checkBox_Exclude_CheckedChanged);
            // 
            // listBox_Filter
            // 
            this.listBox_Filter.FormattingEnabled = true;
            this.listBox_Filter.ItemHeight = 25;
            this.listBox_Filter.Location = new System.Drawing.Point(389, 62);
            this.listBox_Filter.Name = "listBox_Filter";
            this.listBox_Filter.Size = new System.Drawing.Size(293, 254);
            this.listBox_Filter.TabIndex = 7;
            // 
            // label_Filter
            // 
            this.label_Filter.AutoSize = true;
            this.label_Filter.Location = new System.Drawing.Point(389, 28);
            this.label_Filter.Name = "label_Filter";
            this.label_Filter.Size = new System.Drawing.Size(54, 25);
            this.label_Filter.TabIndex = 8;
            this.label_Filter.Text = "Filter:";
            // 
            // textBox_Filter
            // 
            this.textBox_Filter.Location = new System.Drawing.Point(9, 178);
            this.textBox_Filter.Name = "textBox_Filter";
            this.textBox_Filter.Size = new System.Drawing.Size(374, 31);
            this.textBox_Filter.TabIndex = 9;
            this.textBox_Filter.Text = "Enter value and press \"Add To Filter\"";
            this.textBox_Filter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Filter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_Filter_MouseDown);
            // 
            // button_AddToFilter
            // 
            this.button_AddToFilter.Location = new System.Drawing.Point(12, 229);
            this.button_AddToFilter.Name = "button_AddToFilter";
            this.button_AddToFilter.Size = new System.Drawing.Size(371, 34);
            this.button_AddToFilter.TabIndex = 10;
            this.button_AddToFilter.Text = "Add To Filter";
            this.button_AddToFilter.UseVisualStyleBackColor = true;
            this.button_AddToFilter.Click += new System.EventHandler(this.button_AddToFilter_Click);
            // 
            // button_ClearFilter
            // 
            this.button_ClearFilter.Location = new System.Drawing.Point(12, 282);
            this.button_ClearFilter.Name = "button_ClearFilter";
            this.button_ClearFilter.Size = new System.Drawing.Size(371, 34);
            this.button_ClearFilter.TabIndex = 11;
            this.button_ClearFilter.Text = "Clear Filter";
            this.button_ClearFilter.UseVisualStyleBackColor = true;
            this.button_ClearFilter.Click += new System.EventHandler(this.button_ClearFilter_Click);
            // 
            // listBox_Logs
            // 
            this.listBox_Logs.FormattingEnabled = true;
            this.listBox_Logs.ItemHeight = 25;
            this.listBox_Logs.Location = new System.Drawing.Point(9, 333);
            this.listBox_Logs.Name = "listBox_Logs";
            this.listBox_Logs.Size = new System.Drawing.Size(1411, 229);
            this.listBox_Logs.TabIndex = 12;
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(158, 81);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(60, 25);
            this.label_Status.TabIndex = 13;
            this.label_Status.Text = "Status";
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(183, 22);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(158, 37);
            this.button_Stop.TabIndex = 14;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // Form_Folders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 588);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.label_Status);
            this.Controls.Add(this.listBox_Logs);
            this.Controls.Add(this.button_ClearFilter);
            this.Controls.Add(this.button_AddToFilter);
            this.Controls.Add(this.textBox_Filter);
            this.Controls.Add(this.label_Filter);
            this.Controls.Add(this.listBox_Filter);
            this.Controls.Add(this.checkBox_Exclude);
            this.Controls.Add(this.checkBox_Include);
            this.Controls.Add(this.label_Files);
            this.Controls.Add(this.label_Folders);
            this.Controls.Add(this.listBox_Files);
            this.Controls.Add(this.listBox_Folders);
            this.Controls.Add(this.button_Browse);
            this.Name = "Form_Folders";
            this.Text = "Homework_3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.ListBox listBox_Folders;
        private System.Windows.Forms.ListBox listBox_Files;
        private System.Windows.Forms.Label label_Folders;
        private System.Windows.Forms.Label label_Files;
        private System.Windows.Forms.CheckBox checkBox_Include;
        private System.Windows.Forms.CheckBox checkBox_Exclude;
        private System.Windows.Forms.ListBox listBox_Filter;
        private System.Windows.Forms.Label label_Filter;
        private System.Windows.Forms.TextBox textBox_Filter;
        private System.Windows.Forms.Button button_AddToFilter;
        private System.Windows.Forms.Button button_ClearFilter;
        private System.Windows.Forms.ListBox listBox_Logs;
        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_Stop;
    }
}

