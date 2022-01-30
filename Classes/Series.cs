namespace cadastroSeries
{
    public class Series: EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo {get;set;}
        private string Descricao { get; set; }
        private int Ano { get; set; }

        private bool Ativo {get;set;}

        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Ativo = true;
            
        }

        public override string ToString(){
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descricao: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Ativo: " + this.Ativo + Environment.NewLine;

            return retorno;
        }

        public string getTitulo(){
            return this.Titulo;
        }


        public int getId(){
            return this.Id;
        }

        public bool getAtivo(){
            return this.Ativo;
        }

        public void Desabilita(){
            this.Ativo = false;
        }
}

}