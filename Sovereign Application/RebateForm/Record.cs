using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebateForm
{
    
    class Record
    {
        
        public string firstName;
        public string lastName;
        public string middleName;
        public string address1;
        public string address2;
        public string city;
        public string state;
        public string zipCode;
        public string gender;
        public string email;
        public string proofPurchase;
        public string dateReceived;
        public string phoneNumber;
        public string firstKeyPressTime;
        public string saveTime;
        public string backSpaceKeyPressCount;
        public Record()
        {
            firstName = "";
            lastName = "";
            middleName = "";
            address1 = "";
            address2 = "";
            city = "";
            state = "";
            zipCode ="";
            gender = "";
            phoneNumber = "";
           
            email ="";
            proofPurchase ="";
            dateReceived = "";
            firstKeyPressTime = "";
            saveTime = "";
            backSpaceKeyPressCount = "";
        }

        public Record(string firstName1,string lastName1, string middleName1, string addrs1, string addrs2,
             string cty, string  st, string  zipcode, string  gendr, string  phoneNum,
              string emailID, string proofOfPurchase, string dateRecd,string firstKeyPrsTime,string savetime,string backSpaceKeyCount)
        {
            firstName = firstName1;
            lastName = lastName1;
            middleName = middleName1;
            address1 = addrs1;
            address2 = addrs2;
            city = cty;
            state = st;
            zipCode = zipcode;
            gender = gendr;
            phoneNumber = phoneNum;
            email = emailID;
            proofPurchase = proofOfPurchase;
            dateReceived = dateRecd;
            firstKeyPressTime = firstKeyPrsTime;
            saveTime = savetime;
            backSpaceKeyPressCount = backSpaceKeyCount;

 
            Console.WriteLine("Add record in constructed");
        }

    }
}
