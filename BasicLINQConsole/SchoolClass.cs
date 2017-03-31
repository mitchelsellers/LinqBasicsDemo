using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLINQConsole
{
    class SchoolClass
    {
        public string Department { get; set; }
        public string ClassName { get; set; }
        public int RegisteredStudents { get; set; }

        public static List<SchoolClass> BuildClassList()
        {
            return new List<SchoolClass>()
                   {
                       new SchoolClass()
                       {
                           ClassName = "Intro to Visual Basic",
                           Department = "Computer Science",
                           RegisteredStudents = 10
                       },
                       new SchoolClass()
                       {
                           ClassName = "Advanced Visual Basic",
                           Department = "Computer Science",
                           RegisteredStudents = 10
                       },
                       new SchoolClass()
                       {
                           ClassName = "Intro C#",
                           Department = "Computer Science",
                           RegisteredStudents = 100
                       },
                       new SchoolClass()
                       {
                           ClassName = "Accounting 101",
                           Department = "Business",
                           RegisteredStudents = 210
                       }
                   };
        }
    }
}
