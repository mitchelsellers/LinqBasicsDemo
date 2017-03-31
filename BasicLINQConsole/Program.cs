using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicLINQConsole
{
    class Program
    {
        
        static int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 15, 72, 18 };
        private static int[] nameKeys = {0, 1, 7, 5, 2, 4, 6, 4};
        static string[] names = {"John", "Mary", "Mark", "Bill", "Jim", "Barbara", "Mitch", "Skip"};

        static void Main(string[] args)
        {
            //Simple Where/Order Queries
            SelectSmallNumbers();
            SortNumbers();
            SortSmallNumbers();
            SmallNumbersDivisbleByTwo();

            //Aggregation
            CountDivisibleByTwo();

            //Projection
            SquaredNumbers();
            NamesFromIndices();

            //Sets
            UnionAndIntersect();

            //Grouping
            GroupByCategory();
            GroupAndSort();

            DataCreation();
            Conversions();
            Deferral();

            Console.ReadLine();
        }

        /*
         * NOTE: All queries include Method Syntax & Query Syntax!
         */

        #region Simple Queries
        
        public static void SelectSmallNumbers()
        {
            Console.WriteLine("Small Numbers:");
            var smallNumbers = from x in numbers
                               where x < 10
                               select x;

            //var smallNumbers = numbers.Where(x => x < 10);
            WriteObjects(smallNumbers);
        }

        public static void SortNumbers()
        {
            Console.WriteLine("Ordered Numbers:");
            var orderedNumbers = from x in numbers
                                    orderby x
                                    select x;
            //var orderedNumbers = numbers.OrderBy(x => x);
            WriteObjects(orderedNumbers);
        }

        public static void SortSmallNumbers()
        {
            Console.WriteLine("Sorted Small NUmbers:");
            var sortedSmall = from x in numbers
                                where x < 10
                                orderby x
                                select x;
            //var sortedSmall = numbers.Where(x => x < 10).OrderBy(x => x);
            WriteObjects(sortedSmall);
        }

        public static void SmallNumbersDivisbleByTwo()
        {
            Console.WriteLine("Divisible By 2 Under 10:");
            var result = from x in numbers
                where x < 10 && x%2 == 0
                select x;
            //var result = numbers.Where(x => x < 10 && x%2 == 0);
            WriteObjects(result);
        }


        #endregion

        #region Aggregation Queries

        public static void CountDivisibleByTwo()
        {
            Console.WriteLine("Count of Divisble By Two");
            var result = (from x in numbers
                where x%2 == 0
                select x).Count();
            //var result = numbers.Where(x => x%2 == 0).Count();
            Console.WriteLine(result);
        }
        #endregion

        #region Projections
        public static void SquaredNumbers()
        {
            Console.WriteLine("Squared Numbers");
            var result = from x in numbers
                select x*x;
            //var result = numbers.Select(x => x*x);
            WriteObjects(result);
        }

        public static void NamesFromIndices()
        {
            Console.WriteLine("Names from Indices");
            var result = from x in nameKeys
                select names[x];
            //var result = nameKeys.Select(x => names[x]);
            WriteObjects(result);
        }

        #endregion

        #region Set Operations

        public static void UnionAndIntersect()
        {
            Console.WriteLine("Unioned Numbers");
            var result = numbers.Union(nameKeys);
            WriteObjects(result);

            Console.WriteLine("Intersection Numbers");
            var result2 = numbers.Intersect(nameKeys);
            WriteObjects(result2);
        }
        #endregion

        #region Grouping & Aggregation

        public static void GroupByCategory()
        {
            Console.WriteLine("Grouped by Category");
            var departmentList = from x in SchoolClass.BuildClassList()
                group x by x.Department
                into grp
                select
                    new
                    {
                        Department = grp.Key,
                        ClassCount = grp.Count(),
                        Enrollment = grp.Sum(x => x.RegisteredStudents)
                    };
            foreach (var item in departmentList)
                Console.WriteLine(item.Department + " Classes: " + item.ClassCount + " Students: " + item.Enrollment);

        }

        public static void GroupAndSort()
        {
            Console.WriteLine("Names By Letter & Sort");
            var result = from x in names
                group x by x[0]
                into grp
                orderby grp.Key
                select new {StartLetter = grp.Key, Words = grp, WordCount = grp.Count()};
            foreach (var item in result)
            {
                Console.WriteLine("Words {0} that start with {1}", item.WordCount, item.StartLetter);
                foreach (var word in item.Words)
                    Console.WriteLine(word);
            }
        }
        #endregion

        public static void WriteObjects<T>(IEnumerable<T> toOutput)
        {
            foreach (var item in toOutput)
                Console.Write(item + " ");
            Console.WriteLine(string.Empty);
        }

        public static void DataCreation()
        {
            Console.WriteLine("Next 50 Years");
            var next50Years = Enumerable.Range(DateTime.Now.Year, 50);
            WriteObjects(next50Years);
        }

        public static void Conversions()
        {
            var result = from x in numbers
                         select x * x;
            var resultList = result.ToList();
            var resultArray = result.ToArray();
            Console.WriteLine(resultList.Count == resultArray.Length);

        }

        public static void Deferral()
        {
            int rowCount = 0;
            var result = (from x in numbers
                select ++rowCount); //Add toList to change behavior

            foreach (var item in result)
                Console.WriteLine("Result: {0}, Row Count: {1}", item, rowCount);
        }
    }
}
