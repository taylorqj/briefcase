namespace briefcase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "RowCreated", c => c.DateTime());
            AlterColumn("dbo.Categories", "RowModified", c => c.DateTime());
            AlterColumn("dbo.Posts", "RowCreated", c => c.DateTime());
            AlterColumn("dbo.Posts", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "LastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "RowCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "RowModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "RowCreated", c => c.DateTime(nullable: false));
        }
    }
}
