# prmToolkit

# AccessMultipleDatabaseWithAdoNet
Acesse mais de um tipo de banco de dados de forma fácil via ADO.NET.

Atualmente dando suporte aos bancos.

- SqlServer

- MySql

- Firebird



É possível implementar outros bancos de dados de forma fácil!

### Installation - AccessMultipleDatabaseWithAdoNet

Para instalar, abra o prompt de comando Package Manager Console do seu Visual Studio e digite o comando abaixo:

Para adicionar somente a referencia a dll
```sh
Install-Package prmToolkit.AccessMultipleDatabaseWithAdoNet
```
### Exemplo de como usar

```sh
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prmToolkit.AccessMultipleDatabaseWithAdoNet;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using System.Collections.Generic;
using System.Linq;
namespace prmToolkit.Test
{

    [TestClass]
    public class AccessMultipleDatabaseWithAdoNetTest : AbstractRepository 
    {
        [TestMethod()]
        public void ObterDadosTest()
        {
            //Define a string de conexão
            string  stringConexao = "Server=seu ip; Database=nome_do_banco; Port=3306; Uid=usuario; Pwd=senha;"
            
            //Monta a query
            string query = @"select u.nome, u.login, u.senha from usuario u;";
            
            //Define em que banco será executada a aquery
            CommandSql cmd = new CommandSql(stringConexao, query, EnumDatabaseType.MySql);

            //Obtem os dados do banco de dados MySql
            List<Usuario> usuarios = GetCollection<Usuario>(cmd)?.ToList();


            Assert.IsTrue(usuarios.Count() > 0);
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}

```
# VEJA TAMBÉM
## Grupo de Estudo no Telegram
- [Participe gratuitamente do grupo de estudo](https://t.me/blogilovecode)

## Cursos baratos!
- [Meus cursos](https://olha.la/udemy)

## Novidades, cupons de descontos e cursos gratuitos
https://olha.la/ilovecode-receber-cupons-novidades
