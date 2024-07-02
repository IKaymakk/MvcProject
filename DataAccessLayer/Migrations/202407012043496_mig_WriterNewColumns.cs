namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_WriterNewColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AddColumn("dbo.Writers", "WriterTel", c => c.String(maxLength: 20));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 16));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 100));
            DropColumn("dbo.Writers", "WriterTel");
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
