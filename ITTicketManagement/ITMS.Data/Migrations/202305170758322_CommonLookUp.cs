namespace ITMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommonLookUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommonLookUps",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ConfigName = c.String(),
                        ConfigKey = c.String(),
                        ConfigValue = c.String(),
                        DisplayOrder = c.Int(),
                        Description = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Guid(),
                        UpdatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommonLookUps");
        }
    }
}
