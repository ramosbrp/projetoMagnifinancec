namespace MyUniversityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoProfessorIdemDisciplina : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disciplinas", "Professor_ProfessorId", "dbo.Professors");
            DropIndex("dbo.Disciplinas", new[] { "Professor_ProfessorId" });
            RenameColumn(table: "dbo.Disciplinas", name: "Professor_ProfessorId", newName: "ProfessorId");
            AlterColumn("dbo.Disciplinas", "ProfessorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Disciplinas", "ProfessorId");
            AddForeignKey("dbo.Disciplinas", "ProfessorId", "dbo.Professors", "ProfessorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Disciplinas", "ProfessorId", "dbo.Professors");
            DropIndex("dbo.Disciplinas", new[] { "ProfessorId" });
            AlterColumn("dbo.Disciplinas", "ProfessorId", c => c.Int());
            RenameColumn(table: "dbo.Disciplinas", name: "ProfessorId", newName: "Professor_ProfessorId");
            CreateIndex("dbo.Disciplinas", "Professor_ProfessorId");
            AddForeignKey("dbo.Disciplinas", "Professor_ProfessorId", "dbo.Professors", "ProfessorId");
        }
    }
}
