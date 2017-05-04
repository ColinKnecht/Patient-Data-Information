using System;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    //COLIN KNECHT ===================================
    //PROGRAM 1 ====================================
    //CPT 244 ========================================
namespace PatentData
{

    class Program
    {
        private const int LIST_SIZE = 3;

        static void showPatient(Patient p)
        {
            // TODO put code to display the patient's name, id and procedure cost here.
            Console.WriteLine("====================Patient Information=====================");
            Console.WriteLine("First Name: " + p.FirstName + " Last Name: " + p.LastName);
            Console.WriteLine("ID Number: " + p.Id + " Last Procedure Cost: $ {0:00.00}", p.ProcedureCost);
            Console.WriteLine("============================================================");
        }

        static void Main(string[] args)
        {
            char key;
            //Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.ResetColor();
            PatientData data = new PatientData(LIST_SIZE);
            data.LoadPatients("c:/Users/lori/desktop/patientList.csv");

            Console.WriteLine("Welcome to the Patient Search Program");
            Console.WriteLine("Please Select From the Menu Below");
            Console.WriteLine("(F)ind -- (S)tatistics -- (R)emove -- (Q)uit");
            key = Console.ReadLine()[0];
            while (key != 'Q' && key != 'q')
            {
                if (key == 'F' || key == 'f')
                {
                    Console.WriteLine("What is the Name of the Patient you are looking for?");
                    string name = Console.ReadLine();
                    string[] names = name.Split();
                    if (names.Length != 2)
                    {
                        Console.WriteLine("Enter First and last Name with a space in the middle please");
                        name = Console.ReadLine();
                        names = name.Split();
                    }
                    Patient.Comparisons = 0;
                    Patient pat = data.FindPatientByName(names[0], names[1]);
                    if (pat != null)
                    {
                        showPatient(pat);
                        Console.WriteLine("Comparisions: {0}", Patient.Comparisons);
                        Console.WriteLine("(F)ind -- (S)tatistics -- (R)emove -- (Q)uit");
                        key = Console.ReadLine()[0];
                    }
                    else
                    {
                        Console.WriteLine("Patient Not Found");

                        Console.WriteLine("(F)ind -- (S)tatistics -- (R)emove -- (Q)uit");
                        key = Console.ReadLine()[0];
                    }

                }
                else if (key == 'S' || key == 's')
                {
                    Console.WriteLine(">----Statistics----<");
                    Console.WriteLine("Number of Slots in Array: " + data.getNumSlotsInArray());
                    Console.WriteLine("Percentage of Slots Used: " + data.getPercentSlotsUsed() + "%");
                    Console.WriteLine("Maximum List Length: " + data.FindLongestLength());
                    Console.WriteLine("Average Length of Lists: {0:00.0}", data.FindAverageSlotLength());

                    Console.WriteLine("(F)ind -- (S)tatistics -- (R)emove -- (Q)uit");
                    key = Console.ReadLine()[0];
                }
                else if (key == 'R' || key == 'r')
                {
                    Console.WriteLine(">----Remove Patient----<");
                    Console.WriteLine("Enter Patient's ID Number (6 Digits)");
                    string id = Console.ReadLine();

                    int idNum = int.Parse(id);
                    data.RemovePatientById(idNum);

                    Console.WriteLine("(F)ind -- (S)tatistics -- (R)emove -- (Q)uit");
                    key = Console.ReadLine()[0];
                }
                else
                {
                    Console.WriteLine("Invalid Key Command -- Please Select From the Menu");

                    Console.WriteLine("(F)ind -- (S)tatistics -- (R)emove -- (Q)uit");
                    key = Console.ReadLine()[0];
                }
            }//end menu while

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("============Program Terminated============");
            Console.ReadLine();
        }
    }
}
