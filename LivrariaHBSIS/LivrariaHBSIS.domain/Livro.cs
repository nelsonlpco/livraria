namespace LivrariaHBSIS.domain
{
    public class Livro
    {
        public virtual long Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual Genero GeneroLivro { get; set; }
        public virtual Autor AutorPrincipal { get; set; }
        public virtual Editora EditoraPublicacao { get; set; }
        public virtual int AnoPublicacao { get; set; }
        public virtual string Isbn { get; set; }
    }
}
