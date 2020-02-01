using Microsoft.EntityFrameworkCore;
using ProjectWatch.Models;
using System;
using System.Collections.Generic;

namespace ProjectWatch
{
    public class ProjectDB : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Element> Element { get; set; }

        public ProjectDB(DbContextOptions<ProjectDB> options)
            : base(options)
        {
        }
    }
}