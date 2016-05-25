using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace Resources {
        public class Resources {
            private static IResourceProvider resourceProvider = new DbResourceProvider();

                
        /// <summary>Person Name</summary>
        public static string NomePessoa {
               get {
                   return (string) resourceProvider.GetResource("NomePessoa", CultureInfo.CurrentUICulture.Name);
               }
            }
            
        /// <summary>eu sou o texto en-us</summary>
        public static string texto1 {
               get {
                   return (string) resourceProvider.GetResource("texto1", CultureInfo.CurrentUICulture.Name);
               }
            }

        public static void reset(){
            resourceProvider.ResetCache();
        }

        }        
}
