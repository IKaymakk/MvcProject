namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addHeadingimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingImg", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "HeadingImg");
        }
    }
}
