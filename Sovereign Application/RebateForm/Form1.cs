using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RebateForm
{
    public partial class Form1 : Form
    {
        HashSet<String> states;
        RecordHandler rh;
        Record selectedR;
        public Form1()
        {
            InitializeComponent();
            states = new HashSet<string>();
            addStates(states);
             rh = new RecordHandler();
            loadListBox();
            selectedR = new RebateForm.Record();
        }

        public void loadListBox()
        {
            LinkedList<Record> lr = rh.getList();
            listView1.Items.Clear();
            foreach(Record r in lr)
            {
                ListViewItem item = new ListViewItem(r.firstName);
                item.SubItems.Add(r.lastName);
                item.SubItems.Add(r.middleName);
                item.SubItems.Add(r.phoneNumber);
                listView1.Items.Add(item);
            }
        }

        private void addStates(HashSet<String> states)
        {
            String[] arry = {
            "AA","AP","AK","AL","AR","AZ","CA","CO","CT","DC","DE","FL","GA","GU","HI","IA","ID","IL","IN","KS","KY",
"LA","MA","MD","ME","MI","MN","MO","MS","MT","NC","ND","NE","NH","NJ","NM","NV","NY",
"OH","OK","OR","PA","PR","RI","SC","SD","TN","TX","UT","VA","VI","VT","WA","WI","WV",
"WY"
            };
            foreach (string st in arry)
                states.Add(st);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutFormData_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void firstNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            if(firstName != string.Empty)
            {
                if(firstName.Any(ch => !(Char.IsLetterOrDigit(ch) || Char.IsWhiteSpace(ch))))
                {
                    MessageBox.Show("First name contains invalid characters ");
                }else
                {
                    int length = firstName.Length;
                    if (length > 20)
                    {
                        MessageBox.Show("First name can be of max size 20");
                    }
                }
            }else
            {
                MessageBox.Show("First name cannot be empty");
            }
        }

        private void lastNameTextBox_Validated(object sender, EventArgs e)
        {
            
        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            string lastName = lastNameTextBox.Text;
            if (lastName != string.Empty)
            {
                if (lastName.Any(ch => !(Char.IsLetterOrDigit(ch) || Char.IsWhiteSpace(ch))))
                {
                    MessageBox.Show("Last name contains invalid characters");
                }
                else
                {
                    int length = lastName.Length;
                    if (length > 20)
                    {
                        MessageBox.Show("Last name can be of max size 20");
                    }
                }
            }
            else
            {
                MessageBox.Show("Last name cannot be empty");
            }
        }

        private void middleInitialTextBox_Validating(object sender, CancelEventArgs e)
        {
            string middleName = middleInitialTextBox.Text;
            if (middleName != string.Empty)
            {
                if (middleName.Any(ch => !(Char.IsLetterOrDigit(ch) || Char.IsWhiteSpace(ch))))
                {
                    MessageBox.Show("Middle name contains invalid character");
                }
                else
                {
                    int length = middleName.Length;
                    if (length > 1)
                    {
                        MessageBox.Show("Middle name can be of max size 1");
                    }
                }
            }
        }

        private void address1TextBox_Validating(object sender, CancelEventArgs e)
        {
            string addr= address1TextBox.Text;
            if (addr != string.Empty)
            {
                if (addr.Any(ch => !(Char.IsLetterOrDigit(ch) || Char.IsWhiteSpace(ch) || Char.Equals(ch,',')  || Char.Equals(ch, '-'))))
                {
                    MessageBox.Show("Address1 contains invalid characters");
                }
                else
                {
                    int length = addr.Length;
                    if (length > 35)
                    {
                        MessageBox.Show("Address1 can be of max size 35");
                    }
                }
            }
            else
            {
                MessageBox.Show("Address1 cannot be empty");
            }
        }

        private void address2TextBox_Validating(object sender, CancelEventArgs e)
        {
            string addr2 = address2TextBox.Text;
            if (addr2 != string.Empty)
            {
                if (addr2.Any(ch => !(Char.IsLetterOrDigit(ch) || Char.IsWhiteSpace(ch) || Char.Equals(ch, ',') || Char.Equals(ch, '-'))))
                {
                    MessageBox.Show("Address2 contains invalid characters");
                }
                else
                {
                    int length = addr2.Length;
                    if (length > 35)
                    {
                        MessageBox.Show("Address1 can be of max size 35");
                    }
                }
            }
        }

        private void cityTextBox_Validating(object sender, CancelEventArgs e)
        {
            string city = cityTextBox.Text;
            if (city != string.Empty)
            {
                if (city.Any(ch => !(Char.IsLetterOrDigit(ch) || Char.IsWhiteSpace(ch) || Char.Equals(ch, '-') || Char.Equals(ch, '\''))))
                {
                    MessageBox.Show("Address1 contains invalid characters");
                }
                else
                {
                    int length = city.Length;
                    if (length > 25)
                    {
                        MessageBox.Show("Address1 can be of max size 25");
                    }
                }
            }
            else
            {
                MessageBox.Show("City cannot be empty");
            }
        }

        private void stateTextBox_Validating(object sender, CancelEventArgs e)
        {
            string state = stateTextBox.Text;
            if (state != string.Empty)
            {
                if (state.Any(ch => !Char.IsLetter(ch)))
                {
                    MessageBox.Show("State contains invalid characters");
                }
                else
                {
                    int length = state.Length;
                    if (length != 2)
                    {
                        MessageBox.Show("State should of length 2");
                    }else
                    {
                        if (!states.Contains(state.ToUpper()))
                        {
                            MessageBox.Show("Invalid state");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("State cannot be empty");
            }
        }

        private void zipCodeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void zipCodeTextBox_Validating(object sender, CancelEventArgs e)
        {
            string zipCode = zipCodeTextBox.Text;
            if (zipCode != string.Empty)
            {
                if (zipCode.Any(ch => !Char.IsDigit(ch)))
                {
                    MessageBox.Show("Zip code should contain only numbers");
                }
                else
                {
                    int length = zipCode.Length;
                    if (length > 9)
                    {
                        MessageBox.Show("Zip code can be of max length 9");
                    }
                }
            }
            else
            {
                MessageBox.Show("Zip code cannot be empty");
            }
        }

        private void phoneNumTextBox_TextChanged(object sender, EventArgs e)
        {
            string phoneNumber = phoneNumTextBox.Text;
            if (phoneNumber != string.Empty)
            {
                if (phoneNumber.Any(ch => !Char.IsDigit(ch)))
                {
                    MessageBox.Show("Phone Number should contain only digits");
                }
                else
                {
                    int length = phoneNumber.Length;
                    if (length > 21)
                    {
                        MessageBox.Show("Phone Number can be of max length 21");
                    }
                }
            }
            else
            {
                MessageBox.Show("Phone Number cannot be empty");
            }
        }

        private void phoneNumTextBox_Validating(object sender, CancelEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
          
            Boolean foundRecord = false;
            LinkedList<Record> tempList = rh.getList();
            foreach (Record r in tempList)
            {
                if (r.firstName == firstNameTextBox.Text && r.lastName == lastNameTextBox.Text && r.phoneNumber == phoneNumTextBox.Text)
                {

                
                    foundRecord = true;
                }
            }
            if (foundRecord)
            {
                MessageBox.Show("Some other record exists with same firstname, lastname,phonenumber");
            }
            else
            {
                String gender = "M";
                String proofOfPurchase = "Y";
                String dateReceived = monthTxtBox.Text + "/" + dateTxtBox.Text + "/" + yearTxtBox.Text;
                if (radioButton2.Checked)
                {
                    gender = "F";
                }
                if (radioButton4.Checked)
                {
                    proofOfPurchase = "N";
                }
                String addr2 = "";
                if (address2TextBox.Text != String.Empty)
                {
                    addr2 = address2TextBox.Text;
                }
                MessageBox.Show("Add button clicked");
                Record r = new Record(firstNameTextBox.Text, lastNameTextBox.Text, middleInitialTextBox.Text,
                    address1TextBox.Text, addr2, cityTextBox.Text, stateTextBox.Text,
                    zipCodeTextBox.Text, gender, phoneNumTextBox.Text, emailTextBox.Text, proofOfPurchase, dateReceived);

                rh.addRecord(r);
                loadListBox();
                rh.writeRecord();
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
            middleInitialTextBox.Clear();
            address1TextBox.Clear();
           
            cityTextBox.Clear();
            stateTextBox.Clear();
            zipCodeTextBox.Clear();

            radioButton1.Select();
            radioButton3.Select();

            phoneNumTextBox.Clear();
            emailTextBox.Clear();

            dateTxtBox.Clear();
            monthTxtBox.Clear();
            yearTxtBox.Clear();
            address2TextBox.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void findAndFillForm(string fname,string lname,string phoneNumber)
        {
            Record foundRecord = null;
            foreach(Record r in rh.getList())
            {
                if(r.firstName==fname && r.lastName==lname && r.phoneNumber == phoneNumber)
                {
                    foundRecord = r;
                    selectedR = r;
                }
            }

            if (foundRecord != null)
            {
                firstNameTextBox.Text = foundRecord.firstName;
                lastNameTextBox.Text = foundRecord.lastName;
                middleInitialTextBox.Text = foundRecord.middleName;
                address1TextBox.Text = foundRecord.address1;
                address2TextBox.Text = foundRecord.address2;
                cityTextBox.Text = foundRecord.city;
                stateTextBox.Text = foundRecord.state;
                zipCodeTextBox.Text = foundRecord.zipCode;

                phoneNumTextBox.Text = foundRecord.phoneNumber;
                emailTextBox.Text = foundRecord.email;


                String[] date = foundRecord.dateReceived.Split('/');
                monthTxtBox.Text = date[0];
                dateTxtBox.Text = date[1];
                yearTxtBox.Text = date[2];

                if (foundRecord.gender == "F")
                {
                    radioButton2.Select();

                }

                if (foundRecord.proofPurchase == "N")
                {
                    radioButton4.Select();
                }
                
            }

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = listView1.SelectedIndices[0];
            string fname = listView1.Items[i].Text;
            string lname = listView1.Items[i].SubItems[1].Text;
            string phoneNumber= listView1.Items[i].SubItems[3].Text;
            //   MessageBox.Show(fname+" "+lname+" "+phoneNumber);
            findAndFillForm(fname,lname,phoneNumber);

        
    }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
        
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            
            if (firstNameTextBox.Text != string.Empty && lastNameTextBox.Text != string.Empty && phoneNumTextBox.Text!=string.Empty)
            {
                //validation
                Record found = new Record();
                Boolean foundRecord = false;
                LinkedList<Record> tempList = rh.getList();
                tempList.Remove(selectedR);
                foreach (Record r in tempList)
                {
                    if (r.firstName == firstNameTextBox.Text && r.lastName == lastNameTextBox.Text && r.phoneNumber == phoneNumTextBox.Text)
                    {
                        
                        found = r;
                        foundRecord = true;
                    }
                }
                if(foundRecord)
                {
                    MessageBox.Show("Some other record exists with same firstname, lastname,phonenumber");
                }else
                {
                    rh.lr.Remove(selectedR);
                    String gender = "M";
                    String proofOfPurchase = "Y";
                    String dateReceived = monthTxtBox.Text + "/" + dateTxtBox.Text + "/" + yearTxtBox.Text;
                    if (radioButton2.Checked)
                    {
                        gender = "F";
                    }
                    if (radioButton4.Checked)
                    {
                        proofOfPurchase = "N";
                    }
                    String addr2 = "";
                    if (address2TextBox.Text != String.Empty)
                    {
                        addr2 = address2TextBox.Text;
                    }
                    MessageBox.Show("Added new record");
                    Record r = new Record(firstNameTextBox.Text, lastNameTextBox.Text, middleInitialTextBox.Text,
                        address1TextBox.Text, addr2, cityTextBox.Text, stateTextBox.Text,
                        zipCodeTextBox.Text, gender, phoneNumTextBox.Text, emailTextBox.Text, proofOfPurchase, dateReceived);

                    rh.addRecord(r);
                    loadListBox();
                    rh.writeRecord();
                }
            }
            else
            {
                MessageBox.Show("Double click the listed record to modify");
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           

    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
            if (firstNameTextBox.Text != string.Empty && lastNameTextBox.Text != string.Empty && phoneNumTextBox.Text != string.Empty)
            {
                rh.lr.Remove(selectedR);
                loadListBox();
                rh.writeRecord();
            }
            else
            {
                MessageBox.Show("Double click the listed record and then click delete");
            }
        }
    }
}
