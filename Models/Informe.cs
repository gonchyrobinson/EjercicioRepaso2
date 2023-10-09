namespace EjercicioRepaso2;

public class Informe{
    private int totalLibros;
    private int totalPrestados;
    private Categoria categoraMasPopular;
    private Libro libroMasPrestado;
    private Usuario UsuarioConMasPrestamos;
    private float promedioLibrosPrestadosPorUsuario;

    public Informe()
    {
    }

    public Informe(int totalLibros, int totalPrestados, Categoria categoraMasPopular)
    {
        this.totalLibros = totalLibros;
        this.totalPrestados = totalPrestados;
        this.categoraMasPopular = categoraMasPopular;
    }

    public Informe(int totalLibros, int totalPrestados, Categoria categoraMasPopular, Libro libroMasPrestado, Usuario usuarioConMasPrestamos, float promedioLibrosPrestadosPorUsuario)
    {
        this.totalLibros = totalLibros;
        this.totalPrestados = totalPrestados;
        this.categoraMasPopular = categoraMasPopular;
        this.libroMasPrestado = libroMasPrestado;
        UsuarioConMasPrestamos = usuarioConMasPrestamos;
        this.promedioLibrosPrestadosPorUsuario = promedioLibrosPrestadosPorUsuario;
    }

    public int TotalLibros { get => totalLibros; set => totalLibros = value; }
    public int TotalPrestados { get => totalPrestados; set => totalPrestados = value; }
    public Categoria CategoraMasPopular { get => categoraMasPopular; set => categoraMasPopular = value; }
    public Libro LibroMasPrestado { get => libroMasPrestado; set => libroMasPrestado = value; }
    public Usuario UsuarioConMasPrestamos1 { get => UsuarioConMasPrestamos; set => UsuarioConMasPrestamos = value; }
    public float PromedioLibrosPrestadosPorUsuario { get => promedioLibrosPrestadosPorUsuario; set => promedioLibrosPrestadosPorUsuario = value; }
}
