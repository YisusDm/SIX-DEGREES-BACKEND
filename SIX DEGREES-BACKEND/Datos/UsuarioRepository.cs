using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SIX_DEGREES_BACKEND.Models;
using Microsoft.Data.SqlClient;

namespace SIX_DEGREES_BACKEND.Datos
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("cadenaSQL");
        }

        // Obtener todos los usuarios
        public async Task<IEnumerable<Usuario>> ObtenerUsuariosAsync()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_GetUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        usuarios.Add(new Usuario
                        {
                            UsuId = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                        });
                    }
                }
            }

            return usuarios;
        }

        // Crear
        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_AddUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);

                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }

        // Editar
        public async Task EditarUsuarioAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_AlterUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", usuario.UsuId);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);

                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }

        // Borrar
        public async Task BorrarUsuarioAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_DeleteUsuario", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
        }

        // Obtener Usuario por ID
        public async Task<Usuario> ObtenerUsuarioIdAsync(int id)
        {
            Usuario usuario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SP_GetUsuarioId", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        usuario = new Usuario
                        {
                            UsuId = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                        };
                    }
                }
            }

            return usuario;
        }


    }
}
