using System;
using System.Collections.Generic;
using DesafioAppCadastroDotNet.Interfaces;


namespace DesafioAppCadastroDotNet
{

    public class CursoRepositorio : IRepositorio<Curso>
	{
		private List<Curso> listaCurso = new List<Curso>();
    
        public void Atualiza(int id, Curso objeto)
        {
            listaCurso[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaCurso[id].Excluir();
        }

        public void Insere(Curso objeto)
        {
            listaCurso.Add(objeto);
        }

        public List<Curso> Lista()
        {
            return listaCurso;
        }

        public int ProximoId()
        {
            return listaCurso.Count;
        }

        public Curso RetornaPorId(int id)
        {
            return listaCurso[id];
		}
    }
}