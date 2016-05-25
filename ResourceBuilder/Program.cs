using Resources.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Resources.Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(@"Data Source=(localdb)\v11.0;Initial Catalog=MvcInternationalization;Integrated Security=True;Pooling=False"),
                summaryCulture: "en-us");
            Console.WriteLine("Created file {0}", filePath);
            Console.ReadKey();
        }
    }
}
