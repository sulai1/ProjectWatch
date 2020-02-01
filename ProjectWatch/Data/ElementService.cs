using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using ProjectWatch.Models;
using ProjectWatch.Pages;
using ProjectWatch.Pages.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWatch.Data
{
    public class ElementService : IElementService<Element>
    {
        private string name = "Default";
        public override string ServiceName { get => name; set => name = value; }

        public ElementService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        
        }

        internal override Element CreateInstance()
        {
            return new Element { ID = Guid.NewGuid(), Type = "Default" };
        }

        public override RenderFragment Draw(Element e)
        {
            return new RenderFragment(builder =>
                            {
                                builder.OpenComponent<ElementView>(0);
                                builder.AddAttribute(0, "Element", e);
                                builder.CloseComponent();
                            });
        }
    }
}
