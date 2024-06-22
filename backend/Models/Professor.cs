﻿namespace MyUniversityAPP.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }
        // Supondo que um professor pode lecionar várias disciplinas
        public virtual List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

    }
}