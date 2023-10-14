namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToSkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "description");
        }
    }
}
