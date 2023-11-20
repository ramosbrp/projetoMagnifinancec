namespace MyUniversityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfessorIdNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disciplinas", "ProfessorId", "dbo.Professors");
            DropIndex("dbo.Disciplinas", new[] { "ProfessorId" });
            AlterColumn("dbo.Disciplinas", "ProfessorId", c => c.Int());
            CreateIndex("dbo.Disciplinas", "ProfessorId");
            AddForeignKey("dbo.Disciplinas", "ProfessorId", "dbo.Professors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Disciplinas", "ProfessorId", "dbo.Professors");
            DropIndex("dbo.Disciplinas", new[] { "ProfessorId" });
            AlterColumn("dbo.Disciplinas", "ProfessorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Disciplinas", "ProfessorId");
            AddForeignKey("dbo.Disciplinas", "ProfessorId", "dbo.Professors", "Id", cascadeDelete: true);
        }
    }
}
