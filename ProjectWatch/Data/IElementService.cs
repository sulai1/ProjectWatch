using Microsoft.Extensions.DependencyInjection;
using ProjectWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWatch.Data
{
    public abstract class IElementService<E> where E: Models.Element
    {

        public abstract string ServiceName { get; set; }

        public E Element { get; set; }

        protected readonly IServiceScopeFactory serviceScopeFactory;

        public IElementService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public void Add(E e, Project project)
        {
            project.Elements.Add(e);
        }

        public void Delete(E e, Project project)
        {
            project.Elements.Remove(e);
        }

        public E Create(Project p)
        {
            var i = CreateInstance();
            p.Elements.Add(i);
            return i;
        }

        internal abstract E CreateInstance();
    }
}
