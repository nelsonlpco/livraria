using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MySql.Data.MySqlClient;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;
using System.Reflection;

namespace LivrariaHBSIS.Infra
{
    public class NHContext : IDisposable
    {
        public ISession Session;
        public ITransaction Transaction;
        public static ISessionFactory SessionFactory;
        public NHContext()
        {
            SessionFactory = CreateSessionFactoryMySql();
            Session = SessionFactory.OpenSession();
        }
        public void BeginTransaction()
        {
            Transaction = Session.BeginTransaction();
        }

        public static ISessionFactory CreateSessionFactory()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database\estoque.mdf;Integrated Security=True";
            return SessionFactory ?? (SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                .BuildSessionFactory());
        }

        public static ISessionFactory CreateSessionFactoryMySql()
        {

            var connectionString = @"server=www.nelsonlpco.com.br;Uid=root;Pwd=HbSisr00t;persistsecurityinfo=True;database=nelsonlp_livrariahbsis";
            return SessionFactory ?? (SessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory());
        }

        public void Dispose()
        {
            if (SessionFactory != null)
            {
                SessionFactory.Dispose();
            }

        }
    }

}
