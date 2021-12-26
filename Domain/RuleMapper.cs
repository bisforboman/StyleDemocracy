using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StyleDemocracy
{
    public class RuleMapper
    {
        private IRepository Repository { get; }

        public RuleMapper(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<Rule?> Lookup(CheckId checkId) => (await Repository.LoadRules()).FirstOrDefault(r => r.CheckId == checkId);        
    }
}
