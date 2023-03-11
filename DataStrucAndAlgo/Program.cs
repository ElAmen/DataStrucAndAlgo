using C5;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DataStrucAndAlgo
{
    class program
    {
        static void Main(string[] args)
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();

            var ciNumber = "225565762502 ";

            var phoneNumber = phoneNumberUtil.Parse(ciNumber, "CI");

            var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);

            

            Console.WriteLine("Sample TBX file generated successfully.");

            Console.ReadLine();
        }



        ///// <summary>
        ///// Generated xml data and print out xml string
        ///// </summary>
        ///// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    string result;
        //    var stream = new MemoryStream(); // The writer closes this for us
        //    using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
        //    {
        //        writer.WriteStartDocument(true);
        //        writer.Formatting = Formatting.Indented;
        //        writer.Indentation = 2;
        //        writer.WriteStartElement("Table");
        //        createNode("1", "Product 1", "100", writer);
        //        createNode("2", "Product 2", "200", writer);
        //        createNode("3", "Product 3", "300", writer);
        //        writer.WriteEndElement();
        //        writer.WriteEndDocument();
        //        writer.Flush();


        //        StreamReader reader = new StreamReader(stream, Encoding.UTF8, true);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        result = reader.ReadToEnd();

        //    }


        //    Console.WriteLine(result);
        //    Console.WriteLine("XML File created ! ");
        //}


        //private static void createNode(string course_id,string courseName,string price, XmlTextWriter writer)
        //{
        //    writer.WriteStartElement("course");
        //    writer.WriteStartElement("course_id");
        //    writer.WriteString(course_id);
        //    writer.WriteEndElement();
        //    writer.WriteStartElement("courseName");
        //    writer.WriteString(courseName);
        //    writer.WriteEndElement();
        //    writer.WriteStartElement("price");
        //    writer.WriteString(price);
        //    writer.WriteEndElement();
        //    writer.WriteEndElement();
        //}


        //static void Main(string[] args)
        //{

        //var x = new int[] {1,2 };
        //var finRes = x.Any() ? "ARRAY[\"" : "ARRAY[";

        //foreach (var i in x)
        //{
        //    finRes += i + "\",\"";
        //}

        //try
        //{
        //    finRes = x.Any() ? finRes.Remove(finRes.LastIndexOf(",\"", StringComparison.Ordinal)) : finRes;
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e);
        //}

        //finRes += "]";
        //Console.WriteLine(finRes);
        //var sql = $"INSERT INTO BLA BLA BLA {finRes}";
        //Console.WriteLine(sql);
        //Console.ReadKey();
        //}

        //static void Main(string[] args)
        //{

        //    Console.WriteLine("Binary Search: Bitonic Array Maximum");
        //    Console.WriteLine(FindMax(new int[] { 1, 3, 8, 12, 4, 2 }));
        //    Console.WriteLine(FindMax(new int[] { 3, 8, 3, 1 }));
        //    Console.WriteLine(FindMax(new int[] { 1, 3, 8, 12 }));
        //    Console.WriteLine(FindMax(new int[] { 10, 9, 8 }));

        //    Console.WriteLine("\nTwo Pointers: Pair with Target Sum");
        //    int[] result = Search(new int[] { 1, 2, 3, 4, 6 }, 6);
        //    Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");
        //    result = Search(new int[] { 2, 5, 9, 11 }, 11);
        //    Console.WriteLine("Pair with target sum: [" + result[0] + ", " + result[1] + "]");

        //    Console.WriteLine("\n‘K’ Closest Points to the Origin");
        //    Point[] points = new Point[] { new Point(1, 3), new Point(3, 4), new Point(2, -1), new Point(1, -1), new Point(-1, -1) };
        //    List<Point> result2 = FindClosestPoints(points, 2);
        //    Console.WriteLine("Here are the k points closest the origin: ");
        //    foreach (Point p in result2)
        //        Console.WriteLine("[" + p.x + " , " + p.y + "] ");

        //    Console.WriteLine("\n‘K’ Closest Points to the Origin(0,0)");
        //    Point result3 = ClosestToOrigin(points, 2);
        //    Console.WriteLine("[" + result3.x + " , " + result3.y + "] ");

        //    Console.WriteLine("\n Subsets");
        //    List<List<int>> result4 = Subsets.FindSubsets(new int[] { 1, 3 });
        //    Console.WriteLine("Here is the list of subsets: " + Subsets.ToString(result4));
        //    result4 = Subsets.FindSubsets(new int[] { 1, 5, 3 });
        //    Console.WriteLine("Here is the list of subsets: " + Subsets.ToString(result4) );

        //    Console.WriteLine("\n Binary Tree Path Sum");
        //    TreeNode root = new TreeNode(12);
        //    root.left = new TreeNode(7);
        //    root.right = new TreeNode(1);
        //    root.left.left = new TreeNode(9);
        //    root.right.left = new TreeNode(10);
        //    root.right.right = new TreeNode(5);
        //    Console.WriteLine("Tree has path: " + TreePathSum.hasPath(root, 23));
        //    Console.WriteLine("Tree has path: " + TreePathSum.hasPath(root, 16));

        //    Console.ReadKey();
        //}

        #region  Bitonic Array Maximum

        //Problem statement: Find the maximum value in a given Bitonic array.An array is considered bitonic if it is monotonically increasing and then monotonically decreasing. Monotonically increasing or decreasing means that for any index i in the array arr[i] != arr[i + 1].
        //Example: Input: [1, 3, 8, 12, 4, 2], Output: 12
        //Solution: A bitonic array is a sorted array; the only difference is that its first part is sorted in ascending order and the second part is sorted in descending order.We can use a variation of Binary Search to solve this problem.Remember that in Binary Search we have start, end, and middle indices and in each step we reduce our search space by moving start or end. Since no two consecutive numbers are same (as the array is monotonically increasing or decreasing), whenever we calculate the middle index for Binary Search, we can compare the numbers pointed out by the index middle and middle+1 to find if we are in the ascending or the descending part.So:
        //1. If arr[middle] > arr[middle + 1], we are in the second (descending) part of the bitonic array. Therefore, our required number could either be pointed out by middle or will be before middle.This means we will be doing: end = middle.
        //2. If arr[middle] <= arr[middle + 1], we are in the first (ascending) part of the bitonic array. Therefore, the required number will be after middle.This means we will be doing: start = middle + 1.
        //We can break when start == end.Due to the two points mentioned above, both start and end will be pointing at the maximum number of the Bitonic array.
        //Code: Here is the Java code to solve this problem:

        public static int FindMax(int[] arr)
        {
            int start = 0, end = arr.Length - 1;
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (arr[mid] > arr[mid + 1])
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            // at the end of the while loop, 'start == end'
            return arr[start];
        }



        #endregion

        #region Two Pointers: Pair with Target Sum

        //Problem statement: Given an array of sorted numbers and a target sum, find a pair in the array whose sum is equal to the given target.
        //Write a function to return the indices of the two numbers(i.e., the pair) such that they add up to the given target.
        //Example: Input: [1, 2, 3, 4, 6], target=6, Output: [1, 3] (The numbers at index 1 and 3 add up to 6: 2+4=6)
        //Solution: Since the given array is sorted, a brute-force solution could be to iterate through the array, taking one number at a time and searching for the second number through Binary Search.The time complexity of this algorithm will be O(N* logN). Can we do better than this?
        //We can follow the Two Pointers approach. We will start with one pointer pointing to the beginning of the array and another pointing at the end.At every step, we will see if the numbers pointed by the two pointers add up to the target sum.If they do, we have found our pair.Otherwise, we will do one of two things:
        //If the sum of the two numbers pointed by the two pointers is greater than the target sum, this means that we need a pair with a smaller sum. So, to try more pairs, we can decrement the end-pointer.
        //If the sum of the two numbers pointed by the two pointers is smaller than the target sum, this means that we need a pair with a larger sum. So, to try more pairs, we can increment the start-pointer.
        //Here is the visual representation of this algorithm for the example mentioned above:
        //Code: Here is what our algorithm will look like:

        public static int[] Search(int[] arr, int targetSum)
        {
            int left = 0, right = arr.Length - 1;
            while (left < right)
            {
                // comparing the sum of two numbers to the 'targetSum' can cause integer overflow
                // so, we will try to find a target difference instead
                int targetDiff = targetSum - arr[left];
                if (targetDiff == arr[right])
                    return new int[] { left, right }; // found the pair

                if (targetDiff > arr[right])
                    left++; // we need a pair with a bigger sum
                else
                    right--; // we need a pair with a smaller sum
            }
            return new int[] { -1, -1 };
        }

        #endregion

        #region ‘K’ Closest Points to the Origin

        //Problem statement: Given an array of points in a 2D plane, find ‘K’ closest points to the origin.
        //Example: Input: points = [[1,2],[1,3]], K = 1, Output: [[1,2]]
        //Solution: The Euclidean distance of a point P(x, y) from the origin can be calculated through the following formula:

        //We can use a Max Heap to find ‘K’ points closest to the origin.We can start with pushing first ‘K’ points in the heap.While iterating through the remaining points, if a point (say ‘P’) is closer to the origin than the top point of the max-heap, we will remove that top point from the heap and add ‘P’ to always keep the closest points in the heap.
        //Code: Here is what our algorithm will look like:

        public class Point : IComparable<Point>
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int CompareTo(Point other)
            {
                return x.CompareTo(y);
            }

            public int distFromOrigin()
            {
                // ignoring sqrt
                return (x * x) + (y * y);
            }
        }

        public static List<Point> FindClosestPoints(Point[] points, int k)
        {
            IPriorityQueue<Point> maxHeap = new IntervalHeap<Point>();
            // new IPriorityQueueHandle<Point>((p1, p2) => p2.distFromOrigin() - p1.distFromOrigin());

            // put first 'k' points in the max heap
            for (int i = 0; i < k; i++)
            {
                maxHeap.Add(points[i]);
            }
            // go through the remaining points of the input array, if a point is closer to 
            // the origin than the top point of the max-heap, remove the top point from 
            // heap and add the point from the input array
            for (int i = k; i < points.Length; i++)
            {
                if (points[i].distFromOrigin() < maxHeap.Max().distFromOrigin())
                {
                    maxHeap.DeleteMax();
                    maxHeap.Add(points[i]);
                }
            }

            //Point x = new Point(k, 0);

            // the heap has 'k' points closest to the origin, return them in a list
            return maxHeap.ToList<Point>();
        }

        public static Point ClosestToOrigin(Point[] points, int k)
        {
            Point x = new Point(k, 0);

            var closestToOrigin = points
                                    .Select(p => new { Point = p, Distance2 = p.x * p.x + p.y * p.y })
                                    .Aggregate((p1, p2) => p1.Distance2 < p2.Distance2 ? p1 : p2)
                                    .Point;
            return closestToOrigin;
        }

        #endregion

        #region Subsets

        // Problem Statement: Given a set with distinct elements, find all of its distinct subsets.
        // Example: Input: [1, 5, 3], Output: [], [1], [5], [3], [1,5], [1,3], [5,3], [1,5,3]
        // Solution: To generate all subsets of the given set, we can use the Breadth-First Search(BFS) approach.We can start with an empty set, iterate through all numbers one-by-one, and add them to existing sets to create new subsets.
        // Let’s take the abovementioned example to go through each step of our algorithm:
        // Given set: [1, 5, 3]
        // Start with an empty set: [[]]
        // Add the first number(1) to all the existing subsets to create new subsets: [[], [1]];
        // Add the second number(5) to all the existing subsets: [[], [1], [5], [1,5]];
        // Add the third number(3) to all the existing subsets: [[], [1], [5], [1,5], [3], [1,3], [5,3], [1,5,3]].
        //Code: Here is what our algorithm will look like:

        class Subsets
        {
            public static List<List<int>> FindSubsets(int[] nums)
            {
                List<List<int>> subsets = new List<List<int>>();
                // start by adding the empty subset
                subsets.Add(new List<int>());
                foreach (int currentNumber in nums)
                {
                    // we will take all existing subsets and insert the current number in them to
                    // create new subsets
                    int n = subsets.Count();
                    for (int i = 0; i < n; i++)
                    {
                        // create a new subset from the existing subset and 
                        // insert the current element to it
                        List<int> set = new List<int>(subsets[i]);
                        set.Add(currentNumber);
                        subsets.Add(set);
                    }
                }
                return subsets;
            }

            public static string ToString(List<List<int>> subset)
            {
                string a = "";
                int count = 0;
                foreach (var items in subset)
                {
                    count++;
                    a += "[";
                    a += string.Join(",", items);
                    a += "],";
                }
                return a + " Number of combination(s) : " + count;

            }
        }
        #endregion

        #region  Binary Tree Path Sum

        //Problem Statement: Given a binary tree and a number ‘S,’ find if the tree has a path from root-to-leaf such that the sum of all the node values of that path equals ‘S.’
        //Solution: As we are trying to search for a root-to-leaf path, we can use the Depth First Search(DFS) technique to solve this problem.
        //To recursively traverse a binary tree in a DFS fashion, we can start from the root and at every step, make two recursive calls one for the left and one for the right child.
        //Here are the steps for our Binary Tree Path Sum problem:
        //Start DFS with the root of the tree.
        //If the current node is not a leaf node, do two things: a)Subtract the value of the current node from the given number to get a new sum => S = S - node.value, b) Make two recursive calls for both the children of the current node with the new number calculated in the previous step.
        //At every step, see if the current node being visited is a leaf node and if its value is equal to the given number ‘S.’ If both these conditions are true, we have found the required root-to-leaf path, therefore return true.
        //If the current node is a leaf, but its value is not equal to the given number ‘S,’ return false.
        //Code: Here is what our algorithm will look like:

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        };

        class TreePathSum
        {
            public static bool hasPath(TreeNode root, int sum)
            {
                if (root == null)
                    return false;

                // if current node is a leaf and its value is equal to the sum, we've found a path
                if (root.val == sum && root.left == null && root.right == null)
                    return true;

                // recursively call to traverse the left and right sub-tree
                // return true if any of the two recursive call return true
                return hasPath(root.left, sum - root.val) || hasPath(root.right, sum - root.val);
            }


        }
        #endregion




        ///Fixed size queue
        //public class FixedSizedQueue<T> : ConcurrentQueue<T>
        //{
        //    private readonly object syncObject = new object();

        //    public int Size { get; private set; }

        //    public FixedSizedQueue(int size)
        //    {
        //        Size = size;
        //    }

        //    public new void Enqueue(T obj)
        //    {
        //        base.Enqueue(obj);
        //        lock (syncObject)
        //        {
        //            while (Count > Size)
        //            {
        //                T outObj;
        //                TryDequeue(out outObj);
        //            }
        //        }
        //    }
        //}

        ////Usage
        //var set = new FixedSizedQueue<LastSales>(10);

    }

    internal class Term
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public string Value { get; set; }
        public string Definition { get; set; }
    }
}
