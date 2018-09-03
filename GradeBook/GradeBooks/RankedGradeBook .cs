using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            Students.OrderBy(students => students.AverageGrade).ToList();
            Student targetStudent;
            var ranking = 0;

            foreach (Student student in Students)
            {
                if (student.AverageGrade == averageGrade)
                {
                    targetStudent = student;
                    ranking = Students.IndexOf(targetStudent)+1;
                    break;
                }
            }

            if(ranking > (int)Math.Ceiling(Students.Count *.8))
            {
                return 'A';
            }
            else if (ranking > (int)Math.Ceiling(Students.Count *.6))
            {
                return 'B';
            }   
            else if (ranking > (int)Math.Ceiling(Students.Count *.4))
            {
                return 'C';
            } 
            else if (ranking > (int)Math.Ceiling(Students.Count *.2))
            {
                return 'D';
            }

            return 'F';
        }
    }
}
