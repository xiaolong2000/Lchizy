using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Student.Models;

namespace Student.DataAccessLayer
{
  public  class ClassContext:DbContext
    {
        public DbSet<Clas> Clas { get; set; }
        public DbSet<Stu> Stu { get; set; }
    }
}
