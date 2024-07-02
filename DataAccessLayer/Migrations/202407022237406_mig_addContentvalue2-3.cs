namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addContentvalue23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentValue2", c => c.String());
            AddColumn("dbo.Contents", "ContentValue3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentValue3");
            DropColumn("dbo.Contents", "ContentValue2");
        }
    }
}
