using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSEntityFramework
{
    public static class StudentDB
    {
        /// <summary>
        /// returns a list of all the students sorted by studentId in ascending order
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetAllStudents()
        {
            using (var context = new StudentContext())
            {

                //LINQ - language INtegrated Query

                //LINQ Query Syntax
                List<Student> students =
                    (from s in context.Students
                     orderby s.StudentId ascending
                     select s).ToList();

                //LINQ Method Syntax
                List<Student> students2 =
                    context
                        .Students
                            .OrderBy(stu => stu.StudentId)
                                .ToList();
                return students;
            }
        }

        public static Student Add(Student stu)
        {
            using (StudentContext context = new StudentContext())
            {
                //preparing insert query
                context.Students.Add(stu);
                //execute insert query against DB
                context.SaveChanges();
            }

            //return the student with the studentID set
            return stu;
        }

        public static void Delete(Student s)
        {
            using (var context = new StudentContext())
            {
#if DEBUG
                //log query generate to output window
                context.Database.Log = Console.WriteLine;
#endif

                context.Students.Add(s);
                context.Entry(s).State = EntityState.Deleted;
                context.SaveChanges();
            }

            //same as above
            /*var context2 = new StudentContext();
            try
            {
                //DB code goes here
            }
            finally
            {
                context2.Dispose();
            }*/
        }
    }
}
