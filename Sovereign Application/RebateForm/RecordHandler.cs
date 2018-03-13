using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RebateForm
{
    class RecordHandler
    {
       public  LinkedList<Record> lr;
        String fileName;

        public RecordHandler()
        {
            lr=new LinkedList<Record>();
            fileName = "CS6326Asg2.txt";
            Console.WriteLine("Size in before constr" + lr.Count());
            if (File.Exists(fileName))
            {
                int count = 1;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string s = "";
                    
                    while ((s = sr.ReadLine()) != null)
                    {
                      Console.WriteLine("Line: "+(count++));
                        string[] split = s.Split('\t');
                       
                            Record r = new Record(split[0], split[1], split[2], split[3], split[4], split[5],
                                split[6], split[7], split[8], split[9], split[10],
                                split[11],split[12],split[13],split[14],split[15]);
                            lr.AddLast(r);
                        
                    }
                }
                Console.WriteLine("Size in constr" + lr.Count());
            }
        }

        public LinkedList<Record> getList()
        {
            return lr;
        }

        public void addRecord(Record r)
        {
            lr.AddLast(r);
            Console.WriteLine("Size "+lr.Count());
            writeRecord();
        }

        public void writeRecord()
        {
             Console.WriteLine( " directory "+Directory.GetCurrentDirectory());

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
                // Create a file to write to.
                Console.WriteLine("Add record .......");
               
                using (StreamWriter sw = File.CreateText(fileName))
                {
                foreach (Record r in lr)
                {
                    sw.WriteLine(r.firstName + "\t" + r.lastName + "\t" + r.middleName + "\t" + r.address1 + "\t" + r.address2 +
                        "\t" + r.city + "\t" + r.state + "\t" + r.zipCode + "\t" + r.gender + "\t" + r.phoneNumber + "\t" + r.email + "\t"
                        + r.proofPurchase + "\t" + r.dateReceived+"\t"+r.firstKeyPressTime+"\t"+r.saveTime+"\t"+r.backSpaceKeyPressCount
                        );
                }
                  
                }
        }
    }
}
