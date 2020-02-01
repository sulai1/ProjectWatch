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
        private readonly IElementService<Element> elementService;


        public ProjectService(IServiceScopeFactory serviceScopeFactory, IElementService<Element> elementService)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.elementService = elementService;
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

        public Task<E> GetElementAssync<E>(Guid id) where E : Element
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ProjectDB>();
                var e = db.Element.OfType<E>().Where(e => e.ID == id).First();
                return Task.FromResult(e);
            }
        }

        public E ElementService<E>() where E : IElementService<Element>
        {
            return (E)elementService;
        }
    }
}
