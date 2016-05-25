# CultureBase

Project designed to study the implementation of Resources of culture seeking information on SQLServer database.

The model used is that of the [Nadeem Afana's](http://afana.me/post/aspnet-mvc-internationalization-store-strings-in-database-or-xml.aspx)

A change was made so that the cache is restarted at the desired time, a solution for database, for example, that allows the user to change the culture at any time can not depend on restarting the application to the new cache.

Before attempting to understand the project read the whole [post](http://afana.me/post/aspnet-mvc-internationalization-store-strings-in-database-or-xml.aspx), with it you will better understand the porjeto.

# Changes to maintenance Cache

 - The BaseResourceProvider class suffered an inclusion of a method.
```
public void ResetCache()
{
  resources = null;
}
```
The variable resources is where the culture data are included and maintained, by annulling the variable you force a new query to the database and new feed variable.

 - The IResourceProvider interface has undergone the inclusion of a new method
```
void ResetCache();        
```

 - The ResourceBuilder class has undergone a change in the Create method.
 
 The constant header became thus:
 
 ```
const string header =
@"using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
    
namespace {0} {{
        public class {1} {{
            private static IResourceProvider resourceProvider = new {2}();

    {3}

        public static void reset(){{
            resourceProvider.ResetCache();
        }}

}}  
      
}}";
```

# Using the cache reset function

You can see the controller HomeController method including a reset is done only for the test:
```
public void reset()
{
  Resources.Resources.reset();
}
```

All implementation of how to test the cache in views were based on the guide also [Nadeem Afana's](http://afana.me/post/aspnet-mvc-internationalization.aspx)

