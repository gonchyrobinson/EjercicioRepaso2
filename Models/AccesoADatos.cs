namespace EjercicioRepaso2;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


public class AccesoADatos
{
    private string ruta;
    private string ruta2;
    private string ruta3;
    public AccesoADatos(string ruta, string ruta2, string ruta3)
    {
        this.ruta = ruta;
        this.ruta2 = ruta2;
        this.ruta3 = ruta3;
    }
    public List<Libro> ObtenerLibros()
    {
        List<Libro> libros = new List<Libro>();
        if (File.Exists(ruta))
        {
            string TextoJson = File.ReadAllText(ruta);
            libros = JsonSerializer.Deserialize<List<Libro>>(TextoJson);
        }
        return libros;
    }
    public void GuardarLibros(List<Libro> libros)
    {
        string formatoJson = JsonSerializer.Serialize(libros);
        File.WriteAllText(this.ruta, formatoJson);
    }
    public List<Usuario> ObtenerUsuarios()
    {
        List<Usuario> duenios = new List<Usuario>();
        if (File.Exists(ruta2))
        {
            string TextoJson = File.ReadAllText(ruta2);
            duenios = JsonSerializer.Deserialize<List<Usuario>>(TextoJson);
        }
        return duenios;
    }
    public void GuardarUsuarios(List<Usuario> duenios)
    {
        string formatoJson = JsonSerializer.Serialize(duenios);
        File.WriteAllText(this.ruta2, formatoJson);
    }
    public List<Prestamo> ObtenerPrestamos()
    {
        List<Prestamo> prestamos = new List<Prestamo>();
        if (File.Exists(ruta3))
        {
            string TextoJson = File.ReadAllText(ruta3);
            prestamos = JsonSerializer.Deserialize<List<Prestamo>>(TextoJson);
        }
        return prestamos;
    }
    public void GuardarPrestamos(List<Prestamo> prestamos)
    {
        string formatoJson = JsonSerializer.Serialize(prestamos);
        File.WriteAllText(this.ruta3, formatoJson);
    }
}
