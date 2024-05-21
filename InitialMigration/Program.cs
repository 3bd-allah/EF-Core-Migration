using InitialMigration.Data;
using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace InitialMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using(var context = new AppDbContext())
            {
                foreach(var item in context.Sections.Include(e => e.Course).Include(e => e.Instructor)
                    .Include(e => e.Schedules))
                {
                    foreach(var scheule in item.Schedules)
                    {
                        foreach(var secSchedule in scheule.SectionShedules)
                        {

                            Console.WriteLine($"Course: {item.Course.CourseName}, " +
                                $"section: {item.SectionName}, " +
                            $"Instructor: {item.Instructor.FName} {item.Instructor.LName}, " +
                            $"schedule title: {scheule.Title} Start time: {secSchedule.StartTime}, End time: {secSchedule.EndTime}" +
                            $"SUN: {scheule.SUN}, MON:{scheule.MON}, TUE:{scheule.TUE}, WED:{scheule.WED}, THU:{scheule.THU}," +
                            $" FRI:{scheule.FRI}, SAT:{scheule.SAT} ");
                        }

                    }
                }

            }

        }
    }
}
