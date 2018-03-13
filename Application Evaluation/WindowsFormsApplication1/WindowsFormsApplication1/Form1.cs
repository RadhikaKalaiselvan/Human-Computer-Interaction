using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /* When Analyse button is clicked the following method is called.
        * This method contains the logic for evaluating the file based on the attributes
        */
        private void button1_Click(object sender, EventArgs e)
        {
            String filePath = textBox1.Text;
            //Check if the path is given else show error message
            if (filePath.Equals(String.Empty))
            {
                MessageBox.Show("Enter the path and click analyse");
            }else
            {

                int totalRecords = 0; //Used to count the total number of records
                
                //These two variables are used for finding the total time
                DateTime firstStartTime = DateTime.Today;
                DateTime lastFinishTime = DateTime.Today; 

                
                int totalbackspace = 0; //used to count the total backspace key press
                LinkedList<TimeSpan> list_sp = new LinkedList<TimeSpan>(); //List contains the time taken to enter a record
                LinkedList<TimeSpan> list_interRecord = new LinkedList<TimeSpan>(); //List contains time in between the record
                DateTime prevEndTime = DateTime.Today; //used to find the time inbetween data entry
               
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string s = "";

                        while ((s = sr.ReadLine()) != null)
                        {

                            string[] split = s.Split('\t');
                            if (split.Length != 16)
                            {
                                //return error message when the file doesnot contain all the attributes
                                MessageBox.Show("Unable to parse the file, fields might be missing or invalid file format");
                                break;
                            }
                            else
                            {
                                String firstKeyPress = split[13];
                                DateTime starttime = Convert.ToDateTime(firstKeyPress);


                                string lastKeyPress = split[14];
                                DateTime endtime = Convert.ToDateTime(lastKeyPress);
                                lastFinishTime = endtime;

                                if (totalRecords == 0)
                                {
                                    prevEndTime = endtime;
                                    firstStartTime = starttime;

                                }
                                else
                                {
                                    TimeSpan interDiff = starttime.Subtract(prevEndTime);
                                    list_interRecord.AddLast(interDiff);
                                    prevEndTime = endtime;
                                }

                                int backKeyCount = int.Parse(split[15]);
                                totalbackspace += backKeyCount;

                                TimeSpan diff = endtime.Subtract(starttime);
                                list_sp.AddLast(diff);

                                totalRecords++;
                            }
                        }
                    }

                    if (totalRecords > 0)
                    {
                        // Create the list view and values to be added to the output file
                        String outputContent = "";
                        listView1.Items.Clear();

                        //Just add the totalrecord variable to output
                        ListViewItem item = new ListViewItem("Total record count");
                        item.SubItems.Add(totalRecords+"");
                        item.ToolTipText = "Total number of records added using the application";
                        listView1.Items.Add(item);
                        outputContent += "Total record count:" + totalRecords+"\r\n";

                        //find min from the list which contains all the timespans for entering a record
                        TimeSpan minTimeSpan = list_sp.Min();
                        ListViewItem item3 = new ListViewItem("Minimum entry time");
                        item3.SubItems.Add(minTimeSpan.Minutes + ":" + minTimeSpan.Seconds);
                        item3.ToolTipText = "Least time taken to enter a record using the application";
                        listView1.Items.Add(item3);
                        outputContent += "Minimum entry time:" + minTimeSpan.Minutes + ":" + minTimeSpan.Seconds+"\r\n";

                        //find max from the list which contains all the timespans for entering a record
                        TimeSpan maxTimeSpan = list_sp.Max();
                        ListViewItem item2 = new ListViewItem("Maximum entry time");
                        item2.SubItems.Add(maxTimeSpan.Minutes + ":" + maxTimeSpan.Seconds);
                        item2.ToolTipText = "Maximum time taken to enter a record using the application";
                        listView1.Items.Add(item2);
                        outputContent += "Maximum entry time:" + maxTimeSpan.Minutes + ":" + maxTimeSpan.Seconds + "\r\n";


                        //find average from the list which contains all the timespans for entering a record
                        double doubleAverageTicks = list_sp.Average(timeSpan => timeSpan.Ticks);
                        long longAverageTicks = Convert.ToInt64(doubleAverageTicks);
                        TimeSpan avg_timesp= new TimeSpan(longAverageTicks);


                        ListViewItem item1 = new ListViewItem("Average entry time");
                        item1.SubItems.Add(avg_timesp.Minutes+":"+avg_timesp.Seconds);
                        item1.ToolTipText = "Average time taken to enter a record using the application";
                        listView1.Items.Add(item1);

                        outputContent += "Average entry time:" + avg_timesp.Minutes + ":" + avg_timesp.Seconds + "\r\n";

                        //find min from the list which contains all the interval timespans between records
                        TimeSpan minInterTimeSpan = list_interRecord.Min();
                        ListViewItem mininter = new ListViewItem("Minimum inter record time");
                        mininter.SubItems.Add(minInterTimeSpan.Minutes + ":" + minInterTimeSpan.Seconds);
                        mininter.ToolTipText = "Least time interval between consecutive data entry";
                        listView1.Items.Add(mininter);
                        outputContent += "Minimum inter record time:" + minInterTimeSpan.Minutes + ":" + minInterTimeSpan.Seconds+ "\r\n";


                        //find max from the list which contains all the interval timespans between records
                        TimeSpan maxInterTimeSpan = list_interRecord.Max();
                        ListViewItem maxinterTime = new ListViewItem("Maximum inter record time");
                        maxinterTime.SubItems.Add(maxInterTimeSpan.Minutes + ":" + maxInterTimeSpan.Seconds);
                        maxinterTime.ToolTipText = "Maximum time interval between consecutive data entry";
                        listView1.Items.Add(maxinterTime);
                        outputContent += "Maximum inter record time:" + maxInterTimeSpan.Minutes + ":" + maxInterTimeSpan.Seconds + "\r\n";

                        //find average from the list which contains all the interval timespans between records
                        double doubleAvgTicks = list_interRecord.Average(timeSpan => timeSpan.Ticks);
                        long longAvgTicks = Convert.ToInt64(doubleAvgTicks);
                        TimeSpan avg_intertimesp = new TimeSpan(longAvgTicks);


                        ListViewItem avgInter = new ListViewItem("Average inter record time");
                        avgInter.SubItems.Add(avg_timesp.Minutes + ":" + avg_intertimesp.Seconds);
                        avgInter.ToolTipText = "Average time interval between consecutive data entry";
                        listView1.Items.Add(avgInter);
                        outputContent += "Average inter record time:" + avg_timesp.Minutes + ":" + avg_intertimesp.Seconds + "\r\n";



                        //find total time by finding the difference between firstStartTime and lastFinshTime of records
                        TimeSpan total = lastFinishTime - firstStartTime;
                        ListViewItem item4 = new ListViewItem("Total entry time");
                        item4.SubItems.Add(total.Minutes + ":" + total.Seconds);
                        item4.ToolTipText = "Total time take for data entry";
                        listView1.Items.Add(item4);
                        outputContent += "Total entry time:" + total.Minutes + ":" + total.Seconds + "\r\n";


                        //Add total backsapce count to output
                        ListViewItem item5 = new ListViewItem("Backspace count");
                        item5.SubItems.Add(totalbackspace+"");
                        item5.ToolTipText = "Total number of times backspace key was pressed during data entry";
                        listView1.Items.Add(item5);
                        outputContent += "Backspace count:" + totalbackspace;

                        writeOutputToFile(outputContent);

                        
                    }
                    else
                    {
                        //If there are no records in the file show error message
                        MessageBox.Show("No records found in the file");
                    }

                }else
                {
                    //File not found
                    MessageBox.Show("Unable to find the given file.Enter valid file name");
                }
            }
        }
        /*
         * Writes the given string to output file
         */

        private void writeOutputToFile(String content)
        {
            string path = "Output.txt";

            try
            {

               
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }
                MessageBox.Show("Text file format of output can found at :" + path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
         * Clears the form and text box
         */ 
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            listView1.Items.Clear();
        }
    }
}
