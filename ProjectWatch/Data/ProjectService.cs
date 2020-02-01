using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWatch.Data
{
    public class ProjectService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ProjectService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public Task<Project> GetProjectAsync()
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ProjectDB>();
                Project project = db.Projects.First();
                db.Element.Load(); 
                return Task.FromResult(project);
            }
        }
    }
}
