﻿using prmToolkit.AccessMultipleDatabaseWithAdoNet.Databases;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Helpers.Mapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace prmToolkit.AccessMultipleDatabaseWithAdoNet
{
    public abstract class AbstractRepository
    {
        /// <summary>
        /// Obtém uma lista de objetos ou entidade vinda do banco de dados.
        /// </summary>
        /// <typeparam name="TDto">Tipo de objeto que deseja retornar na lista</typeparam>
        /// <param name="commandSql">Parametros necessários para realizar a consulta no banco de dados</param>
        /// <returns>Retorna uma lista de objeto preenchido com as informações do banco de dados</returns>
        protected IEnumerable<TDto> GetCollection<TDto>(CommandSql commandSql) where TDto : class, new()
        {
            AbstractDatabase database = DatabaseFactory.CreateDatabase(commandSql.EnumDatabaseType, commandSql.StringConnection);
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(commandSql.CommandText, connection))
                {
                    //Adiciona os parametros no command
                    if (commandSql.Parametros != null)
                    {
                        commandSql.Parametros.ForEach(x => command.Parameters.Add(x));
                    }

                    //Define configurações do command
                    command.CommandType = commandSql.CommandType;
                    command.CommandTimeout = commandSql.CommandTimeout;
                    command.CommandText = commandSql.CommandText;
                    

                    //Converte o datareader em List
                    List<TDto> objectCollection = new List<TDto>();
                    objectCollection = ObjectMapper.FillCollection<TDto>(command.ExecuteReader());

                    return objectCollection;

                }
            }
        }

        /// <summary>
        /// Obtém o primeiro objeto de uma lista de objetos vinda do banco de dados.
        /// </summary>
        /// <typeparam name="TDto">Tipo de objeto que deseja retornar na lista</typeparam>
        /// <param name="commandSql">Parametros necessários para realizar a consulta no banco de dados</param>
        /// <returns>Retorna um objeto preenchido com as informações do banco de dados</returns>
        protected TDto FirstOrDefault<TDto>(CommandSql commandSql) where TDto : class, new()
        {
            AbstractDatabase database = DatabaseFactory.CreateDatabase(commandSql.EnumDatabaseType, commandSql.StringConnection);
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(commandSql.CommandText, connection))
                {
                    //Adiciona os parametros no command
                    if (commandSql.Parametros != null)
                    {
                        commandSql.Parametros.ForEach(x => command.Parameters.Add(x));
                    }

                    //Define configurações do command
                    command.CommandType = commandSql.CommandType;
                    command.CommandTimeout = commandSql.CommandTimeout;
                    command.CommandText = commandSql.CommandText;


                    //Converte o datareader em List
                    
                    TDto entity = ObjectMapper.FillCollection<TDto>(command.ExecuteReader()).FirstOrDefault();

                    return entity;

                }
            }
        }

        /// <summary>
        /// Obtém o último objeto de uma lista de objetos vinda do banco de dados.
        /// </summary>
        /// <typeparam name="TDto">Tipo de objeto que deseja retornar na lista</typeparam>
        /// <param name="commandSql">Parametros necessários para realizar a consulta no banco de dados</param>
        /// <returns>Retorna um objeto preenchido com as informações do banco de dados</returns>
        protected TDto LastOrDefault<TDto>(CommandSql commandSql) where TDto : class, new()
        {
            AbstractDatabase database = DatabaseFactory.CreateDatabase(commandSql.EnumDatabaseType, commandSql.StringConnection);
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(commandSql.CommandText, connection))
                {
                    //Adiciona os parametros no command
                    if (commandSql.Parametros != null)
                    {
                        commandSql.Parametros.ForEach(x => command.Parameters.Add(x));
                    }

                    //Define configurações do command
                    command.CommandType = commandSql.CommandType;
                    command.CommandTimeout = commandSql.CommandTimeout;
                    command.CommandText = commandSql.CommandText;


                    //Converte o datareader em List

                    TDto entity = ObjectMapper.FillCollection<TDto>(command.ExecuteReader()).LastOrDefault();

                    return entity;

                }
            }
        }

        /// <summary>
        /// Executa uma instrução SQL contra o objeto Connection de dados do .NET Framework e retorna o número de linhas afetadas.
        /// </summary>
        /// <param name="commandSql"></param>
        /// <returns></returns>
        protected int ExecuteNonQuery(CommandSql commandSql)
        {
            AbstractDatabase database = DatabaseFactory.CreateDatabase(commandSql.EnumDatabaseType, commandSql.StringConnection);
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(commandSql.CommandText, connection))
                {
                    //Adiciona os parametros no command
                    if (commandSql.Parametros != null)
                    {
                        commandSql.Parametros.ForEach(x => command.Parameters.Add(x));
                    }

                    //Define consfigurações do command
                    command.CommandType = commandSql.CommandType;
                    command.CommandTimeout = commandSql.CommandTimeout;

                    //Executa comando e exibe o número de linhas afetadas
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Executa a consulta e retorna a primeira coluna da primeira linha no resultset retornado pela consulta. Colunas ou linhas extras são ignoradas.
        /// </summary>
        /// <param name="commandSql"></param>
        /// <returns></returns>
        protected object ExecuteScalar(CommandSql commandSql)
        {
            AbstractDatabase database = DatabaseFactory.CreateDatabase(commandSql.EnumDatabaseType, commandSql.StringConnection);
            using (IDbConnection connection = database.CreateOpenConnection())
            {
                using (IDbCommand command = database.CreateCommand(commandSql.CommandText, connection))
                {
                    //Adiciona os parametros no command
                    if (commandSql.Parametros != null)
                    {
                        commandSql.Parametros.ForEach(x => command.Parameters.Add(x));
                    }

                    //Define consfigurações do command
                    command.CommandType = commandSql.CommandType;
                    command.CommandTimeout = commandSql.CommandTimeout;

                    //Executa comando e exibe o número de linhas afetadas
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
