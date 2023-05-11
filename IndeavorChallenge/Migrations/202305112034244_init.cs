namespace IndeavorChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        surname = c.String(),
                        name = c.String(),
                        hiringDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        dateCreated = c.DateTime(nullable: false),
                        Employee_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.Employee_id)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Skills", new[] { "Employee_id" });
            DropTable("dbo.Skills");
            DropTable("dbo.Employees");
        }
    }
}
