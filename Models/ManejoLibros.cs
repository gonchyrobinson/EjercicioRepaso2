
namespace EjercicioRepaso2;

public class ManejoLibros
{
    private AccesoADatos acceso;

    public ManejoLibros(AccesoADatos acceso)
    {
        this.acceso = acceso;
    }

    public AccesoADatos Acceso { get => acceso; set => acceso = value; }
    public Libro? CrearLibro(Libro l)
    {
        List<Libro> libros = acceso.ObtenerLibros();
        libros.Add(l);
        l.Id = libros.Max(l => l.Id) + 1;
        if (EncuentraLibro(libros, l))
        {
            acceso.GuardarLibros(libros);
            return l;
        }
        else
        {
            return null;
        }
    }
    public List<Libro> ObtenerLibros()
    {
        return acceso.ObtenerLibros();
    }
    public Libro? ObtenerLibroId(int id)
    {
        var libros = acceso.ObtenerLibros();
        return libros.FirstOrDefault(l => l.Id == id, null);
    }
    public Libro? ActualizarLibroExistente(Libro l, int id)
    {
        var libros = acceso.ObtenerLibros();
        var actualizar = libros.FirstOrDefault(lib => lib.Id == id, null);
        if (actualizar != null)
        {
            actualizar.Autor = l.Autor;
            actualizar.Categoria = l.Categoria;
            actualizar.Titulo = l.Titulo;
            actualizar.Disponible = l.Disponible;
            acceso.GuardarLibros(libros);
            return actualizar;
        }
        else
        {
            return null;
        }
    }
    public bool EliminarLibro(int id)
    {
        var libros = acceso.ObtenerLibros();
        var eliminar = libros.FirstOrDefault(lib => lib.Id == id, null);
        bool elimina = libros.Remove(eliminar);
        acceso.GuardarLibros(libros);
        return elimina;
    }
    private bool EncuentraLibro(List<Libro> libros, Libro l)
    {
        return libros.FirstOrDefault(lib => lib == l, null) != null;
    }


