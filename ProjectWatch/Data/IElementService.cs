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

        public virtual void Add(E e, Project project)
        {
            project.Elements.Add(e);
        }

        public virtual void Delete(E element, Project project)
        {
            var e = project.Elements.Where(e=>e.ID==element.ID).First();
            project.Elements.Remove(e);
        }

        public E Create(Project p)
        {
            var e = CreateInstance();
            p.Elements.Add(e);
            return e;
        }

        internal abstract E CreateInstance();
    }
}
