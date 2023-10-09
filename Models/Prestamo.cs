
namespace EjercicioRepaso2;

public class Prestamo{
    private int id;
    private int idLibro;
    private int idUsuario;
    private DateTime fechaPrestamo;
    private DateTime fechaDevolucion;

    public Prestamo()
    {
        this.fechaPrestamo=new DateTime();
        this.fechaDevolucion = new DateTime();
    }

    public Prestamo(int id, int idLibro, int idUsuario, DateTime fechaPrestamo, DateTime fechaDevolucion)
    {
        this.id = id;
        this.idLibro = idLibro;
        this.idUsuario = idUsuario;
        this.fechaPrestamo = fechaPrestamo;
        this.fechaDevolucion = fechaDevolucion;
    }
    public bool CoincideUsuarioYLibro(int idL, int idU){
        return this.idLibro==idL && this.idUsuario==idU;
    }
    public bool ParticipaLibro(int idL){
        return this.idLibro==idL;
    }

    public int Id { get => id; set => id = value; }
    public int IdLibro { get => idLibro; set => idLibro = value; }
    public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    public DateTime FechaPrestamo { get => fechaPrestamo; set => fechaPrestamo = value; }
    public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
}