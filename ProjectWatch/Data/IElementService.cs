using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ProjectWatch.Models;
using ProjectWatch.Pages.Project;
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
            project.Elements.Remove(element);
        }

        public E Create(Project p)
        {
            var e = CreateInstance();
            p.Elements.Add(e);
            return e;
        }

        internal abstract E CreateInstance();



        public abstract RenderFragment Draw(Element e);
        
    }
}
