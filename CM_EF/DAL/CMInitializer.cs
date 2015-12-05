using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CM_EF.Models;

namespace CM_EF.DAL
{
    class CMInitializer : DropCreateDatabaseAlways<CMContext>
    {
        protected override void Seed(CMContext context)
        {
            Course c1 = new Course()
            {
                CourseType = CourseType.Online,
                LaptopRequired = true,
                MaximumParticipants = 150,
                Name = "Web Design 1",
                Price = 564.14,
                StartDate = new DateTime(2015, 12, 9),
                Teacher = "Johan Ven"
            };
            Course c2 = new Course()
            {
                CourseType = CourseType.OnCampus,
                LaptopRequired = true,
                MaximumParticipants = 40,
                Name = " Programming in .NET",
                Price = 225.50,
                StartDate = new DateTime(2016, 1, 10),
                Teacher = "Kenneth De Keulenaer"
            };
            Course c3 = new Course()
            {
                CourseType = CourseType.OnCampus,
                LaptopRequired = false,
                MaximumParticipants = 25,
                Name = "Web Design 1",
                Teacher = null
            };
            context.Courses.Add(c1);
            context.Courses.Add(c2);
            context.Courses.Add(c3);
            context.SaveChanges();
        }
    }
}
