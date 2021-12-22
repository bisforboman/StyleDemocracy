using System;

namespace StyleDemocracy
{
    class Program
    {
        static void Main(string[] _)
        {
            var json = "Styles.json"
                .ReadFile()
                .FromJson<PersistedSetOfRules>();

            Console.WriteLine(json.ToJson());
            
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();   
        }
    }
}
