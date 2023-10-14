namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployeeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "surname", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "name", c => c.String());
            AlterColumn("dbo.Employees", "surname", c => c.String());
        }
    }
}
