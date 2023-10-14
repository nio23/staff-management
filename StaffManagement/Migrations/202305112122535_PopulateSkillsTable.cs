namespace StaffManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSkillsTable : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO Skills ( name, dateCreated ) VALUES ( 'creativity' , '2008-02-21' )");
            Sql("INSERT INTO Skills ( name, dateCreated ) VALUES ( 'analytical' , '2009-08-20' )");
        }
        
        public override void Down()
        {
        }
    }
}
