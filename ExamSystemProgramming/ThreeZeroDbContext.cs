using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystemProgramming
{
    public class ThreeZeroDbContext : DbContext
    {

        public ThreeZeroDbContext() : base ("Server=A-104-04;Database=ThreeZero;Trusted_Connection=true;")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<WorkInfo> WorkInfos { get; set; }
    }
}
