using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyUniversityAPI.Models;


namespace MyUniversityAPI.Controllers
{
    public class AlunoController : Controller

    {
        // GET api/student
        public IEnumerable<Aluno> Get()
        {
            // Aqui você vai buscar todos os estudantes, por exemplo
            return new List<Aluno>();
        }

        // GET api/student/5
        public Aluno Get(int id)
        {
            // Aqui você vai buscar um estudante pelo ID
            return new Aluno();
        }

        // POST api/student
        public void Post( Aluno aluno)
        {
            // Aqui você vai criar um novo estudante
        }

        // PUT api/student/5
        public void Put(int id,  Aluno aluno)
        {
            // Aqui você vai atualizar um estudante pelo ID
        }

        // DELETE api/student/5
        public void Delete(int id)
        {
            // Aqui você vai deletar um estudante pelo ID
        }
    }
}