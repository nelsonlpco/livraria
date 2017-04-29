using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LivrariaHBSIS.domain;
using LivrariaHBSIS.Infra.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaHBSIS.Infra
{
    public class NHContext : IDisposable
    {
        public ISession Session;
        public ITransaction Transaction;
        public static ISessionFactory SessionFactory;

        public NHContext()
        {
            SessionFactory = CreateSessionFactory();
            Session = SessionFactory.OpenSession();
        }
        public void BeginTransaction()
        {
            Transaction = Session.BeginTransaction();
        }

        public static ISessionFactory CreateSessionFactory()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\github\livraria\LivrariaHBSIS\LivrariaHBSIS.Infra\Database\estoque.mdf;Integrated Security=True";
            return SessionFactory ?? (SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
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
