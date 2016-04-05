using Contracts;
using System.ComponentModel.Composition;

namespace ExportingLibrary2
{
    [Export(typeof(IStringMutator))]
    public class Component2 : IStringMutator
    {
        
        public string ComponentDescription
        {
            get { return "Converts the string to uppercase"; }
        }

        public string MutateString(string s)
        {
            return s.ToUpper();
        }

    }
}
