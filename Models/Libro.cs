namespace EjercicioRepaso2;
public enum Categoria
{
    Accion=1,
    CienciaFiccion=2,
    Aventura=3
}
public class Libro{
    private int id;
    private string titulo;
    private string autor;
    private Categoria categoria;
    private bool disponible;

    public Libro()
    {
    }

    public Libro(int id, string titulo, string autor, Categoria categoria)
    {
        this.id = id;
        this.titulo = titulo;
        this.autor = autor;
        this.categoria = categoria;
    }

    public Libro(int id, string titulo, string autor, Categoria categoria, bool disponible)
    {
        this.id = id;
        this.titulo = titulo;
        this.autor = autor;
        this.categoria = categoria;
        this.disponible = disponible;
    }

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Autor { get => autor; set => autor = value; }
    public Categoria Categoria { get => categoria; set => categoria = value; }
    public bool Disponible { get => disponible; set => disponible = value; }
}
