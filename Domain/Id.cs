namespace StyleDemocracy
{
    public abstract class Id
    {
        public string Value { get; }

        protected Id(string value)
        {
            Value = value;
        }
    } 
}
