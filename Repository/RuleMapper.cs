using System;
using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class RuleMapper
    {
        private Repository Repository { get; }

        public RuleMapper(Repository repository)
        {
            Repository = repository;
        }

        public Rule? Lookup(CheckId checkId) => Repository.LoadRules().FirstOrDefault(r => r.CheckId == checkId);        
    }
}
