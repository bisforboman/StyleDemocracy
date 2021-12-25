using System;
using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class RuleMapper
    {
        private FileRepository Repository { get; }

        public RuleMapper(FileRepository repository)
        {
            Repository = repository;
        }

        public Rule? Lookup(CheckId checkId) => Repository.LoadRules().FirstOrDefault(r => r.CheckId == checkId);        
    }
}
