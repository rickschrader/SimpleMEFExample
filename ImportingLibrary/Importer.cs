using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;

namespace ImportingLibrary
{
    public class Importer
    {
        [ImportMany(typeof(IStringMutator))]
        private IEnumerable<IStringMutator> operations;

        public void DoImport()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in all assemblies in 
            //the same directory as the executing program
            catalog.Catalogs.Add(
             new DirectoryCatalog(
              Path.GetDirectoryName(
               Assembly.GetExecutingAssembly().Location)));


            //Create the CompositionContainer with the parts in the catalog
            CompositionContainer container = new CompositionContainer(catalog);

            //Fill the imports of this object
            container.ComposeParts(this);
        }

        public int AvailableNumberOfOperations
        {
            get
            {
                return (operations != null ? operations.Count() : 0);
            }
        }

        public List<string> CallAllComponents(string s)
        {
            var result = new List<string>();
            foreach (var op in operations)
            {
                Console.WriteLine(op.ComponentDescription);
                result.Add(op.MutateString(s));
            }

            foreach (var thisResult in result)
                Console.WriteLine(thisResult);

            return result;
        }
    }
}