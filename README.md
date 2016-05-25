# CultureBase

Projeto feito para estudar a implementação de Resources de culture buscando informações no banco de dados SQLServer.

O modelo utlizado é o do [Nadeem Afana's](http://afana.me/post/aspnet-mvc-internationalization-store-strings-in-database-or-xml.aspx)

Foi feita uma alteração para que o cache seja reiniciado no momento desejado, uma solução por banco de dados, por exemplo, que permite a alteração das culturas pelo usuário a qualquer momento não pode depender de reiniciar a aplicação para o novo cache.

Antes de tentar entender o projeto leia todo o post, com ele você vai entender melhor o porjeto.

# Alterações para manutenção do Cache

 - A classe BaseResourceProvider sofreu uma incluão de um metodo.
```
public void ResetCache()
{
  resources = null;
}
```
A variável resources é onde os dados das culturas são incluído e mantidos, ao anular a variável você força uma nova consulta ao banco de dados e nova alimentação da variável.

 - A interface IResourceProvider sofreu a inclusão de um novo metodo.
```
void ResetCache();        
```

 - A classe ResourceBuilder sofreu uma alteração dentro do metodo Create.
 
 A constant header ficou dessa forma:
 
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

# Utilização da função de reset de cache

Você pode observar no controler HomeController a inclusão de um metodo feito somente para teste do reset:
```
public void reset()
{
  Resources.Resources.reset();
}
```

Todas as implementação de como testar o cache nas views foram feitas baseadas no guia também do [Nadeem Afana's](http://afana.me/post/aspnet-mvc-internationalization.aspx)

