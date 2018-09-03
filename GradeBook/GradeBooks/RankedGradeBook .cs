using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }
            var threshold = (int)Math.Ceiling(Students.Count * .2);
            var grades = Students.OrderByDescending(s => s.AverageGrade).Select(a => a.AverageGrade).ToList();
            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[2*threshold - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[3*threshold - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[4*threshold - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
