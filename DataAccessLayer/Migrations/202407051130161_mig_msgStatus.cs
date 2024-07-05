namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_msgStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactMessageStatu", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatu");
            DropColumn("dbo.Contacts", "ContactMessageStatu");
        }
    }
}
