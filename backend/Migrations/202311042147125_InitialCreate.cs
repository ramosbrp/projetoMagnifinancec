namespace MyUniversityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        NumeroMatricula = c.String(),
                    })
                .PrimaryKey(t => t.AlunoId);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        MatriculaId = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        DisciplinaId = c.Int(nullable: false),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MatriculaId)
                .ForeignKey("dbo.Alunoes", t => t.AlunoId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.DisciplinaId, cascadeDelete: true)
                .Index(t => t.AlunoId)
                .Index(t => t.DisciplinaId);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CursoId = c.Int(nullable: false),
                        Professor_ProfessorId = c.Int(),
                    })
                .PrimaryKey(t => t.DisciplinaId)
                .ForeignKey("dbo.Cursoes", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.Professor_ProfessorId)
                .Index(t => t.CursoId)
                .Index(t => t.Professor_ProfessorId);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Disciplinas", "Professor_ProfessorId", "dbo.Professors");
            DropForeignKey("dbo.Matriculas", "DisciplinaId", "dbo.Disciplinas");
            DropForeignKey("dbo.Disciplinas", "CursoId", "dbo.Cursoes");
            DropForeignKey("dbo.Matriculas", "AlunoId", "dbo.Alunoes");
            DropIndex("dbo.Disciplinas", new[] { "Professor_ProfessorId" });
            DropIndex("dbo.Disciplinas", new[] { "CursoId" });
            DropIndex("dbo.Matriculas", new[] { "DisciplinaId" });
            DropIndex("dbo.Matriculas", new[] { "AlunoId" });
            DropTable("dbo.Professors");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Alunoes");
        }
    }
}
