using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemProgramming
{
    public class WorkInfo
    {
        public Guid Id = Guid.NewGuid();
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string Text { get; set; }
    }
}
