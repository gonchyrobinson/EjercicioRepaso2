namespace EjercicioRepaso2;

public class DatosLibro{
    private int idLibro;
    private int cantPrestamos;

    public DatosLibro(int idLibro, int cantPrestamos)
    {
        this.idLibro = idLibro;
        this.cantPrestamos = cantPrestamos;
    }

    public int IdLibro { get => idLibro; set => idLibro = value; }
    public int CantPrestamos { get => cantPrestamos; set => cantPrestamos = value; }
}