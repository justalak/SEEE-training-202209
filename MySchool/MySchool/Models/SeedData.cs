using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySchool.Infrastructure;
using System;
using System.Linq;
using System.Net;

namespace MySchool.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var contextSt = new ManagerSchoolContext
                (serviceProvider.GetRequiredService<DbContextOptions<ManagerSchoolContext>>()))
            {
                if (contextSt.Students.Any())
                {
                    return;
                }
                contextSt.Students.AddRange(
                    new Student
                    {
                        NameStudent = "Courtenay Dymidowski",
                        Email = "cdymidowski0@artisteer.com",
                        Gender = "Female",
                        PhoneNumber = "9077644042",
                        Score = 3,
                        IdClass = 9
                    },
                    new Student
                    {
                        NameStudent = "Ricky Standley",
                        Email = "rstandley1@shutterfly.com",
                        Gender = "Female",
                        PhoneNumber = "4679388037",
                        Score = 3,
                        IdClass = 5
                    },
                    new Student
                    {
                        NameStudent = "Mauricio Coote",
                        Email = "mcoote2@si.edu",
                        Gender = "Male",
                        PhoneNumber = "2488247981",
                        Score = 7,
                        IdClass = 6
                    },
                    new Student
                    {
                        NameStudent = "Luce McNelly",
                        Email = "lmcnelly3@paginegialle.it",
                        Gender = "Agender",
                        PhoneNumber = "4251433472",
                        Score = 8,
                        IdClass = 1
                    },
                    new Student
                    {
                        NameStudent = "Tressa Grund",
                        Email = "tgrund4@rakuten.co.jp",
                        Gender = "Female",
                        PhoneNumber = "5555246898",
                        Score = 5,
                        IdClass = 9
                    },
                    new Student
                    {
                        NameStudent = "Gretchen Erik",
                        Email = "gerik5@opensource.org",
                        Gender = "Female",
                        PhoneNumber = "3733522324",
                        Score = 4,
                        IdClass = 9
                    },
                    new Student
                    {
                        NameStudent = "Ben Dounbare",
                        Email = "bdounbare6@multiply.com",
                        Gender = "Male",
                        PhoneNumber = "3402679398",
                        Score = 3,
                        IdClass = 9
                    },
                    new Student
                    {
                        NameStudent = "Shelly Wingrove",
                        Email = "swingrove7@sphinn.com",
                        Gender = "Female",
                        PhoneNumber = "6402021568",
                        Score = 7,
                        IdClass = 7
                    },
                    new Student
                    {
                        NameStudent = "Alva Rollason",
                        Email = "arollason8@alibaba.com",
                        Gender = "Male",
                        PhoneNumber = "8088049027",
                        Score = 3,
                        IdClass = 6
                    },
                    new Student
                    {
                        NameStudent = "Milt Starrs",
                        Email = "mstarrs9@smugmug.com",
                        Gender = "Male",
                        PhoneNumber = "6881532908",
                        Score = 3,
                        IdClass = 8
                    }
                );
                contextSt.SaveChanges();
            }
        }
    }
}
