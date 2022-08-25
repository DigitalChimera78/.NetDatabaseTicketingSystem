using System;
using System.IO;

namespace Assignment___TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "ticketing.csv";
            string choice;

            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");

                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] data = line.Split(',');
                            string[] watching = data[data.Length - 1].Split('|');

                            Console.WriteLine("Ticket #" + data[0]);
                            Console.WriteLine("Summary: " + data[1]);
                            Console.WriteLine("Status: " + data[2]);
                            Console.WriteLine("Priority: " + data[3]);
                            Console.WriteLine("Submitted by: " + data[4]);
                            Console.WriteLine("Assigned to: " + data[5]);
                            Console.Write("Watched by: ");

                            for (int i = 0; i < watching.Length; i++)
                            {   
                                if (i == watching.Length - 1)
                                {
                                    Console.WriteLine(watching[i]);
                                }
                                else
                                {
                                Console.Write(watching[i] + ", ");
                                }
                            }
                            /*string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split('|');
                            // display array data
                            Console.WriteLine("Course: {0}, Grade: {1}", arr[0], arr[1]);
                            // add to accumulators
                            gradePoints += arr[1] == "A" ? 4 : arr[1] == "B" ? 3 : arr[1] == "C" ? 2 : arr[1] == "D" ? 1 : 0;
                            count += 1;*/
                        }

                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    int j = 0;
                    string resp;
                    do
                    {
                        string delimOne = j.ToString();
                        Console.WriteLine("Enter ticket summary: ");
                        delimOne += "," + Console.ReadLine();
                        Console.WriteLine("Enter ticket status: ");
                        delimOne += "," + Console.ReadLine();
                        Console.WriteLine("Enter ticket priority: ");
                        delimOne += "," + Console.ReadLine();
                        Console.WriteLine("Enter who submitted this ticket: ");
                        delimOne += "," + Console.ReadLine();
                        Console.WriteLine("Enter who is assigned this ticket: ");
                        delimOne += "," + Console.ReadLine();

                        Console.WriteLine("How many users are watching this ticket?");
                        int x = int.Parse(Console.ReadLine());
                        string delimTwo = "";

                        for (int i = 0; i < x; i++)
                        {
                            if (i == 0)
                            {
                                Console.WriteLine("Enter user: ");
                                delimTwo = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Enter user: ");
                                delimTwo += "|" + Console.ReadLine();
                            }
                        }

                        sw.WriteLine("{0},{1}", delimOne, delimTwo);

                        j++;
                        Console.WriteLine("Enter another ticket? y/n");
                        resp = Console.ReadLine();
                        /*
                        // ask a question
                        Console.WriteLine("Enter a course (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }
                        // prompt for course name
                        Console.WriteLine("Enter the course name.");
                        // save the course name
                        string name = Console.ReadLine();
                        // prompt for course grade
                        Console.WriteLine("Enter the course grade.");
                        // save the course grade
                        string grade = Console.ReadLine().ToUpper();
                        sw.WriteLine("{0}|{1}", name, grade);*/
                    } while (resp.ToUpper() == "Y");
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
