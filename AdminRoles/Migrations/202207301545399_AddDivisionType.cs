namespace AdminRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDivisionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DivisionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentTypes", t => t.DepartmentTypeId, cascadeDelete: true)
                .Index(t => t.DepartmentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DivisionTypes", "DepartmentTypeId", "dbo.DepartmentTypes");
            DropIndex("dbo.DivisionTypes", new[] { "DepartmentTypeId" });
            DropTable("dbo.DivisionTypes");
        }
    }
}
