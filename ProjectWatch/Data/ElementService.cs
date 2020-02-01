using Microsoft.Extensions.DependencyInjection;
using ProjectWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWatch.Data
{
    public class ElementService : IElementService<Element>
    {
        private string name = "test";

        public ElementService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public override string ServiceName { get => name; set => name = value; }

        internal override Element CreateInstance()
        {
            return new Element { ID = Guid.NewGuid(), Type = "Default" };
        }
    }
}
