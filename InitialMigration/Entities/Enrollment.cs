using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace InitialMigration.Entities
{
    public class Enrollment
    {

        public int StudentId { get; set; }
        public int SectionId { get; set; }

        public Student Student { get; set; } = null!;
        public Section Section { get; set; } = null!;
    }
}