    //Usuarios
    public Usuario? CrearUsuario(Usuario us)
    {
        var usuarios = acceso.ObtenerUsuarios();
        usuarios.Add(us);
        us.Id = usuarios.Max(u => u.Id) + 1;
        if (EncuentraUs(usuarios, us))
        {
            acceso.GuardarUsuarios(usuarios);

            return us;
        }
        else
        {
            return null;
        }
    }
    public List<Usuario> ObtenerUsuarios()
    {
        return acceso.ObtenerUsuarios();
    }
    public Usuario? ObtenerUsuarioId(int id)
    {
        var usuarios = acceso.ObtenerUsuarios();
        return usuarios.FirstOrDefault(us => us.Id == id, null);
    }
    public Usuario? ActualizarInformacionUsuario(int id, Usuario us)
    {
        var usuarios = acceso.ObtenerUsuarios();
        var buscado = usuarios.FirstOrDefault(u => u.Id == id, null);
        if (buscado != null)
        {
            buscado.Nombre = us.Nombre;
            buscado.LibrosPrestados = us.LibrosPrestados;
            acceso.GuardarUsuarios(usuarios);
        }
        return buscado;
    }
    public bool EliminarUsuario(int id)
    {
        var usuarios = acceso.ObtenerUsuarios();
        var buscado = usuarios.FirstOrDefault(u => u.Id == id, null);
        if (buscado != null)
        {
            bool retorna = usuarios.Remove(buscado);
            acceso.GuardarUsuarios(usuarios);
            return retorna;
        }
        else
        {
            return false;
        }
    }
    public Prestamo? PrestarLibro(Prestamo p)
    {
        var libros = acceso.ObtenerLibros();
        var usuarios = acceso.ObtenerUsuarios();
        var prestamos = acceso.ObtenerPrestamos();
        var usuarioPrestado = usuarios.FirstOrDefault(u => u.Id == p.IdUsuario, null);
        var libroPrestado = libros.FirstOrDefault(l => l.Id == p.IdLibro, null);
        if (usuarioPrestado != null && libroPrestado != null && libroPrestado.Disponible)
        {
            prestamos.Add(p);
            p.Id = prestamos.Max(p => p.Id) + 1;
            p.FechaPrestamo = DateTime.Now;
            libroPrestado.Disponible = false;
            usuarioPrestado.AgregarLibro(libroPrestado.Id);
            acceso.GuardarLibros(libros);
            acceso.GuardarUsuarios(usuarios);
            acceso.GuardarPrestamos(prestamos);
            return p;
        }
        else
        {
            return null;
        }
    }
    public Prestamo? DevolverLibro(int idLibro, int idUsuario)
    {
        var libros = acceso.ObtenerLibros();
        var usuarios = acceso.ObtenerUsuarios();
        var prestamos = acceso.ObtenerPrestamos();
        var prestamoBuscado = prestamos.FirstOrDefault(p => p.CoincideUsuarioYLibro(idLibro, idUsuario), null);
        var libroBuscado = libros.FirstOrDefault(l => l.Id == idLibro, null);
        var usuarioBuscado = usuarios.FirstOrDefault(u => u.Id == idUsuario, null);
        if (prestamoBuscado != null && libroBuscado != null && usuarioBuscado != null)
        {
            prestamoBuscado.FechaDevolucion = DateTime.Now;
            libroBuscado.Disponible = true;
            usuarioBuscado.EliminarLibro(idLibro);
            acceso.GuardarLibros(libros);
            acceso.GuardarPrestamos(prestamos);
            acceso.GuardarUsuarios(usuarios);
            return prestamoBuscado;
        }
        else
        {
            return null;
        }
    }
    public List<Prestamo> ListarPrestamos()
    {
        return acceso.ObtenerPrestamos();
    }
    public List<Libro> ObtenerLibrosPrestados()
    {
        return acceso.ObtenerLibros().FindAll(p => !p.Disponible);
    }
    public List<Libro> BuscarLibroPorTitulo(string titulo)
    {
        return acceso.ObtenerLibros().FindAll(l => l.Titulo == titulo);
    }
    public List<Libro> BuscarLibroPorGenero(Categoria cat)
    {
        return acceso.ObtenerLibros().FindAll(l => l.Categoria == cat);
    }

