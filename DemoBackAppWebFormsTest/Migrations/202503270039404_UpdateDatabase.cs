namespace DemoBackAppWebFormsTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Products", newName: "Product");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Product", newName: "Products");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
