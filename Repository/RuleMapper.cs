using System;
using System.Collections.Generic;
using System.Linq;

namespace StyleDemocracy
{
    public class RuleMapper
    {
        private IReadOnlyList<Rule> AllAvailableRules => "styles.json"
            .ReadFile()
            .FromJson<IEnumerable<PersistedRule>>()
            .Select(r => new Rule(
                typeName: r.TypeName ?? string.Empty,
                checkId: new CheckId(r.CheckId ?? string.Empty),
                category: EnumHelper.ToDomain(r.Category ?? string.Empty)
            ))
            .ToList();

        private Repository Repository { get; }

        public RuleMapper(Repository repository)
        {
            Repository = repository;
        }

        public IReadOnlyList<Rule> Load() => AllAvailableRules;

        public Rule? Lookup(CheckId checkId) => AllAvailableRules.FirstOrDefault(r => r.CheckId == checkId);        
    }
}
