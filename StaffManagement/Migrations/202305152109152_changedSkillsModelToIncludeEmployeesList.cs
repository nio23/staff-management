namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedSkillsModelToIncludeEmployeesList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Employee_id", "dbo.Employees");
            DropIndex("dbo.Skills", new[] { "Employee_id" });
            CreateTable(
                "dbo.SkillEmployees",
                c => new
                    {
                        Skill_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_id, t.Employee_id })
                .ForeignKey("dbo.Skills", t => t.Skill_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Skill_id)
                .Index(t => t.Employee_id);
            
            DropColumn("dbo.Skills", "Employee_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Employee_id", c => c.Int());
            DropForeignKey("dbo.SkillEmployees", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.SkillEmployees", "Skill_id", "dbo.Skills");
            DropIndex("dbo.SkillEmployees", new[] { "Employee_id" });
            DropIndex("dbo.SkillEmployees", new[] { "Skill_id" });
            DropTable("dbo.SkillEmployees");
            CreateIndex("dbo.Skills", "Employee_id");
            AddForeignKey("dbo.Skills", "Employee_id", "dbo.Employees", "id");
        }
    }
}
