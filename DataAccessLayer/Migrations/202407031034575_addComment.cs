namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentUserName = c.String(maxLength: 50),
                        CommentText = c.String(maxLength: 250),
                        HeadingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Headings", t => t.HeadingID, cascadeDelete: true)
                .Index(t => t.HeadingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Comments", new[] { "HeadingID" });
            DropTable("dbo.Comments");
        }
    }
}
