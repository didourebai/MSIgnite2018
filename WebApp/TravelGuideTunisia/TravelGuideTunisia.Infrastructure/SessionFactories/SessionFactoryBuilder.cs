using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using TravelGuideTunisia.Infrastructure.BaseContext;
using TravelGuideTunisia.Infrastructure.BaseContext.Enumerations;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using log4net;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ConfigurationManager = System.Configuration.ConfigurationManager;



namespace TravelGuideTunisia.Infrastructure.SessionFactories
{
    public class SessionFactoryBuilder
    {

        public static ISessionFactory BuildSessionFactory(string dbmsTypeAsString, string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            var dbmsType = (EAvailableDBMS)Enum.Parse(typeof(EAvailableDBMS), dbmsTypeAsString);

            switch (dbmsType)
            {
                case EAvailableDBMS.Oracle10:
                    {
                        return BuildSessionFactoryForOracle10(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.SqlServer7:
                    {
                        return BuildSessionFactoryForSqlServer7(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.SqlServer2000:
                    {
                        return BuildSessionFactoryForSqlServer2000(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.SqlServer2005:
                    {
                        return BuildSessionFactoryForSqlServer2005(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.SqlServer2008:
                    {
                        return BuildSessionFactoryForSqlServer2008(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.SqlServer2012:
                    {
                        return BuildSessionFactoryForSqlServer2012(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.MySql:
                    {
                        return BuildSessionFactoryForMySql(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.PostgreSQL:
                    {
                        return BuildSessionFactoryForPostgreSQL(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.PostgreSQL81:
                    {
                        return BuildSessionFactoryForPostgreSQL81(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                case EAvailableDBMS.PostgreSQL82:
                    {
                        return BuildSessionFactoryForPostgreSQL82(connectionStringName, entityMappingTypes, withLog, create, update);
                    }
                //case EAvailableDBMS.SQLite:
                //    {
                //        return BuildSessionFactoryForSqLite(connectionString, entityMappingTypes, withLog, create, update);
                //    }
                default:
                    {
                        throw new NotSupportedException(String.Format("The DBMS Type {0} is not supported.", dbmsTypeAsString));
                    }
            }
        }


        private delegate ISessionFactory BuildSessionFactoryDelegate(FluentConfiguration config);

        private delegate FluentConfiguration FluentConfigurationDelegate(string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false);


        #region Private Methods

        private static ISessionFactory BuildSessionFactoryForOracle10(string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            if (withLog)
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
            }

            return Fluently.Configure()
                .Database(OracleClientConfiguration.Oracle10
                .ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForMySql(string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            if (withLog)
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("App.config"));
            }

            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                .ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForPostgreSQL(string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                    .ConnectionString(connectionStringName))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForPostgreSQL81(string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL81
                .ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForPostgreSQL82(string connectionStringName, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82
                .ConnectionString(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForSqlServer7(string connectionString, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql7.ConnectionString(connectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForSqlServer2000(string connectionString, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2000.ConnectionString(connectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForSqlServer2005(string connectionString, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(connectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForSqlServer2008(string connectionString, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        private static ISessionFactory BuildSessionFactoryForSqlServer2012(string connectionString, List<Type> entityMappingTypes, bool withLog = true, bool create = false, bool update = false)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => entityMappingTypes.ForEach(e => { m.FluentMappings.Add(e); }))
                .CurrentSessionContext("call")
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
        }

        /// <summary>
        /// Build the schema of the database.
        /// </summary>
        /// <param name="config">Configuration.</param>
        private static void BuildSchema(Configuration config, bool create = false, bool update = false)
        {
            if (create)
            {
                new SchemaExport(config).Create(false, true);
            }
            else
            {
                new SchemaUpdate(config).Execute(false, update);
            }
        }

        #endregion

        //private class CustomerSQLite20Driver : NHibernate.Driver.SQLite20Driver
        //{
        //    protected override void InitializeParameter(System.Data.IDbDataParameter dbParam, string name, NHibernate.SqlTypes.SqlType sqlType)
        //    {
        //        base.InitializeParameter(dbParam, name, sqlType);
        //        if ((sqlType is StringClobSqlType))
        //        {
        //            dbParam.DbType = System.Data.DbType.String;
        //        }
        //        if ((sqlType is NHibernate.SqlTypes.BinaryBlobSqlType))
        //        {
        //            dbParam.DbType = System.Data.DbType.Binary;
        //        }
        //    }
        //}
    }
}
