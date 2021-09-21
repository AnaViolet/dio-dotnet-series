using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        public int Ano { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            //Gets the newline string defined for this environment. https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1 
            retorno += "\nGênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            //retorno += "Excluido: " + this.Excluido;
            retorno += (this.Excluido ? "[EXCLUÍDO]" : "");
            return retorno;
        }

        public string retornarTitulo()
        {
            return this.Titulo;
        }

        public int retornarId()
        {
            return this.Id;
        }

        public bool retornarExcluido()
        {
            return this.Excluido;
        }

        public void excluir()
        {
            this.Excluido = true;
        }
    }
}