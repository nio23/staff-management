namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedemployeeSkills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Employee_id", c => c.Int());
            CreateIndex("dbo.Skills", "Employee_id");
            AddForeignKey("dbo.Skills", "Employee_id", "dbo.Employees", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Skills", new[] { "Employee_id" });
            DropColumn("dbo.Skills", "Employee_id");
        }
    }
}
