namespace IndeavorChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateEmployeesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Employees ( surname, name,  hiringDate ) VALUES ( 'Duke' , 'John',  '2008-02-21' )");
            Sql("INSERT INTO Employees ( surname, name,  hiringDate ) VALUES ( 'Morsa' , 'George',  '2017-05-18' )");
        }


    

        public override void Down()
        {
        }
    }
}
