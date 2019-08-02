using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistences
{
    public class EmployeeDbcontext : DbContext
    {
        public DbSet <Employee> Employee  { get; set; }

        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options)
            : base(options)
        { }

    }
}
