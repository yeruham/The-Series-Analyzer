using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSeriesAnalyzer
{
    internal class TheSeriesAnalyzer
    {

        static void SeriesAnalysisManager()
        {
            bool runAgain = true;
            do
            {
                menu();
            }            
            while (runAgain);
        }


        static void menu()
        {
            int selectedOption = 0;

                Console.WriteLine("To insert a new list, press 1. \n" +
                              "To display the series in the order entered, press 2. \n" +
                              "To view the series in reverse order, press 3. \n" +
                              "For the series in ascending order, press 4 \n" +
                              "To the maximum number, press 5 \n" +
                              "To the minimum number, press 6 \n" +
                              "For the series average, press 7 \n" +
                              "For the number of numbers recorded, press 8 \n" +
                              "To exsit, press 9 \n");

            selectedOption = Convert.ToInt32(Console.ReadLine());

            switch (selectedOption)
                {
                    case 1:
                        Console.WriteLine("new list");
                        break;
                    case 2:
                        Console.WriteLine("series in order");
                        break;
                    case 3:
                        Console.WriteLine("series in reverse order");
                        break;
                    case 4:
                        Console.WriteLine("series in ascending order");
                        break;
                    case 5:
                        Console.WriteLine("maximum number");
                        break;
                    case 6:
                        Console.WriteLine("minimum number");
                        break;
                    case 7:
                        Console.WriteLine("series average");
                        break;
                    case 8:
                        Console.WriteLine("number of numbers recorded");
                        break;
                case 9:
                    Console.WriteLine("exsit");
                    break;
            }
            
        }

        static float[] insertNewList()
        {
            string stringOfNumbers = inputSeries();
            string[] listOfStrings = stringToListString(stringOfNumbers);
            float[] listOfFloat = listStrToListFloat(listOfStrings);
            return listOfFloat;
        }
        static string inputSeries()
        {
            Console.WriteLine("insert a list of numbers, insert at least trhee numbers");
            string stringOfNumbers = Console.ReadLine();
            return stringOfNumbers;
        }

        static string[] stringToListString(string str)
        {
            string[] listOfStrings = str.Split(' ');
            return listOfStrings;
        }

        static float[] listStrToListFloat(string[] listOfStrings)
        {
            float[] listOfFloat = new float[listOfStrings.Length];
            for (int i = 0; i < listOfStrings.Length; i++)
            {
                listOfFloat[i] = float.Parse(listOfStrings[i]);
            }
            return listOfFloat;
        }




        static void Main(string[] args)
        {

            SeriesAnalysisManager();
        }
    }
}
