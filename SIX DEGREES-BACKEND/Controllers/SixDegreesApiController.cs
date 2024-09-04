using Microsoft.AspNetCore.Mvc;
using SIX_DEGREES_BACKEND.Datos;
using SIX_DEGREES_BACKEND.Models;

namespace SIX_DEGREES_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SixDegreesApiController: ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        // Inyección de dependencias del repositorio
        public SixDegreesApiController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Método GET para obtener la lista de usuario
        [HttpGet("ObtenerUsuarios")]
        public async Task<IActionResult> GetUsuario()
        {
            var usuarios = await _usuarioRepository.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }

        // Método GET para usuario por ID
        [HttpGet("ObtenerUsuariosId")]
        public async Task<IActionResult> GetUsuarioId(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // Método POST para crear un nuevo usuario
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _usuarioRepository.CrearUsuarioAsync(usuario);
            return Ok(usuario);
        }

        // Método PUT para actualizar un usuario
        [HttpPut("ModificarUsuario")]
        public async Task<IActionResult> EditarUsuario(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.UsuId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _usuarioRepository.EditarUsuarioAsync(usuario);
            return NoContent();
        }

        // Método DELETE para borrar un Usuario
        [HttpDelete("EliminarUsuario")]
        public async Task<IActionResult> BorrarUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObtenerUsuarioIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioRepository.BorrarUsuarioAsync(id);
            return NoContent();
        }
    }
}
