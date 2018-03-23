using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{


    public partial class SearchForm : Form
    {

        String searchText = "";
        Queue<Content> q;
        int totalCount;
        public SearchForm()
        {
            InitializeComponent();
            q = new Queue<Content>();
            totalCount = 0;
        }

        /*
         * When search button is called the following method is invoked.
         * The following method contains code to toggle between search and cancel operation,
         * when search is clicked the backgroundworker thread is started.
         */

        private void searchButton_Click(object sender, EventArgs e)
        {
            occurrences.Text = "Total line count with search text: 0";
            if (searchButton.Text.Equals("Search"))
            {
                totalCount = 0;
                resultsListView.Items.Clear();
                String filePath = fileNameTextBox.Text;
                searchText = searchTextBox.Text;
                String errorMsg = "";
              
                //Validate if the two text boxes contain valid values
                if (filePath.Equals(String.Empty))
                {
                    errorMsg += "Enter or select the file path \n";
                }
                else if (!filePath.Contains(".txt"))
                {
                    errorMsg += "Enter or select a valid .txt file \n";
                }


                if (searchText.Equals(String.Empty))
                {
                    errorMsg += "Enter search text";
                }

                if (!errorMsg.Equals(""))
                {
                    MessageBox.Show(errorMsg);
                }
                else
                {

                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show("File not found, enter a valid txt file name");
                    }
                    else
                    {
                        //The selected file is found
                        //valid case
                        object[] parameters = new object[4] { filePath, searchText, q, ignoreCase.Checked };
                        //Change the search button text to cancel
                        searchButton.Text = "Cancel";
                        browseButton.Enabled = false;
                        backgroundWorker1.RunWorkerAsync(parameters);
                    }

                }
            }
            else
            {
                //when cancel is called
                backgroundWorker1.CancelAsync();
               

            }

        }

        /*
         * The following method is called when browse button is clicked, it contains code to display the file system files and search for text files
         */
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog1.FileName;
            }
        }

        /*
         *Following code opens the given file and searches for the given search string , if found adds it to the queue along with line number
         */

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            object[] parameters = e.Argument as object[];
            string filePath = parameters[0].ToString();
            string searchText = parameters[1].ToString();
            Queue<Content> q = (Queue<Content>)parameters[2];
            bool ignorecase = (bool)parameters[3];

           
            try
            {
                FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                long fileSizeInBytes = new FileInfo(filePath).Length;
                long readSize = 0;
                int lineNum = 0;
                using (var sr = new StreamReader(inFile))
                {
                    while (!sr.EndOfStream)
                    {
                        if (backgroundWorker1.CancellationPending)
                        {
                            //when cancel button sis clicked 
                            //close the file
                            e.Cancel = true;
                            sr.Close();
                            inFile.Close();

                        }
                        else
                        {
                            var line = sr.ReadLine();
                            lineNum++;

                            if (String.IsNullOrEmpty(line)) continue;
                            if (ignorecase && line.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                q.Enqueue(new Content(lineNum.ToString().Trim(), line));

                            }
                            if ((!ignorecase) && line.IndexOf(searchText) >= 0)
                            {

                                q.Enqueue(new Content(lineNum.ToString().Trim(), line));
                            }

                            readSize += ASCIIEncoding.ASCII.GetByteCount(line);
                            int percentage = (int)(((double)readSize / fileSizeInBytes) * 100);
                            //rounding the completion percentage as discussed in class
                            if (percentage >= 95)
                            {
                                percentage = 100;
                            }
                            else if (percentage == 0)
                            {
                                percentage = 1;
                            }

                            backgroundWorker1.ReportProgress(percentage, q);
                            Thread.Sleep(1);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*
         * Update the progress status in progress bar
         */
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            searchProgressBar.Value = e.ProgressPercentage;
            label2.Text = "Progress Status (" + e.ProgressPercentage.ToString() + "%)";
            while (q.Count > 0)
            {
                Content c = q.Dequeue();
                totalCount++;
                ListViewItem item1 = new ListViewItem(c.getLineNumber());
                item1.SubItems.Add(c.getLineText());
                resultsListView.Items.Add(item1);
            }
            occurrences.Text = "Total line count with search text: " + totalCount;

        }

        /*
         * When the background worker has completed the task the following method is called,
         * it reads the Content object from queue and updates the listview in UI and also
         * updated total lines count with the given search string.
         * Enable browse button when search is completed or when cancel is clicked.
         */
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            searchButton.Text = "Search";
            browseButton.Enabled = true;
            if (e.Cancelled)
            {
               
               
                MessageBox.Show("Search was cancelled");
                occurrences.Text = "Total line count with search text: 0";
                label2.Text = "Progress Status (0%)";
                searchProgressBar.Value = 0;

            }
            else
            {
                MessageBox.Show("Successfully completed the search!");
            }
            
        }
    }

    /*
     * A class with line number and content used to store in the Queue
     */
    public class Content
    {
        String lineNumber;
        String lineText;
        public Content(String lineNumber, String lineText)
        {
            this.lineNumber = lineNumber;
            this.lineText = lineText;
        }

        public String getLineNumber()
        {
            return lineNumber;
        }

        public String getLineText()
        {
            return lineText;
        }
    }
}
