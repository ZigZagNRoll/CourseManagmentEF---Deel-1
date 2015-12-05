using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM_EF.Models;

namespace CM_EF
{
    class Program
    {
        private static CM_EF.DAL.CMContext context;

        static void Main(string[] args)
        {
            context = new DAL.CMContext();
            int nbrOfCourses = context.Courses.Count<Course>();
            Console.WriteLine("Done!");
            Console.WriteLine("{0} courses found!\n", nbrOfCourses);
            ShowCourses();
            UpdateCourses();
            ShowCourses();
            ShowCoursesWithAPrice();
            ShowCoursesWithAPrice2();
            ShowCoursesWithAPrice3();
            ShowCoursesWithAPrice4();
            Console.WriteLine("--------------------");
            SearchCourseByText("web");
            Console.WriteLine("--------------------");
            SearchCourseByNumber(1);
            Console.ReadLine();
        }

        private static void ShowCourses()
        {
            IEnumerable<Course> courses = context.Courses.AsEnumerable<Course>();
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
            Console.WriteLine("-----------");
        }

        private static void UpdateCourses()
        {
            IEnumerable<Course> courses = context.Courses.AsEnumerable<Course>();
            foreach (var course in courses)
                course.Price = course.Price * 1.1;
            context.SaveChanges();
        }

        private static void DeleteCourse()
        {
            IEnumerable<Course> courses = context.Courses.AsEnumerable<Course>();
            foreach (var course in courses)
            {
                if (course.Name.Contains("Web Design"))
                    context.Courses.Remove(course);
            }
            context.SaveChanges();
        }

        //Named method
        private static void ShowCoursesWithAPrice()
        {
            IEnumerable<Course> courses = context.Courses.Where<Course>(HasThisCourseAPrice).AsEnumerable<Course>();
            Console.WriteLine("{0} courses has a price", courses.Count<Course>());
        }

        private static bool HasThisCourseAPrice(Course course)
        {
            return course.Price.HasValue;
        }
        //\Named method

        //Anonymous method
        private static void ShowCoursesWithAPrice2()
        {
            IEnumerable<Course> courses = context.Courses.Where<Course>(delegate (Course course)
            {
                return course.Price.HasValue;
            }).AsEnumerable<Course>();
            Console.WriteLine("{0} courses has a price", courses.Count<Course>());
        }
        //\Anonymous method
        //Lambda
        private static void ShowCoursesWithAPrice3()
        {
            IEnumerable<Course> courses = context.Courses.Where<Course>(course => course.Price.HasValue).AsEnumerable<Course>();
            Console.WriteLine("{0} courses have a price", courses.Count<Course>());
        }
        //\Lambda

        //Lambda on sql server - beter!
        private static void ShowCoursesWithAPrice4()
        {
            var coursesWithAPrice = context.Courses.Where<Course>(course => course.Price.HasValue);
            Console.WriteLine("{0} courses have a price", coursesWithAPrice.Count<Course>());

        }
        //\Lambda on sql server

        private static void SearchCourseByText(string text)
        {
            var coursesByText = context.Courses.Where<Course>(course => course.Name.Contains(text)).AsEnumerable<Course>();
            foreach(var course in coursesByText)
            {
                Console.WriteLine(course);
            }
        }

        private static void SearchCourseByNumber(int nummer)
        {
            var courseWithNumber = context.Courses.Find(nummer);
            Console.WriteLine(courseWithNumber);
        }
    }
}
