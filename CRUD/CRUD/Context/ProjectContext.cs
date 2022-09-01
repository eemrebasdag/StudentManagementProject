using CRUD.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = @"Server=EMRE;Database=CodeFirstSchool;Integrated Security=True";
        }
        public DbSet<Student> Students { get; set; }
    }
}
