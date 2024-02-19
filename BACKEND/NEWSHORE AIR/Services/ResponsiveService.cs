using Air.Interfaces;
using Air.Models;

/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */

namespace Air.Services
{
    // Definición de la clase ResponseService que implementa la interfaz IResponse.
    public class ResponseService : IResponse
    {
        private readonly IConfiguration _configuration; // Campo que almacena la configuración de la aplicación.

        // Constructor de la clase ResponseService que recibe una instancia de IConfiguration mediante inyección de dependencias.
        public ResponseService(IConfiguration configuration)
        {
            _configuration = configuration; // Asigna la configuración proporcionada al campo _configuration.
        }

        // Método que obtiene todos los datos de forma asíncrona.
        public async Task<dynamic> GetAllAsync()
        {
            try

            {
                // Obtiene la URL de la configuración.
                string page = _configuration["url"];

                // Crea una nueva instancia de HttpClient.
                using (HttpClient client = new HttpClient())
                {
                    // Agrega un encabezado User-Agent al cliente HttpClient.
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Fiddler");

                    // Realiza una solicitud GET a la URL especificada.
                    using (HttpResponseMessage response = await client.GetAsync(page))
                    using (HttpContent content = response.Content)
                    {
                        // Lee el contenido de la respuesta como una cadena.
                        string result = await content.ReadAsStringAsync();

                        // Devuelve el resultado.
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                throw;
            }
        }
    }
}
