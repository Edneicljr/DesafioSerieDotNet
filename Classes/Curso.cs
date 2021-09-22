using System;

namespace DesafioAppCadastroDotNet
{
    public class Curso : EntidadeBase
     {
         
        // Atributos
		private Tema Tema { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private string EnderecoWeb { get; set; }
		private int Duracao { get; set; }
		private bool Excluido {get; set;}
        

        // Métodos
		public Curso(int id, Tema tema, string titulo, string descricao, string enderecoWeb, int duracao)
		{
          	this.Id = id;
			this.Tema = tema;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.EnderecoWeb = enderecoWeb;
			this.Duracao = duracao;
            this.Excluido = false;
		}

        public Curso(int id, Tema tema, string titulo, int duracao, string descricao)
        {
            Id = id;
            Tema = tema;
            Titulo = titulo;
            Duracao = duracao;
            Descricao = descricao;
        }

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Tema + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
			retorno += "Descrição: " + this.EnderecoWeb + Environment.NewLine;
            retorno += "Ano de Início: " + this.Duracao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    
        
    }
}