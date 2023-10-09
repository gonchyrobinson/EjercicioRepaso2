
namespace EjercicioRepaso2;

public class DatosUsuario{
    private int idUsuario;
    private int cantPrestamos;

    public DatosUsuario(int idUsuario, int cantPrestamos)
    {
        this.idUsuario = idUsuario;
        this.cantPrestamos = cantPrestamos;
    }

    public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    public int CantPrestamos { get => cantPrestamos; set => cantPrestamos = value; }
}
