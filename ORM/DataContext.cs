using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ORM
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="options"></param>
        public DataContext(DbContextOptions<DataContext> options):
            base(options)
        { }

        public DbSet<Notes> Notes { get; set; }//Set of Notes from data base    
    }
}
