namespace EjercicioRepaso2;

public class Usuario{
    private int id;
    private string nombre;
    private List<int> librosPrestados;

    public Usuario()
    {
        this.librosPrestados=new List<int>();
    }

    public Usuario(int id, string nombre, List<int> librosPrestados)
    {
        this.id = id;
        this.nombre = nombre;
        this.librosPrestados = librosPrestados;
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public List<int> LibrosPrestados { get => librosPrestados; set => librosPrestados = value; }
    public void AgregarLibro(int idlibro){
        if (librosPrestados!=null)
        {
            librosPrestados.Add(idlibro);
        }
    }
    public void EliminarLibro(int idLibro){
        if (this.librosPrestados!=null)
        {
            this.librosPrestados.Remove(idLibro);
        }
    }
    public bool ExisteLibro(int idL){
        return this.librosPrestados.Count(l => l==idL)!=0;
    }
}
