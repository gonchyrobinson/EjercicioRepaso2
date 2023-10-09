using Microsoft.AspNetCore.Mvc;

namespace EjercicioRepaso2.Controllers;

[ApiController]
[Route("[controller]")]
public class LibrosController : ControllerBase
{
    private ManejoLibros manejoLibros;
    private readonly ILogger<LibrosController> _logger;

    public LibrosController(ILogger<LibrosController> logger)
    {
        _logger = logger;
        AccesoADatos acceso = new AccesoADatos("./DatosJSON/libros.json", "./DatosJSON/usuarios.json", "./DatosJSON/prestamos.json");
        manejoLibros = new ManejoLibros(acceso);
    }
    [HttpPost("CrearLibro/libro={l}")]
    public ActionResult<Libro> AddLibro(Libro l){
        var libro = manejoLibros.CrearLibro(l);
        if (libro!=null)
        {
            return Ok(libro);
        }else
        {
            return BadRequest("Error al agregar libro");
        }
    }
    [HttpGet("ObtenerLibros")]
    public ActionResult<List<Libro>> ObtenerLibros(){
        return Ok(manejoLibros.ObtenerLibros());
    }
    [HttpGet("ObtenerLibroId={Id}")]
    public ActionResult<Libro> GetLibroId(int Id){
        var libro = manejoLibros.ObtenerLibroId(Id);
        if (libro!=null)
        {
            return Ok(libro);
        }else
        {
            return NotFound("Id inexistente");
        }
    }
    [HttpPut("ActualizarLibro/id={id}/libro={l}")]
    public ActionResult<Libro> ActualizarLibro(int id, Libro l){
        var actualizado = manejoLibros.ActualizarLibroExistente(l,id);
        if (actualizado!=null)
        {
            return Ok(actualizado);
        }else
        {
            return NotFound("Id no encontrado");
        }
    }
    [HttpDelete("BorrarLibro/id={id}")]
    public ActionResult BorrarLibro(int id){
        if (manejoLibros.EliminarLibro(id))
        {
            return Ok("Libro eliminado correctamente");
        }else
        {
            return NotFound("Libro no encontrado");
        }
    }
    [HttpPost("CrearUsuario/usuario={us}")]
    public ActionResult<Usuario> AddUsuario(Usuario us){
        var agregado = manejoLibros.CrearUsuario(us);
        if (agregado!=null)
        {
            return Ok(agregado);
        }else
        {
            return NotFound("Usuario no se pudo agregar");
        }
    }
    [HttpGet("ObtenerUsuarios")]
    public ActionResult<List<Usuario>> ObtenerUsuarios(){
        return Ok(manejoLibros.ObtenerUsuarios());
    }
    [HttpGet("ObtenerUsuarioId/id={id}")]
    public ActionResult ObtenerUsuarioId(int id){
        var usuario = manejoLibros.ObtenerUsuarioId(id);
        if (usuario!=null)
        {
            return Ok(usuario);
        }else
        {
            return NotFound("Usuario no encontrado");
        }
    }
    [HttpPut("ActualizarUsuario/id={id}/usuario={us}")]
    public ActionResult<Usuario> ActualizarUsuario(int id, Usuario us){
        var act = manejoLibros.ActualizarInformacionUsuario(id,us);
        if (act!=null)
        {
            return Ok(act);
        }else{
            return NotFound("No se encontro el id");
        }
    }
    [HttpDelete("EliminarUsuario/id={id}")]
    public ActionResult EliminarUsuario(int id){
        var eliminado = manejoLibros.EliminarUsuario(id);
        if (eliminado)
        {
            return Ok("Eliminacion exitosa");
        }else
        {
            return NotFound("No se encontro el usuario");
        }
    }
    [HttpPost("PrestarLibro/prestamo={p}")]
    public ActionResult<Prestamo> PrestarLibro(Prestamo p){
        var prestamo = manejoLibros.PrestarLibro(p);
        if (prestamo!=null)
        {
            return Ok(prestamo);
        }else
        {
            return BadRequest("Error al realizar prestamo");
        }
    }
    [HttpPut("DevolverLibro/idLibro={idL}/idUsuario={idU}")]
    public ActionResult<Prestamo> DevolverLibro(int idL, int idU){
        var prestamo = manejoLibros.DevolverLibro(idL,idU);
        if (prestamo!=null)
        {
            return Ok(prestamo);
        }else
        {
            return BadRequest("Error al devolver libro");
        }
    }
    [HttpGet("ListarPrestamos")]
    public ActionResult<List<Prestamo>> ListarPrestamos(){
        return Ok(manejoLibros.ListarPrestamos());
    }
    [HttpGet("ObtenerLibrosPrestados")]
    public ActionResult<List<Prestamo>> GetLibrosPrestados(){
        var librosPrestados = manejoLibros.ObtenerLibrosPrestados();
        if (librosPrestados.Count()>0)
        {
            return Ok(librosPrestados);
        }else
        {
            return NotFound("No se encontraron libros prestados");
        }
    }
   
[HttpGet("BuscarPorTitulo/titulo={t}")]
public ActionResult<List<Libro>> BuscarLibroPorTitulo(string t){
    var libros = manejoLibros.BuscarLibroPorTitulo(t);
    if (libros.Count()>0)
    {
        return Ok(libros);
    }else
    {
        return NotFound("No existen libros del titulo mencionado");
    }
}
[HttpGet("BuscarPorCategoria/cat={c}")]
public ActionResult<List<Libro>> BuscarLibroPorTitulo(Categoria c){
    var libros = manejoLibros.BuscarLibroPorGenero(c);
    if (libros.Count()>0)
    {
        return Ok(libros);
    }else
    {
        return NotFound("No existen libros de la categoria mencionada");
    }
}
[HttpGet("HistorialPrestamos/idUsuario={idU}")]
public ActionResult<List<Prestamo>> HistorialPrestamo(int idU){
    var prestamos = manejoLibros.HistorialPrestamo(idU);
    if (prestamos.Count()>0)
    {
        return Ok(prestamos);
    }else
    {
        return NotFound("No existen Prestamos del usuario "+idU);
    }
}
[HttpDelete("EliminarLibro/id={id}")]
public ActionResult EliminarLibro(int id){
    if (manejoLibros.EliminaLibroYPrestamosAsociados(id))
    {
        return Ok("Libro eliminado con exito");
    }else
    {
        return BadRequest("No se pudo eliminar el libro");
    }
}
[HttpPut("CargarInforme")]
public ActionResult<Informe> CargarInforme(){
    var inf = manejoLibros.CargarInforme();
    if (inf!=null)
    {
        return Ok(inf);
    }else
    {
        return BadRequest("No se realizaron prestamos");
    }
}

}