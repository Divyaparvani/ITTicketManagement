namespace ITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userstests : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles1", newName: "UserRoles");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        UserName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        MobileNo = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserRoles", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.UserRoles", "RoleId", c => c.Guid(nullable: false));
            DropColumn("dbo.UserRoles", "FirstName");
            DropColumn("dbo.UserRoles", "LastName");
            DropColumn("dbo.UserRoles", "Email");
            DropColumn("dbo.UserRoles", "Password");
            DropColumn("dbo.UserRoles", "UserName");
            DropColumn("dbo.UserRoles", "Gender");
            DropColumn("dbo.UserRoles", "MobileNo");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserRoles", "MobileNo", c => c.String());
            AddColumn("dbo.UserRoles", "Gender", c => c.String(nullable: false));
            AddColumn("dbo.UserRoles", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.UserRoles", "Password", c => c.String());
            AddColumn("dbo.UserRoles", "Email", c => c.String(nullable: false));
            AddColumn("dbo.UserRoles", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.UserRoles", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.UserRoles", "RoleId");
            DropColumn("dbo.UserRoles", "UserId");
            DropTable("dbo.Users");
            RenameTable(name: "dbo.UserRoles", newName: "UserRoles1");
        }
    }
}
