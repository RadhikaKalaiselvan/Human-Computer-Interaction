namespace WindowsFormsApplication1
{
    partial class SearchForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ignoreCase = new System.Windows.Forms.CheckBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchTerm = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.occurrences = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchProgressBar = new System.Windows.Forms.ProgressBar();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.Attribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ignoreCase);
            this.panel1.Controls.Add(this.fileNameTextBox);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.searchTerm);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.browseButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 112);
            this.panel1.TabIndex = 1;
            // 
            // ignoreCase
            // 
            this.ignoreCase.AutoSize = true;
            this.ignoreCase.Checked = true;
            this.ignoreCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreCase.Location = new System.Drawing.Point(502, 78);
            this.ignoreCase.Name = "ignoreCase";
            this.ignoreCase.Size = new System.Drawing.Size(83, 17);
            this.ignoreCase.TabIndex = 3;
            this.ignoreCase.Text = "Ignore Case";
            this.ignoreCase.UseVisualStyleBackColor = true;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(83, 22);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(502, 20);
            this.fileNameTextBox.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(83, 74);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(394, 20);
            this.searchTextBox.TabIndex = 2;
            // 
            // searchTerm
            // 
            this.searchTerm.Location = new System.Drawing.Point(4, 74);
            this.searchTerm.Name = "searchTerm";
            this.searchTerm.Size = new System.Drawing.Size(73, 23);
            this.searchTerm.TabIndex = 6;
            this.searchTerm.Text = "Search for";
            this.searchTerm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(610, 74);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(157, 22);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(610, 22);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(157, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "File name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.occurrences);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.searchProgressBar);
            this.panel2.Controls.Add(this.resultsListView);
            this.panel2.Location = new System.Drawing.Point(12, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 390);
            this.panel2.TabIndex = 2;
            // 
            // occurrences
            // 
            this.occurrences.AutoSize = true;
            this.occurrences.Location = new System.Drawing.Point(585, 330);
            this.occurrences.Name = "occurrences";
            this.occurrences.Size = new System.Drawing.Size(169, 13);
            this.occurrences.TabIndex = 8;
            this.occurrences.Text = "Total line count with search text: 0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Progress Status (%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchProgressBar
            // 
            this.searchProgressBar.Location = new System.Drawing.Point(6, 356);
            this.searchProgressBar.Name = "searchProgressBar";
            this.searchProgressBar.Size = new System.Drawing.Size(761, 23);
            this.searchProgressBar.TabIndex = 1;
            // 
            // resultsListView
            // 
            this.resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Attribute,
            this.Value});
            this.resultsListView.Location = new System.Drawing.Point(6, 3);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.ShowItemToolTips = true;
            this.resultsListView.Size = new System.Drawing.Size(761, 314);
            this.resultsListView.TabIndex = 0;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            this.resultsListView.View = System.Windows.Forms.View.Details;
            // 
            // Attribute
            // 
            this.Attribute.Text = "Line Number";
            this.Attribute.Width = 103;
            // 
            // Value
            // 
            this.Value.Text = "Line Text";
            this.Value.Width = 653;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 509);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SearchForm";
            this.Text = "Search Application";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.ColumnHeader Attribute;
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label searchTerm;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar searchProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox ignoreCase;
        private System.Windows.Forms.Label occurrences;
    }
}

