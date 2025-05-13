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
        static string menu()
        {
            string selectedOption;
            Console.WriteLine("To insert a new list, press 1. \n" +
                          "To display the series in the order entered, press 2. \n" +
                          "To view the series in reverse order, press 3. \n" +
                          "For the series in ascending order, press 4 \n" +
                          "To the maximum number, press 5 \n" +
                          "To the minimum number, press 6 \n" +
                          "For the series average, press 7 \n" +
                          "For the number of numbers recorded, press 8 \n" +
                          "For sum of the series, press 9 \n" +
                          "To exsit, press 0 \n");
            selectedOption = Console.ReadLine();

            return selectedOption;
        }


        static void SeriesAnalysisManager()
        {

            string runAgain;
            bool newList = false;
            float[] numbers = insertNewList();

            do
            {
                if (newList)
                {
                    numbers = insertNewList();
                    newList = false;
                }
                runAgain = menu();

                switch (runAgain)
                {
                    case "1":
                        newList = true;
                        Console.WriteLine("new list");
                        break;
                    case "2":
                        showAsEntered(numbers);
                        Console.WriteLine("series in order");
                        break;
                    case "3":
                        showInReversed(numbers);
                        Console.WriteLine("series in reverse order");
                        break;
                    case "4":
                        showInOrder(numbers);
                        Console.WriteLine("series in ascending order");
                        break;
                    case "5":
                        showMax(numbers);
                        Console.WriteLine("maximum number");
                        break;
                    case "6":
                        showMin(numbers);
                        Console.WriteLine("minimum number");
                        break;
                    case "7":
                        showAverage(numbers);
                        Console.WriteLine("series average");
                        break;
                    case "8":
                        showAmountNumbers(numbers);
                        Console.WriteLine("number of numbers recorded");
                        break;
                    case "9":
                        showSum(numbers);
                        Console.WriteLine("sum of series");
                        break;
                    case "0":
                        Console.WriteLine("exsit");
                        break;
                    default:
                        Console.WriteLine("invalid input. please try agine!");
                        break;
                }
            } while (runAgain != "0");
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
                listOfFloat[i] = Convert.ToSingle(listOfStrings[i]);
            }
            return listOfFloat;
        }

        static bool validate()
        {
            return true;
        }
        static void showAsEntered(float[] numbers)
        {
            foreach (float number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static void showInReversed(float[] numbers)
        {
            for (int i = 1; i <= numbers.Length; i++) 
            { 
            Console.Write(numbers[numbers.Length - i] + " ");
            }
            Console.WriteLine();
        }


        static void showInOrder(float[] numbers)
        {
            float[] copy = numbers.ToArray();
            Array.Sort(copy);
            foreach (float number in copy)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static void showMin(float[] numbers)
        {
            float min = numbers[0];
            foreach (float number in numbers)
            {
                if(number < min)
                {
                    min = number;
                }
            }
            Console.WriteLine(min);
        }

        static float sumNum(float[] numbers)
        {
            float sum = 0;
            foreach (float number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        static void showMax(float[] numbers)
        {
            float max = numbers[0];
            foreach (float number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine(max);
        }


        static void showAverage(float[] numbers)
        {
            float sum = sumNum(numbers);
            Console.WriteLine(sum / numbers.Length);
        }

        static void showAmountNumbers(float[] numbers)
        {
            Console.WriteLine(numbers.Length);
        }

        static void showSum(float[] numbers)
        {
            Console.WriteLine(sumNum(numbers));
        }

        static void Main(string[] args)
        {

            SeriesAnalysisManager();

        }
    }
}
