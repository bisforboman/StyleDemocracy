namespace StyleDemocracy
{
    public abstract class Id
    {
        public string Value { get; }

        protected Id(string value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();

        public override int GetHashCode() => Value.GetHashCode();
    } 
}
