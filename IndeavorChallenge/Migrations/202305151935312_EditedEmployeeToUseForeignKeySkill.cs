namespace IndeavorChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedEmployeeToUseForeignKeySkill : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Skills", new[] { "Employee_id" });
            DropColumn("dbo.Skills", "Employee_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Employee_id", c => c.Int());
            CreateIndex("dbo.Skills", "Employee_id");
            AddForeignKey("dbo.Skills", "Employee_id", "dbo.Employees", "id");
        }
    }
}
