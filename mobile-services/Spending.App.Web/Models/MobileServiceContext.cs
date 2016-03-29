using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server.Tables;
using Spending.App.Web.DataObjects;

namespace Spending.App.Web.Models
{
    public class MobileServiceContext : DbContext
    {
        private const string ConnectionStringName = "Name=Spending_ConnectionString";

        public MobileServiceContext() : base(ConnectionStringName)
        {
        }

        public DbSet<ExpenseItem> ExpenseItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }
    }
}
