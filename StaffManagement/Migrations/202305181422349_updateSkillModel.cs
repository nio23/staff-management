namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSkillModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "name", c => c.String());
        }
    }
}
