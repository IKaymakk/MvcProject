namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addContentimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentImg1", c => c.String(maxLength: 300));
            AddColumn("dbo.Contents", "ContentImg2", c => c.String(maxLength: 300));
            AddColumn("dbo.Contents", "ContentImg3", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentImg3");
            DropColumn("dbo.Contents", "ContentImg2");
            DropColumn("dbo.Contents", "ContentImg1");
        }
    }
}
