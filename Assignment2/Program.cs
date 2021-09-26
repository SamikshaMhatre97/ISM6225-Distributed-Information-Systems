using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignment_2_Fall_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:

            Console.WriteLine("Question 1");
            int[] heights = { -5, 1, 5, 0, -7 };
            int max_height = LargestAltitude(heights);
            Console.WriteLine("Maximum altitude gained is {0}", max_height);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3:
            Console.WriteLine("Question 3");
            string[] words1 = { "bella", "label", "roller" };
            List<string> commonWords = CommonChars(words1);
            Console.WriteLine("Common characters in all the strigs are:");
            for (int i = 0; i < commonWords.Count; i++)
            {
                Console.Write(commonWords[i] + "\t");
            }
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            int[] arr1 = { 1, 2, 2, 1, 1, 3 };
            bool unq = UniqueOccurrences(arr1);
            if (unq)
                Console.WriteLine("Number of Occurences of each element are same");
            else
                Console.WriteLine("Number of Occurences of each element are not same");

            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            List<List<string>> items = new List<List<string>>();
            items.Add(new List<string>() { "phone", "blue", "pixel" });
            items.Add(new List<string>() { "computer", "silver", "lenovo" });
            items.Add(new List<string>() { "phone", "gold", "iphone" });

            string ruleKey = "color";
            string ruleValue = "silver";

            int matches = CountMatches(items, ruleKey, ruleValue);
            Console.WriteLine("Number of matches for the given rule :{0}", matches);

            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7:

            Console.WriteLine("Question 7:");
            string allowed = "abc";
            string[] words = { "a", "b", "c", "ab", "ac", "bc", "abc" };
            int count = CountConsistentStrings(allowed, words);
            Console.WriteLine("Number of Consistent strings are : {0}", count);
            Console.WriteLine(" ");

            //Question 8:
            Console.WriteLine("Question 8");
            int[] num1 = { 12, 28, 46, 32, 50 };
            int[] num2 = { 50, 12, 32, 46, 28 };
            int[] indexes = AnagramMappings(num1, num2);
            Console.WriteLine("Mapping of the elements are");
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[] arr9 = { 7, 1, 5, 3, 6, 4 };
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            int[] arr10 = { 2, 3, 1, 2, 4, 3 };
            int target_subarray_sum = 7;
            int minLen = minSubArrayLen(target_subarray_sum, arr10);
            Console.WriteLine("Minimum length subarray with given sum is {0}", minLen);
            Console.WriteLine();
        }


        /*
        Question 1:
        There is a biker going on a road trip. The road trip consists of n + 1 points at different altitudes. The biker starts his trip on point 0 with altitude equal 0.
        You are given an integer array gain of length n where gain[i] is the net gain in altitude between points i and i + 1  for all (0 <= i < n). Return the highest altitude of a point.
        Example 1:
        Input: gain = [-5,1,5,0,-7]
        Output: 1
        Explanation: The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.
        */

        public static int LargestAltitude(int[] gain)
        {
            try
            {
                int tempAltitude = 0, max = 0, n = gain.Length;
                if (n >= 1 && n <= 100)
                {
                    //initializing the for loop to iterate through all the altitudes
                    for (int i = 0; i < n; i++)
                    {
                        tempAltitude += gain[i];
                        //comparing the maximum altitude with the altitude of current point
                        //and if current is higher, a new value is stored in max
                        max = Math.Max(max, tempAltitude);
                    }

                }
                return max;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*

        Question 2:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. 
        If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                /*
                 * In this code I've initialised a result variable which stores the traget index.
                 * Further I've used a loop to traverse through all the elements of the sorted array
                 * then I'm checking whether the target number is same as the number in the array, if yes I am printing the index of number
                 * if no, I'm traversing throught the array to find a number greater than the target number
                 * (as the list is sorted, the number that is found would be closest number greater than the target number)
                 * So I'm returning the index value of the large number -1
                 */
                int result = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    //storing the resultant index in the result variable
                     result = nums[i] == target ? i : i > target ? i-1 : 0;             
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3

        Given an array words of strings made only from lowercase letters, return a list of all characters that show up in all strings 
        in words (including duplicates).  For example, if a character occurs 3 times in all strings but not 4 times, 
        you need to include that character three times in the final answer.
        You may return the answer in any order.
        Example 1:
        Input: ["bella","label","roller"]
        Output: ["e","l","l"]
        Example 2:
        Input: ["cool","lock","cook"]
        Output: ["c","o"]

        */

        public static List<string> CommonChars(string[] words)
        {
            try
            {
                /*
                 * Here I have initialised two lists, one to store the common words and other to store the count of all charcaters in English
                 * further I have counted the number of charcaters from a to z and traversed through them to find the minimum common words
                 * then I've appended the common occurances to the commonWords list and returned the list.
                 */

                List<string> commonWords = new List<string>();
                List<int[]> alphaCount = new List<int[]>(words.Length);

                for (int i = 0; i < words.Length; i++)
                {
                    //adding a new array of length 26(total number of alphabets in English) for each word present in the word list
                    alphaCount.Add(new int[26]);

                    //counting the number of charcters from a to z
                    foreach (char c in words[i].ToCharArray())
                    {
                        int index = c - 'a';
                        alphaCount[i][index]++;
                    }

                }

                // traversing through each character form[a to z] and finding the minimum amount of words common
                for (int j = 0; j < 26; j++)
                {
                    int minAmount = int.MaxValue;
                    for (int i = 0; i < words.Length; i++)
                    {
                        minAmount = Math.Min(minAmount, alphaCount[i][j]);
                    }

                    // adding a new string for the minimum common occurances of the current letter.
                    for (int k = 0; k < minAmount; k++)
                    {
                        int charAsInt = 'a' + j;
                        char val = (char)charAsInt;
                        commonWords.Add(val.ToString());
                    }
                }
                return commonWords;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 4:
        Given an array of integers arr, write a function that returns true if and only if the number of occurrences of each value in the array is unique.
        Example 1:
        Input: arr = [1,2,2,1,1,3]
        Output: true
        Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.
        Example 2:
        Input: arr = [1,2]
        Output: false
         */

        public static bool UniqueOccurrences(int[] arr)
        {
            /*
         * Here the occurance count of each element is to being compared
         * So I am using a dictonary called "occurance" to store the information where 
         * keys is the element of array,and values is the number of occurances of that element in the array.
         */

            try
            {
                //initializing a dictionary to find the number of occurance of each elements
                var occurences = new Dictionary<int, int>();
                foreach (int i in arr)
                {
                    if (occurences.ContainsKey(arr[i]))
                        //keeps a count of total number of occurances for a particular number
                        occurences[arr[i]] = ++occurences[arr[i]];

                    else
                        occurences[arr[i]] = 1;
                }
                //comparing the occurance count of each element
                return occurences.Values.Distinct().Count() == occurences.Values.Count();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*

        Question 5:
        You are given an array items, where each items[i] = [type, color, name]  describes the type, color, and name of the ith item. You are also given a rule represented by two strings, ruleKey and ruleValue.
        The ith item is said to match the rule if one of the following is true:
        •	ruleKey == "type" and ruleValue == type.
        •	ruleKey == "color" and ruleValue == color.
        •	ruleKey == "name" and ruleValue == name.
        Return the number of items that match the given rule.
        Example 1:
        Input:  items = [["phone","blue","pixel"],["computer","silver","lenovo"],["phone","gold","iphone"]],  ruleKey = "color",  ruleValue = "silver".
        Output: 1
        Explanation: There is only one item matching the given rule, which is ["computer","silver","lenovo"].
        Example 2:
        Input: items = [["phone","blue","pixel"],["computer","silver","phone"],["phone","gold","iphone"]], ruleKey = "type",  ruleValue = "phone"
        Output: 2
        Explanation: There are only two items matching the given rule, which are ["phone","blue","pixel"]  and ["phone","gold","iphone"]. 
        Note that the item ["computer","silver","phone"] does not match.
        */

        public static int CountMatches(List<List<string>> items, string ruleKey, string ruleValue)
        {
            /*
             * In this code, I've directly traversed through each element of the list and checked according to the specified conditions 
             * and returned the total number of items that have matched used a counter
             */
            try
            {
                int cnt = 0;

                foreach (var item in items)
                {
                    //We increment the count if any rule key matches the rule value.
                    //If not that we keep on traversing through all entires
                    if (ruleKey == "type" && item[0] != ruleValue
                        || ruleKey == "color" && item[1] != ruleValue
                        || ruleKey == "name" && item[2] != ruleValue)

                        continue;

                    cnt++;
                }

                return cnt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*

        Question 6:

        Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers. Length.
        You may not use the same element twice, there will be only one solution for a given array.
        Note: Solve it in O(n) and O(1) space complexity.
        Hint: Use the fact that array is sorted in ascending order and there exists only one solution.
        Typically, in these cases it’s useful to use pointers tracking the two ends of the array.
        Example 1:
        Input: numbers = [2,7,11,15], target = 9
        Output: [1,2]
        Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
        Example 2:
        Input: numbers = [2,3,4], target = 6
        Output: [1,3]
        Example 3:
        Input: numbers = [-1,0], target = -1
        Output: [1,2]
        */

        public static void targetSum(int[] nums, int target)
        {
            /*
             * In this code, as the array is already sorted, what I've done is initialised a start and end pointer for the elements in araay
             * and then calculated the sum, if the sum of the both start and end element is the target number then I've printed the elements,
             * if not I have incremented and decremented the pointers according to the target number.
             */

            try
            {
                //setting two variables to track the start and end of the array
                var fromStart = 0;
                var fromEnd = nums.Length - 1;

                while (fromStart < fromEnd)
                {
                    var sum = nums[fromStart] + nums[fromEnd];

                    //checking whether the targeted number has been achieved
                    //If not, we increment or decrement the start and end according to the conditions specified and
                    //then print the values once we've achieved them
                    if (target > sum)
                        fromStart++;
                    else if (target < sum)
                        fromEnd--;
                    else
                    {
                        Console.WriteLine("[{0},{1}]", fromStart + 1, fromEnd + 1);
                        break;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /*

        Question 7:
        You are given a string allowed consisting of distinct characters and an array of strings words. 
        A string is consistent if every character in words[i] appears in the string allowed.
        Return the number of consistent strings in the array words.
        Note: The algorithm should have run time complexity of O(n).
        Hint: Use Dictionaries. 
        Example 1:
        Input: allowed = "ab", words = ["ad","bd","aaab","baa","badab"]
        Output: 2
        Explanation: Strings "aaab" and "baa" are consistent since they only contain characters 'a' and 'b'. string “bd” is not consistent since ‘d’ is not in string allowed.
        Example 2:
        Input: allowed = "abc", words = ["a","b","c","ab","ac","bc","abc"]
        Output: 7
        Explanation: All strings are consistent.
        */


        public static int CountConsistentStrings(string allowed, string[] words)
        {
            /*
        * In this code I have created a dictionary to store the characters in the allowed string.
        * After that I traversse through each character of a word from the array of word and 
        * check whether the allowed character is present in word string or not.
        * The result counter keeps a track of the total lenght of word array and decrements the length if the word is not consistent
        */

            try
            {
                var result = words.Length;
                var dict = new Dictionary<char, bool>();
                for (int i = 0; i < allowed.Length; i++)
                {
                    if (!dict.ContainsKey(allowed[i]))
                        dict.Add(allowed[i], true);
                }
                //traversing through the array of words
                foreach (var singleWord in words)
                {
                    //traversing through each character of each word at a time
                    foreach (var ch in singleWord)
                    {
                        //checking if the dictionary of allowed string contains the characters in words 
                        if (!dict.ContainsKey(ch))
                        {
                            result--;
                            break;
                        }
                    }
                }
                return result;
            }

            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 8:
        You are given two integer arrays nums1 and nums2 where nums2 is an anagram of nums1. Both arrays may contain duplicates.
        Return an index mapping array mapping from nums1 to nums2 where mapping[i] = j indicates that  the ith element in nums1 appears in nums2 at index j. If there are multiple answers, return any of them.
        An array a is an anagram of array b if b is made by randomizing the order of the elements in a.

        Example 1:
        Input: nums1 = [12,28,46,32,50], nums2 = [50,12,32,46,28]
        Output: [1,4,3,2,0]
        Explanation: As mapping[0] = 1 because the 0th element of nums1 appears at nums2[1], and mapping[1] = 4 because the 1st element of nums1 appears at nums2[4], and so on.
        */

        public static int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            try
            {
                //here i've created  a result array to store all the shuffled indices
                int[] result = new int[nums2.Length];
              
                //the first for loop helps traverse the first array where the elements for which the shuffled index is required is obtained
                for (int i = 0; i < nums1.Length; i++)
                {
                    //this loop traverses throught the shuffled array
                    for (int j = 0; j < nums2.Length; j++)
                    {
                        //here we are checking whether the number of 1st array matches with the second array.
                        if (nums1[i] == nums2[j])
                           // storing the shuffled index in the resultant array
                            result[i] = j;
                    }
                }
                return result;
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*

        Question 9:
        Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
        Note: Time Complexity should be O(n).
        Hint: Keep track of maximum sum as you move forward.
        Example 1:
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Example 2:
        Input: nums = [1]
        Output: 1
        */

        public static int MaximumSum(int[] arr)
        {
            try
            {
                /*
                 *In this code maxCurrent stores all positive contiguous sections of the array and 
                 *maxSum keeps a track of maximum sum contiguous sections 
                 *Each time I get a positive-sum, I  am comparing it with maxCurrent and updating value of maxCurrent if it's greater that it's current value
                 */

                int maxSum = int.MinValue, maxCurrent = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    maxCurrent += arr[i];

                    //comparing the sum of contiguous sections with current 
                    if (maxSum < maxCurrent)
                        maxSum = maxCurrent;

                    //assigning max value to 0 for negative integer values
                    if (maxCurrent < 0)
                        maxCurrent = 0;
                }

                return maxSum;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*

        Question 10:
        Given an array of positive integers nums and a positive integer target, 
        return the minimal length of a contiguous subarray [nums[l], nums[l+1], ..., nums[r-1], nums[r]] \
        of which the sum is greater than or equal to target. If there is no such subarray, return 0 instead.
        Note: Try to solve it in O(n) time.
        Hint: Try to create a window and track the sum you have in the window.
        Example 1:
        Input: target = 7, nums = [2,3,1,2,4,3]
        Output: 2
        Explanation: The subarray [4,3] has the minimal length under the problem constraint.
        Example 2:
        Input: target = 4, nums = [1,4,4]
        Output: 1
        */

        public static int minSubArrayLen(int target_subarray_sum, int[] arr10)
        {
            try
            {
                int start = 0;
                int sum = 0;
                int minLength = int.MaxValue;

                //travering through each element
                for (int end = 0; end < arr10.Length; end++)
                {
                    //finding the current sum of elements in the array
                    sum += arr10[end];

                    
                    while (sum >= target_subarray_sum && start <= end)
                    {
                        minLength = Math.Min(minLength, end - start + 1);
                       
                        sum -= arr10[start];
                        start++;
                    }
                }
                //using a ternary operator to return minimum legth. If minimum length found is same as initial, we return 0,
                //else we return the newly found minimum lenth
                return minLength == int.MaxValue ? 0 : minLength;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
