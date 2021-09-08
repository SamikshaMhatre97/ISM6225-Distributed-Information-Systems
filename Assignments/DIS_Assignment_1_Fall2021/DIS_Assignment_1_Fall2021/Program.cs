using System;
using System.Collections.Generic;

namespace DIS_Assignment1_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the string:");
            string s = Console.ReadLine();
            bool pos = HalvesAreAlike(s);
            if (pos)
            {
                Console.WriteLine("Both Halfs of the string are alike");
            }
            else
            {
                Console.WriteLine("Both Halfs of the string are not alike");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the string to check for pangram:");
            string s1 = Console.ReadLine();
            bool flag = CheckIfPangram(s1);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:
            int[,] arr = new int[,] { { 1, 2, 3 }, { 3, 2, 1 } };
            int Wealth = MaximumWealth(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("Richest person has a wealth of {0}", Wealth);


            //Question 4:
            string jewels = "aA";
            string stones = "aAAbbbb";
            Console.WriteLine("Q4:");
            int num = NumJewelsInStones(jewels, stones);
            Console.WriteLine("the number of stones you have that are also jewels are {0}:", num);

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String word2 = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(word2, indices);
            Console.WriteLine("The Final string after rotation is " + rotated_string);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            int[] nums = { 0, 1, 2, 3, 4 };
            int[] index = { 0, 1, 2, 2, 1 };
            int[] target = CreateTargetArray(nums, index);
            Console.WriteLine("Target array  for the Given array's is:");
            for (int i = 0; i < target.Length; i++)
            {
                Console.Write(target[i] + "\t");
            }
            Console.WriteLine();

        }


        /* As this question deals with counting the number of vowels in both halves, 
         * I have hard coded and stored all the vowels in a variable (sVowels) of datatype string. 
         * Further I have defined a counter(count) to iterate through the input string,
         * where the counter increments by 1 if the is vowel is in the first half of the string 
         * and decrements if it is in the second half. At the end I am returning whether count is equal 
         * to 0 or not, to determine whether both halves are alike.
        */

        private static bool HalvesAreAlike(string s)
        {
            try
            {
                int middle = s.Length / 2, count = 0;

                string sVowels = "aeiouAEIOU";
                for (int i = 0, j = middle; i < middle; i++, j++)
                {
                    if (sVowels.IndexOf(s[i]) >= 0)
                        count++;
                    if (sVowels.IndexOf(s[j]) >= 0)
                        count--;
                }
                return count == 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
         * I have defined a boolean array (check) to store all the indices of the alphabets.
         * Using the for loop I have iterated through all the alphabets both in upper and lower case 
         * and have saved the index of every character.
         * After iterating through all the characters I've checked whether all the characters are present at 
         * their index or not.If not then I have set the is Pangram variable (isPan) to false else it returns true.   
         */

        private static bool CheckIfPangram(string s)
        {
            try
            {

                bool[] check = new bool[26];
                bool isPan = true;
                int index = 0;

                for (int i = 0; i < s.Length; i++)
                {
                    if ('A' <= s[i] && s[i] <= 'Z')
                        index = s[i] - 'A';

                    else if ('a' <= s[i] && s[i] <= 'z')
                        index = s[i] - 'a';

                    else
                        continue;

                    check[index] = true;
                }

                for (int i = 0; i <= 25; i++)
                    if (check[i] == false)
                        isPan = false;

                return (isPan);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
         * I have used two for loops to parse throuh the 2D array, the first array keep a track of the customer 
         * and the second loop keep a tack of the bank number.
         * Furtehr I have calculated the sum of the numbers in each row which is equal to the 
         * total amount of the user’s deposits. Then I have compared the most recent maximum value with the 
         * customer's total amount.
         */

        private static int MaximumWealth(int[,] accounts)
        {
            try
            {
                int iMaxWealth = 0;
                for (int i = 0; i < accounts.GetLength(0); i++)
                {
                    int total = 0;
                    for (int j = 0; j < accounts.GetLength(1); j++)
                        total = total + accounts[i, j];

                    iMaxWealth = Math.Max(iMaxWealth, total);
                }
                return iMaxWealth;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*I've used two for loops to parse throught the each string of jewels and stones.
         * Furtehr I have compared each character of string stones with each character of string jewels.
         * Every time the stones is also a jewel, the counter increments by 1, 
         * which basically returns the total number of stones which are also jewels.
         */
        private static int NumJewelsInStones(string jewels, string stones)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < stones.Length; i++)
                {
                    for (int j = 0; j < jewels.Length; j++)
                    {
                        if (jewels[j] == stones[i])
                            count++;
                    }
                }
                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /*
         * I've initialised a character array which helps parse through the input string. 
         * Further I am trying to assign a character that is present at the ith position 
         * to indices[i]th position inorder to shuffle the string. After that I have used 
         * a new string variable to store and return the reshuffled string. 
         */

        private static string RestoreString(string s, int[] indices)
        {
            try
            {
                char[] restore = new char[s.Length];

                for (int i = 0; i < s.Length; i++)
                    restore[indices[i]] = s[i];

                string revert = new string(restore);

                return revert;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        /* 
         * I have initialised a List (nTarget) and have just used a for loop to iterate throught the indices
         * and have inserted numbers based on indices in the list.
         */
        private static int[] CreateTargetArray(int[] nums, int[] index)
        {
            try
            {
                int[] arrTarget = new int[index.Length];
                List<int> nTarget = new List<int>(index.Length);
                for (int i = 0; i < index.Length; i++)
                    nTarget.Insert(index[i], nums[i]);
                arrTarget = nTarget.ToArray();
                return arrTarget;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

//Self Reflection:

//Time taken:
//I completed the assignment in the span of 2 days and it took me around 3 to 3.5 hours to finish it.

//Learning: 
//Having come from a Java background, I found a lot of similarities between C# and Java.
//This assignment helped me brush up my basics on loops and conditional statements.
//It compelled me to think on a very basic ground as some questions didn’t allow the usage of inbuild functions of C#.
//This helped me gain insight on how the compiler handles the program one step at a time.
//I also got to learn how to use object reference in methods and about several C# functions such as Split() etc.

//Recommendation
//One thing that I would have preferred is if we weren't provided with the basic layout,
//for eg. I would have loved to learn more about how to call a function on my own, but thanks to the layout provided, it became easy for me.
// One thing that I really loved was that this assignment compelled me to think on the intricate working of the compiler.
