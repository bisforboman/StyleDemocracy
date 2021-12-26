using System.Collections.Generic;

namespace StyleDemocracy
{
    public class RuleSet
    {
        public RuleSetId RuleSetId { get; }
        public IReadOnlyList<Rule> ActiveRules { get; }

        public RuleSet(RuleSetId id, IReadOnlyList<Rule> rules)
        {
            RuleSetId = id;
            ActiveRules = rules;
        }
    }
}
