namespace modelo_core_angular.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Projeto(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public Projeto()
        {

        }

    }
}
