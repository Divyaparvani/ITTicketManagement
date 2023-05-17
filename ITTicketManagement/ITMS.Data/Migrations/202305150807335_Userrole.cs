namespace ITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userrole : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserRoles", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.UserRoles", "RoleId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "RoleId", c => c.String());
            AlterColumn("dbo.UserRoles", "UserId", c => c.String());
        }
    }
}
