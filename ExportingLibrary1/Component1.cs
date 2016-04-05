using Contracts;
using System.ComponentModel.Composition;

namespace ExportingLibrary1
{
    [Export(typeof(IStringMutator))]
    public class Component1 : IStringMutator
    {

        const string StringToAppend = "MEF is cool";

        public string ComponentDescription
        {
            get { return string.Format("Appends '{0}' to the string", StringToAppend); }
        }

        public string MutateString(string s)
        {
            return string.Format("{0} {1}", s, StringToAppend);
        }

    }
}