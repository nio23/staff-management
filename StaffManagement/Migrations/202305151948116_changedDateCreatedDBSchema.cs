namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDateCreatedDBSchema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "hiringDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Skills", "dateCreated", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "dateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "hiringDate", c => c.DateTime(nullable: false));
        }
    }
}
