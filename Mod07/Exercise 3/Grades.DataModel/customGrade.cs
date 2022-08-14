using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Grades.DataModel
{
    public partial class Grade
    {
        public bool ValidateAssessmentDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Date is later than the current day", "DateTime");
            }

            return true;
        }

        public bool ValidateAssessmentGrade(string assessment)
        {
            Match matchGrade = Regex.Match(assessment, @"^[A-E][+-]?$");

            if (!matchGrade.Success)
            {
                throw new ArgumentOutOfRangeException("Assessment is not in the valid range", "Assessment");
            }

            return true;
        }
    }
}
