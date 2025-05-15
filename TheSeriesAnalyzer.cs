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
        // show the options to the yusr. receives and returns his choice.
        {
            string selectedOption;
            Console.WriteLine("\n To insert a new list, press 1. \n" +
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
        // manager all the series analysis
        {
            
            string runAgain;
            bool newList = false;
            float[] numbers = new float[0];
            
            
            do
            {
                if (inputConfirmation(arrNumbers))
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
                    } while (!inputConfirmation(numbers));

                }
                runAgain = menu();


                switch (runAgain)
                {
                    case "1":
                        newList = true;
                        //Console.WriteLine("new list");
                        break;
                    case "2":
                        showAsEntered(numbers);
                        //Console.WriteLine("series in order");
                        break;
                    case "3":
                        showInReversed(numbers);
                        //Console.WriteLine("series in reverse order");
                        break;
                    case "4":
                        showInOrder(numbers);
                        //Console.WriteLine("series in ascending order");
                        break;
                    case "5":
                        showMax(numbers);
                        //Console.WriteLine("maximum number");
                        break;
                    case "6":
                        showMin(numbers);
                        //Console.WriteLine("minimum number");
                        break;
                    case "7":
                        showAverage(numbers);
                        //Console.WriteLine("series average");
                        break;
                    case "8":
                        showAmountNumbers(numbers);
                        //Console.WriteLine("number of numbers recorded");
                        break;
                    case "9":
                        showSum(numbers);
                        //Console.WriteLine("sum of series");
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

        static bool inputConfirmation(float[] arrNumbers)
        {
            int count = 0;
            foreach (float num in arrNumbers)
            {
                if (num > 0)
                {
                    count++;
                }
            }
            Console.WriteLine("count================" + count);
            return count >= 3;
        }


        static float[] insertNewList()
        // function which operates a number of functions below. by them she received string from the yusr.
        // and returns array with numbers only.
        {
            string stringOfNumbers = inputSeries();
            string[] listOfStrings = stringToListString(stringOfNumbers);
            List<float> listOfFloat = leavNum(listOfStrings);
            float[] numbers = listToArray(listOfFloat);
            return numbers;
        }
        static string inputSeries()
        // function that received from the user string, and returns it. The goal is to get some numbers.
        {
            Console.WriteLine("insert a list of numbers, insert at least trhee numbers");
            string stringOfNumbers = Console.ReadLine();
            return stringOfNumbers;
        }

        static string[] stringToListString(string str)
        // function that accepts string, and returns him in a array. each word in a different organ.
        {
            string[] listOfStrings = str.Split(' ');
            return listOfStrings;
        }

        static float[] listToArray(List<float> numbers)
        // function that accepts list with flout numbers, and returns them in a array.
        {
            float[] arrNumbers = new float[numbers.Count];
            for (int i = 0; i < numbers.Count; i++)
            {

                arrNumbers[i] = numbers[i];
            }
            return arrNumbers;
        }
        static List<float> leavNum(string[] listSrt )
        // function that accepts string[], converting each number to flout,
        // and returns list of flout of all numbers that found in the string[].
        {
            List<float> numbers = new List<float>();
            foreach (string str in listSrt)
            {
                if (float.TryParse(str, out float result))
                { 
                    numbers.Add(result);
                };
            }

            return numbers;
        }
        static void showAsEntered(float[] numbers)
        // showlist of numbers as entered.
        {
            foreach (float number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        static void showInReversed(float[] numbers)
        // show list of numbers from the end of the list to the beginning.
        {
            for (int i = 1; i <= numbers.Length; i++) 
            { 
            Console.Write(numbers[numbers.Length - i] + " ");
            }
            Console.WriteLine();
        }


        static void showInOrder(float[] numbers)
        // show list of numbers from the min to max number.
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
        // Finds the minimum number from the list, and show them.
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
        // Calculates the sum of all numbers in a list, and returns them.
        {
            float sum = 0;
            foreach (float number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        static void showMax(float[] numbers)
        // Finds the maximum number from the list, and show them.
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
        // Calculates the average of all numbers in a list, and show them.
        {
            float sum = sumNum(numbers);
            Console.WriteLine(sum / numbers.Length);
        }

        static void showAmountNumbers(float[] numbers)
        // Calculates the amount of numbers in a list, and show them.
        {
            Console.WriteLine(numbers.Length);
        }

        static void showSum(float[] numbers)
        // show the sum of all the numbers in a list.
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
                List<float> numbers = leavNum(args);
                float[] arrNum = listToArray(numbers);
                SeriesAnalysisManager(arrNum);
            };

        }
    }
}
