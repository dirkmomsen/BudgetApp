namespace BudgetApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedDataToItemType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ItemTypes (TypeCode, TypeName, Symbol) VALUES ('inc', 'Income', '+')");
            Sql("INSERT INTO ItemTypes (TypeCode, TypeName, Symbol) VALUES ('exp', 'Expense', '-')");
        }
        
        public override void Down()
        {
        }
    }
}