    private bool EncuentraUs(List<Usuario> usuarios, Usuario us)
    {
        return usuarios.FirstOrDefault(u => u == us, null) != null;
    }
    public List<Prestamo> HistorialPrestamo(int idU)
    {
        return acceso.ObtenerPrestamos().FindAll(p => p.IdUsuario == idU);
    }
    public bool EliminaLibroYPrestamosAsociados(int idL)
    {
        var libros = acceso.ObtenerLibros();
        var usuarios = acceso.ObtenerUsuarios();
        var buscado = libros.FirstOrDefault(l => l.Id == idL, null);
        var prestamos = acceso.ObtenerPrestamos();
        foreach (var prestamo in prestamos)
        {
            if (prestamo.ParticipaLibro(idL))
            {
                prestamo.FechaDevolucion = DateTime.Now;
            }
        }
        acceso.GuardarPrestamos(prestamos);
        if (buscado != null)
        {
            foreach (var us in usuarios)
            {
                if (us.ExisteLibro(idL))
                {
                    us.EliminarLibro(idL);
                }
            }
            EliminarLibro(idL);
            acceso.GuardarUsuarios(usuarios);
            return true;
        }
        else
        {
            return false;
        }
    }
    public Informe? CargarInforme()
    {
        var libros = acceso.ObtenerLibros();
        var prstamos = acceso.ObtenerPrestamos();
        var usuarios = acceso.ObtenerUsuarios();
        if (libros != null && prstamos != null)
        {
            int cantLibros = libros.Count();
            int cantPrestados = this.LibrosPrestados(libros).Count();
            Categoria catMasPopular = CatMasPopular(libros);
            int idlibroMasPrestado = LibroMasPrestado(libros, prstamos);
            int idusuarioConMasPrestamos = UsuarioConMasPrestamos(prstamos,usuarios);
            float promedioLibrosPrestadosPorUsuario = PromedioPrestamosUsuarios(prstamos,usuarios);
            var usuarioConMasPrestamos =EncuentraUsuario(usuarios,idusuarioConMasPrestamos);
            var libroConMasPrestamos =EncuentraLibroId(libros, idlibroMasPrestado);
            return new Informe(cantLibros, cantPrestados, catMasPopular,libroConMasPrestamos,usuarioConMasPrestamos,promedioLibrosPrestadosPorUsuario);
        }
        else
        {
            return null;
        }
    }
    private Libro EncuentraLibroId(List<Libro> libros, int id){
        return libros.FirstOrDefault(l => l.Id==id, new Libro());
    }
    private Usuario EncuentraUsuario(List<Usuario> usuarios, int id){
        var us = usuarios.FirstOrDefault(u => u.Id==id);
        if (us!=null)
        {
            return us;
        }else
        {
            return new Usuario();
        }
    }
    private List<Libro> LibrosPrestados(List<Libro> libros)
    {
        return libros.FindAll(l => !l.Disponible);
    }
    private List<Libro> LibrosCat(Categoria c, List<Libro> libros)
    {
        return libros.FindAll(l => l.Categoria == c);
    }
    private Categoria CatMasPopular(List<Libro> libros)
    {
        int cantAccion = LibrosCat(Categoria.Accion, libros).Count();
        int cantAventura = LibrosCat(Categoria.Aventura, libros).Count();
        int cantCienciaFiccion = LibrosCat(Categoria.CienciaFiccion, LibrosPrestados(libros)).Count();
        Dictionary<Categoria, int> valores = new Dictionary<Categoria, int>();
        valores.Add(Categoria.Accion, cantAccion);
        valores.Add(Categoria.Aventura, cantAventura);
        valores.Add(Categoria.CienciaFiccion, cantCienciaFiccion);
        var maximo = valores.MaxBy(v => v.Value);
        return maximo.Key;
    }
    private List<DatosLibro> CargaDatosLibro(List<Libro> libros, List<Prestamo> prestamos)
    {
        var datosLibros = new List<DatosLibro>();
        foreach (var l in libros)
        {
            var datosLibro = new DatosLibro(l.Id, CantidadPrestamos(prestamos, l.Id));
            datosLibros.Add(datosLibro);
        }
        return datosLibros;
    }
    private int CantidadPrestamos(List<Prestamo> prestamos, int idLibro)
    {
        return prestamos.Count(p => p.IdLibro == idLibro);
    }
    private int LibroMasPrestado(List<Libro> libros, List<Prestamo> prestamos)
    {
        var datosLibros = CargaDatosLibro(libros, prestamos);
        var masPrestado = datosLibros.MaxBy(l => l.CantPrestamos);
        if (masPrestado != null)
        {
            return masPrestado.IdLibro;
        }else
        {
            return 0;
        }
    }
    private List<DatosUsuario> CargaDatosUsuario(List<Usuario> usuarios, List<Prestamo> prestamos)
    {
        var datosUsuarios = new List<DatosUsuario>();
        foreach (var us in usuarios)
        {
            var datosUs = new DatosUsuario(us.Id, CantidadPrestamosUsuarios(prestamos, us.Id));
            datosUsuarios.Add(datosUs);
        }
        return datosUsuarios;
    }
    private int CantidadPrestamosUsuarios(List<Prestamo> prestamos, int idU)
    {
        return prestamos.Count(p => p.IdUsuario == idU);
    }
    private int UsuarioConMasPrestamos(List<Prestamo> prestamos, List<Usuario> usuarios){
        var datosUsuarios = CargaDatosUsuario(usuarios,prestamos);
        var usuarioMasConMasPrestamos = datosUsuarios.MaxBy(us => us.CantPrestamos);
        if (usuarioMasConMasPrestamos!=null)
        {
            return usuarioMasConMasPrestamos.IdUsuario;
        }else
        {
            return 0;
        }
    }
    private float PromedioPrestamosUsuarios(List<Prestamo> prestamos, List<Usuario> usuarios){
        var datosUsuarios = CargaDatosUsuario(usuarios,prestamos);
        var promedio =(float)datosUsuarios.Sum(d => d.CantPrestamos)/(float)datosUsuarios.Count();
        return promedio;
    }
}
