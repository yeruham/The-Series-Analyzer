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


        static void SeriesAnalysisManager(float[] arrNumbers)
        {
            
            string runAgain;
            bool newList = false;
            float[] numbers = new float[0];
            
            
            do
            {
                if (arrNumbers.Length > 3)
                {
                    numbers = arrNumbers;
                }
                else
                {
                    newList = true;
                }
                if (newList)
                {
                    do
                    {
                        numbers = insertNewList();
                        newList = false;
                    } while (numbers.Length < 3);

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
            List<float> listOfFloat = leavPositiveNum(listOfStrings);
            float[] numbers = listToArray(listOfFloat);
            return numbers;
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

        static float[] listToArray(List<float> numbers)
        {
            float[] arrNumbers = new float[numbers.Count];
            for (int i = 0; i < numbers.Count; i++)
            {

                arrNumbers[i] = numbers[i];
            }
            return arrNumbers;
        }
        static List<float> leavPositiveNum(string[] listSrt )
        {
            List<float> numbers = new List<float>();
            foreach (string str in listSrt)
            {
                if (float.TryParse(str, out float result))
                {
                    if (result > 0) { 
                    numbers.Add(result);
                }
                };
            }

            return numbers;
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

            if (args.Length == 0)
            {
                SeriesAnalysisManager(new float[0]);
            }
            else 
            {
                List<float> numbers = leavPositiveNum(args);
                float[] arrNum = listToArray(numbers);
                SeriesAnalysisManager(arrNum);
            };

            
            //string[] s = { "2", "9.5", "i7", "poi", "90", "-89", "00908"};
            //float[] num = leavPositiveNum(s);
            //Console.WriteLine(num.Length + " length");
            //foreach (float number in num)
            //{
            //    Console.WriteLine(number);
            //}

        }
    }
}
