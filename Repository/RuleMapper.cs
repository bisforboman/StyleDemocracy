using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StyleDemocracy
{
    public class RuleMapper
    {
        private FileRepository Repository { get; }

        public RuleMapper(FileRepository repository)
        {
            Repository = repository;
        }

        public async Task<Rule?> Lookup(CheckId checkId) => (await Repository.LoadRules()).FirstOrDefault(r => r.CheckId == checkId);        
    }
}
