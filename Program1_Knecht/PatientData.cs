using SimpleLinkedList;
using System;
using System.IO;
//COLIN KNECHT ===================================
//PROGRAM 1 ====================================
//CPT 244 ========================================
namespace PatentData
{
    class PatientData
    {
        private int numSlotsInArray;
        private SimpleLinkedList<Patient>[] list;

        /// <summary>
        /// Constructor.  Instantiates the array based on the size passed to the constructor.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        public PatientData(int size)
        {
            list = new SimpleLinkedList<Patient>[size];
        }

        /// <summary>
        /// Loads patients into the data structure from the filename passed as a parameter.
        /// </summary>
        /// <param name="filename">Path to the file where the patient data is kept.  The format is: <para>first,last,procedureCost</para></param>
        public void LoadPatients(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader input = new StreamReader(fs);

            while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                string[] fields = line.Split(",".ToCharArray());
                // TODO create the new patient
                Patient p = new Patient(fields[1], fields[0], Double.Parse(fields[2]));

                // TODO add the patient to the list
                //test
                AddPatient(p);
            }
        }

        /// <summary>
        /// Adds a patient to the data structure.
        /// </summary>
        /// <param name="patient">The patient to be added.</param>
        public void AddPatient(Patient patient)
        {
            // TODO add code needed to add a patient
            int size = list.Length;
            int target = patient.Id % size;


            // Find the correct index
            // Add the patient to the linked list

            //list[target].AddAtHead(patient);
            // Create a new list if there isn't one at this index

            if (list[target] == null)
            {
                list[target] = new SimpleLinkedList<Patient>();
                list[target].AddAtHead(patient);
            }
            else
            {
                list[target].AddAtHead(patient);
            }
        }

        public Patient FindPatientByName(string first, string last)
        {
            Patient pat = null;
            // TODO
            // create a patient using the names; the cost can be zero since it isn't used in the comparison
            // use the patient you created to get the id, slot in the array and finally the data in the linked list
            Patient p = new Patient(first, last, 0);
            int size = list.Length;
            int target = p.Id % size;
            if (list[target] == null)
            {
                //Console.WriteLine("No List at array slot: " + target);
                return null;
            }
            int pID = p.Id;
            pat = list[target].Find(p);
            if (list[target].Find(p) == null)
            {
                return null;
            }

            return pat;
        }

        public int FindLongestLength()
        {
            int max = 0;
            int size = list.Length;
            int temp;
            // TODO for 'B' grade
            for (int i = 0; i < size; i++)
            {
                if (list[i] == null)
                {
                    continue;
                }
                temp = list[i].Count;
                if (i > 0 && list[i - 1] == null)
                {
                    continue;
                }
                else if (i != 0 && temp > list[i - 1].Count)
                {
                    max = temp;
                }

            }
            return max;
        }

        public double FindAverageSlotLength()
        {
            double average = 0;
            int size = list.Length;
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                if (list[i] == null)
                {
                    continue;
                }
                sum += list[i].Count;
            }
            average = (double)sum / (double)size;

            return average;
        }

        public Patient RemovePatientById(int id)
        {
            Patient pat = null;
            // TODO for 'A' grade
            // remove the patient
            // return the data
            int size = list.Length;
            int target = id % size;
            Patient p = new Patient("", "", 0, id);
            //p.Id = pat.Id;

            pat = list[target].Remove(p);


            return pat;
        }
        public int getNumSlotsInArray()
        {
            numSlotsInArray = list.Length;
            return numSlotsInArray;
        }

        public double getPercentSlotsUsed()
        {
            double answer;
            double finalAnswer;
            int count = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] != null)
                {
                    count++;
                }
            }
            answer = (double)count / (double)list.Length;
            finalAnswer = answer * 100;
            finalAnswer = Math.Round(finalAnswer);
            return finalAnswer;
        }

    }
}
