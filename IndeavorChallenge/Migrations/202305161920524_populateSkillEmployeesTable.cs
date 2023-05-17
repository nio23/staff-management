namespace IndeavorChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateSkillEmployeesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SkillEmployees  VALUES ( 24 , 1 )");
            Sql("INSERT INTO SkillEmployees  VALUES ( 25 , 1 )");
            Sql("INSERT INTO SkillEmployees  VALUES ( 25 , 2 )");
            Sql("INSERT INTO SkillEmployees  VALUES ( 33 , 2 )");
        }
        
        public override void Down()
        {
        }
    }
}
