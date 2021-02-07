using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CowsAndBulls
{
    //Chicago Bulls and Cows

    class Program
    {
        // the array to read the numbers
        // If you don't know what is this: https://metanit.com/sharp/tutorial/4.3.php
        // And about array https://metanit.com/sharp/tutorial/2.4.php

        public static ArrayList list = new ArrayList();
        public static int count = 0;

        public static ArrayList userList = new ArrayList();
        public static int userCount = 0;

        static void Main(string[] args) // Entry point start of the code
        {
            int modeSelector;
            string modeInput;
            do
            {
                Console.Clear();
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t╔=====================================╗");
                    Console.WriteLine("\t\t║ Mode 1: User/length guess ");
                    Console.WriteLine("\t\t║ Mode 2: Length guess ");
                    Console.WriteLine("\t\t║ Mode 3: AI vs You ");
                    Console.WriteLine("\t\t║ Mode 4: Secret ");
                    Console.WriteLine("\t\t║ Mode 5: Instruction about the game ");
                    Console.WriteLine("\t\t╚=====================================╝");
                    Console.Write("\t\t║Which Mode do you want?: ");
                    modeInput = Console.ReadLine();
                } while (!int.TryParse(modeInput, out modeSelector) || modeSelector < 1 || modeSelector > 5);

                if (modeSelector == 1)
                {
                    UserGuess();
                }
                else if (modeSelector == 2)
                {
                    UserLengthGame();
                }
                else if (modeSelector == 3)
                {
                    AiVsYou();
                }
                else if (modeSelector == 4)
                {
                    Secret();
                }
                else if (modeSelector == 5)
                {
                    Instruction();
                }
                Console.WriteLine("\t\t║ Press ESC to exit the game...");
                Console.WriteLine("\t\t╚=========================================╝");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        public static void AiVsYou()
        {
            Console.WriteLine("\t\t║ Guess mutual numbers, as soon as possible.");
            Console.WriteLine("\t\t║ You first");

            //assigning variables from the method generating random numbers from an Array
            //Which will guess your winning percentage
            list = ListArrayGenerator();
            userList = ListArrayGenerator();
            bool userWin = false;
            bool aiWin = false;
            int answerList = ListArrayNumberGenerator();

            // Checking the validity of computer and user winnings
            while (!userWin && !aiWin)
            {
                //Creating an Array
                int[] answer = new int[4];

                //Sorting by numbers
                answer[0] = (answerList / 1000);
                answer[1] = (answerList / 100) % 10;
                answer[2] = (answerList / 10) % 10;
                answer[3] = (answerList % 10);

                //Attaching the answer array to the method UserGame()
                userWin = UserGame(answer);
                //If the variable after the method is still false, the program will terminate (break)
                if (userWin)
                {
                    break;
                }
                // Assigning a method in aiWin
                aiWin = Game();
                if (aiWin)
                {
                    break;
                }
                //checking the winrate of the computer and the user
                double comWinRate = Math.Round(100 - ((double)list.Count / 5040) * 100);
                double userWinRate = Math.Round(100 - ((double)userList.Count / 5040) * 100);

                Console.WriteLine($"\t\t║ AI win rate: {(double)(comWinRate / (comWinRate + userWinRate)) * 100} %, Your win rate: {(double)(userWinRate / (comWinRate + userWinRate)) * 100} %");
                // For example, the result: AI win rate: 54%, Your win rate: 46%

            }
        }
        /// <summary>
        ///Instructions and in principle the rules of the game
        /// </summary>
        public static void Instruction()
        {
            Console.WriteLine("\t\t╔===========================================================================================╗");
            Console.WriteLine("\t\t║ Cows are guessed numbers riddles that are out of place,");
            Console.WriteLine("\t\t║ bulls are numbers that are in their place. For example, you guess a number, such as 1234");
            Console.WriteLine("\t\t║ the opponent must guess it, for example, the opponent said 5431. ");
            Console.WriteLine("\t\t║ it turns out that there are 2 cows(4,1) and 1 bull (3)");
            Console.WriteLine("\t\t║ well, then everything is clear and simple . AThe number can be with a leading zero");
            Console.WriteLine("\t\t║ he user changes the numbers in the response and looks at how the cows and bulls will change.");
            Console.WriteLine("\t\t╚===========================================================================================╝");
        }

        /// <summary>
        /// Secret Method
        /// </summary>
        public static void Secret()
        {
            Console.WriteLine("\t\t║ Hi! If you're reading this , you're doing great! You got into the Tower!");
            Console.WriteLine("\t\t║ You're waiting for a secret, aren't you?");
            Thread.Sleep(1000);
            Console.WriteLine("\t\t║ The secret is that you are the best =)");
            Console.WriteLine("\t\t║ That's about it. Thank you for testing this code");
            Console.WriteLine("");
        }
        /// <summary>
        /// Guessing the user's number
        /// </summary>
        public static void UserGuess()
        {
            //The generation of the array and integers inside this array
            list = ListArrayGenerator();
            userList = ListArrayGenerator();
            //Assigning an array to a variable
            int ansint = ListArrayNumberGenerator();

            // Adding numbers to an array and splitting it into bits
            int[] ans = new int[4];
            ans[0] = ansint / 1000;
            ans[1] = (ansint / 100) % 10;
            ans[2] = (ansint / 10) % 10;
            ans[3] = (ansint % 10);

            //through the while loop we check for a win and the result of the attempt is displayed
            while (!UserGame(ans)) ;
            Console.WriteLine($"\t\t║ You guess  {userCount} turn(s)");
            //For example: You guess 2 turn(s)
        }
        /// <summary>
        /// Random number generator in Array
        /// </summary>
        /// <returns></returns>
        public static ArrayList ListArrayGenerator()
        {
            ArrayList list = new ArrayList();

            //Through the for loop outputs 4 numbers and adds them to the array
            for (int i = 1000; i <= 9999; i++)
            {
                int firstNum = i / 1000;
                int secondNum = (i / 100) % 10;
                int thirdNum = (i / 10) % 10;
                int fourthNum = (i % 10);

                //checking for validity
                if (firstNum != secondNum && firstNum != thirdNum && firstNum != fourthNum && secondNum != thirdNum && secondNum != fourthNum && thirdNum != fourthNum)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        /// <summary>
        /// Data validation
        /// Data validation
        /// </summary>
        /// <returns></returns>
        public static bool Game()
        {
            Random randomGuess = new Random();
            int rgNum = randomGuess.Next(1, 4);

            //setting variables
            int cow, bull, a, b;
            float rate;
            //using the method we assign values
            int guess = ListArrayNumberGenerator();
            count++;
            string result = guess.ToString();
            if (result.Count() == 3)
            {
                result = '0' + result;
            }
            rate = ((float)list.Count / 5040) * 100;
            //Check in your win rate
            Console.WriteLine($"\n\t\t║ Round  {count} : {result} , give me hints. ( Guess Rate: {(100 - rate)} % )");

            Console.Write("\t\t║ How many bulls: ");
            while (!int.TryParse(Console.ReadLine(), out bull))
            {
                Console.WriteLine("\t\t║ Incorrect input");
                Console.Write("\t\t║ How many bulls: ");
            }
            Console.Write("\t\t║ How many cows: ");
            while (!int.TryParse(Console.ReadLine(), out cow))
            {
                Console.WriteLine("\t\t║ Incorrect input");
                Console.Write("\t\t║ How many cows: ");
            }
            //Checking input data for numbers not exceeding 0 and 4
            if (bull < 0 || bull > 4 || cow < 0 || cow > 4)
            {
                Console.WriteLine("\t\t║ Incorrect input...");
                Console.WriteLine("\t\t║ Digit must be from 1 to 4");
                count--;
                Game();
            }
            else if (bull == 4 && cow == 0)
            {
                Console.WriteLine($"\t\t║ Ai win, your secret number is {result}");
                return true;
            }
            // Checking the data type
            CheckList(bull, cow, guess, true);

            if (list.Count == 1)
            {
                result = list[0].ToString();
                if (result.Count() == 3)
                {
                    result = '0' + result;
                }
                // Checking the WinRate probability
                Console.WriteLine($"\t\t║ Confirm: {count} : {result} , give me confirm ( Guess Rate: {(100 - rate)} % ");

                Console.Write("\t\t║ How many bulls: ");
                while (!int.TryParse(Console.ReadLine(), out a))
                    Console.WriteLine("\t\t║ Incorrect input");

                Console.Write("\t\t║ How many cows: ");
                while (!int.TryParse(Console.ReadLine(), out b))
                    Console.WriteLine("\t\t║ Incorrect input");
                //Checking input data
                if (a != 4 || b != 0)
                {
                    Console.WriteLine("\t\t║ You must type something wrong, try again");
                }
                else if (a == 4 && b == 0)
                {
                    Console.WriteLine($"\t\t║ Your secret number is {result} ");
                    return true;
                }
                return true;
            }
            else if (list.Count == 0)
            {
                Console.WriteLine("\t\t║ You must type something wrong, try again");
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// A method that works for calculating the user's game
        /// </summary>
        /// <param name="ans"></param>
        /// <returns></returns>
        public static bool UserGame(int[] ans)
        {
            int guess;
            string guessInput;
            //Every attemp we count 
            userCount++;
            do
            {
                Console.Write("\t\t║ Guess a four digit number: ");
                guessInput = Console.ReadLine();

            } while (!int.TryParse(guessInput, out guess) || guess < 1000 || guess > 9999);

            //After guessing, we put it in the array
            char[] guessed = guess.ToString().ToCharArray();
            //Creating counter variables for cows and bulls
            int bullsCount = 0;
            int cowsCount = 0;

            //assign variables to the for loop trace
            int curAns = 0;
            int curGuess = 0;
            for (int i = 0; i < 4; i++)
            {
                double dec = Math.Pow(10, 3 - i);
                curAns = (int)(curAns + ans[i] * dec);
                curGuess = (int)(curGuess + (int)char.GetNumericValue(guessed[i]) * dec);
            }

            // Creating a new array and assigning to a new variable
            ArrayList ab = new ArrayList();

            ab = GetNumberAB(curGuess, curAns);

            CheckList(bullsCount, cowsCount, guess, false);

            if ((int)ab[0] == 4)
            {
                Console.WriteLine("\t\t║ Congratulations! You win");
                return true;
            }
            else
            {
                Console.WriteLine($"\t\t║ {(int)ab[0]} bulls and {(int)ab[1]} cows");
                return false;
            }
        }
        /// <summary>
        /// Generate an Array with random numbers
        /// </summary>
        /// <returns></returns>
        public static int ListArrayNumberGenerator()
        {
            int number = 0;
            Random rnd = new Random();
            int index = rnd.Next(1, list.Count);
            number = (int)list[index];
            return number;
        }

        /// <summary>
        /// Validate an data type
        /// </summary>
        /// <param name="bull">Type of bull</param>
        /// <param name="cow">Type of cow</param>
        /// <param name="guess">Guess number</param>
        /// <param name="aiBot">AI</param>
        public static void CheckList(int bull, int cow, int guess, bool aiBot)
        {
            //Creating an Array
            ArrayList newList = new ArrayList();

            if (aiBot)
            {
                // reads the number of cows and bulls
                for (int i = 0; i < list.Count; i++)
                {

                    ArrayList firstAndSecond = new ArrayList();

                    firstAndSecond = GetNumberAB(guess, (int)list[i]);

                    if (bull == (int)firstAndSecond[0] && cow == (int)firstAndSecond[1])
                    {
                        newList.Add(list[i]);
                    }

                }

                list = newList;
            }
            else
            {
                // Counting cows and bulls
                for (int i = 0; i < userList.Count; i++)
                {
                    // Creating an Array
                    ArrayList ab = new ArrayList();

                    //From method GetNumberAB we compare the number of guess and array
                    ab = GetNumberAB(guess, (int)userList[i]);

                    // compare the number of cows and bulls
                    if (bull == (int)ab[0] && cow == (int)ab[1])
                        newList.Add(userList[i]);

                }
                // Assigning a variable
                userList = newList;
            }


        }
        /// <summary>
        /// This method creates two arrays and comparing both
        /// </summary>
        /// <param name="guessNumber">Guess Number</param>
        /// <param name="answerList">Array</param>
        /// <returns></returns>
        public static ArrayList GetNumberAB(int guessNumber, int answerList)
        {
            // Creating an Array
            ArrayList ab = new ArrayList();
            //Assign variables
            int a = 0, b = 0;
            //Create array 
            int[] listArr = new int[4];
            int[] guessArr = new int[4];

            //Sorting of numbers
            listArr[0] = answerList / 1000;
            listArr[1] = (answerList / 100) % 10;
            listArr[2] = (answerList / 10) % 10;
            listArr[3] = (answerList % 10);

            //Sorting of Numbers
            guessArr[0] = (guessNumber / 1000);
            guessArr[1] = (guessNumber / 100) % 10;
            guessArr[2] = (guessNumber / 10) % 10;
            guessArr[3] = (guessNumber % 10);

            //Comparing both of them
            for (int i = 0; i < 4; i++)
            {
                if (guessArr[i] == listArr[i])
                {
                    a++;
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (guessArr[j] == listArr[i])
                        {
                            b++;
                        }
                    }
                }
            }
            //Adding these variables
            ab.Add(a);
            ab.Add(b);

            return ab;
        }
        /// <summary>
        /// Creating another class Random
        /// </summary>
        static Random r = new Random();
        /// <summary>
        /// Creating the Random Number on Array
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        static int[] RandomNumberGenerator(int length)
        {
            int p, k = 1;
            //Creating an Array for Sorting the value
            int[] ar = new int[length];
            //Creating the random first digit number
            ar[0] = r.Next(1, 9);
            // Sorting and creating random numbers in Array
            while (k < length)
            {
                p = r.Next(0, 9);
                bool b = true;
                for (int i = 0; i < k; i++)
                    if (p == ar[i])
                    {
                        b = false;
                        break;
                    }
                if (b)
                {
                    ar[k] = p;
                    k++;
                }
            }
            return ar;
        }
        /// <summary>
        /// Comparing both Arrays of similarity
        /// </summary>
        /// <param name="a">first Array</param>
        /// <param name="b">second Array</param>
        /// <param name="bull">type Bull</param>
        /// <returns></returns>
        public static int CompareArrays(int[] a, int[] b, out int bull)
        {
            //Creating 2 variables
            int cow = 0;
            bull = 0;
            //Using loop for, we start to compare the first array and second
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    //if first array is similar with second we counting bull
                    if (a[i] == b[j] && i == j)
                    {
                        bull++;
                    }
                    //if first array is similar with second we counting cow
                    else if (a[i] == b[j])
                        cow++;
                }
            }
            return cow;
        }
        /// <summary>
        /// Create an Array for Length Guess
        /// </summary>
        /// <param name="length"></param>
        /// <param name="lengthNumber"></param>
        /// <returns></returns>
        public static int[] CreateArray(int length, int lengthNumber)
        {
            //Creating an Array
            int[] result = new int[length];
            //Using loop we start sorting the value from 0 to length of the value
            for (int i = 0; i < length; i++)
            {
                //example: 345
                int a = lengthNumber % 10;
                result[i] = a;
                lengthNumber = lengthNumber / 10;
                //final output [5],[4],[3]
            }
            //Reverse the Array
            Array.Reverse(result);
            //returning result to the first Method
            return result;
        }

        /// <summary>
        /// The Main program of Length Guess
        /// </summary>
        static void UserLengthGame()
        {
            //creating variable
            int lengthNumber;
            Console.Write("\t\t║ Enter the length of the number: ");
            //validating the input
            while (!int.TryParse(Console.ReadLine(), out lengthNumber) || lengthNumber < 1 || lengthNumber >= 10)
            {
                Console.WriteLine("\t\t║ Incorrect input");
                Console.Write("\t\t║ Enter the length of the number: ");
            }
            GameLengthProcess(lengthNumber);
        }

        private static void GameLengthProcess(int length)
        {
            int numberDigit;
            //Creating another array
            int[] num2 = RandomNumberGenerator(length);
            while (true)
            {
                Console.Write("\t\t║ Input the digit: ");
                while (!int.TryParse(Console.ReadLine(), out numberDigit) || numberDigit < Math.Pow(10, length - 1) || numberDigit >= Math.Pow(10, length))
                {
                    Console.WriteLine("\t\t║ Incorrect input");
                    Console.Write("\t\t║ Input the digit: ");
                }
                //Returning the method to the Array num1
                int[] num1 = CreateArray(length, numberDigit);
                //Returning the method which compare both arrays
                int cow = CompareArrays(num1, num2, out int bull);
                //The Result
                Console.WriteLine($"\t\t║ Bulls: {bull} and Cows: {cow}");
                //Comparing length and bull
                // Example: if(4 == 4), return true; GameOver
                if (bull == length)
                {
                    Console.WriteLine("\t\t║ You win! Congratulations!");
                    Console.WriteLine("\t\t╚=============================╝");
                    break;
                }
            }
        }
    }
}
