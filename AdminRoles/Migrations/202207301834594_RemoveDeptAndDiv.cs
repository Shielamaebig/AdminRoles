namespace AdminRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDeptAndDiv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DivisionTypes", "DepartmentTypeId", "dbo.DepartmentTypes");
            DropIndex("dbo.DivisionTypes", new[] { "DepartmentTypeId" });
            DropTable("dbo.DepartmentTypes");
            DropTable("dbo.DivisionTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DivisionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.DivisionTypes", "DepartmentTypeId");
            AddForeignKey("dbo.DivisionTypes", "DepartmentTypeId", "dbo.DepartmentTypes", "Id", cascadeDelete: true);
        }
    }
}
