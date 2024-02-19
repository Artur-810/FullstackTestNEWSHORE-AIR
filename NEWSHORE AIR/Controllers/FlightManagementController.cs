using Air.Interfaces; // Espacio de nombres que contiene las interfaces relacionadas con el manejo de vuelos.
using Air.Models; // Espacio de nombres que contiene los modelos de datos relacionados con los vuelos.
using Microsoft.AspNetCore.Authorization; // Espacio de nombres que proporciona funcionalidades relacionadas con la autorización en ASP.NET Core.
using Microsoft.AspNetCore.Mvc; // Espacio de nombres que contiene clases y métodos para crear aplicaciones web basadas en el modelo de controlador de MVC (Modelo-Vista-Controlador).
using System.Net; // Espacio de nombres que contiene tipos que proporcionan compatibilidad con la red, como HttpStatusCode.

/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */

namespace Air.Controllers
{
    [ApiController] // Atributo que indica que esta clase es un controlador de API.
    [AllowAnonymous] // Atributo que permite el acceso anónimo a los métodos del controlador.
    [Route("FlightManagement/[action]")] // Atributo que establece la ruta base para las acciones de este controlador.
    public class FlightManagementController : ControllerBase // Clase que actúa como controlador de gestión de vuelos.
    {
        private IFlightManagement _flightmanagement; // Campo para almacenar una instancia de IFlightManagement.


        public FlightManagementController(IFlightManagement FlightManagement)
        {
            this._flightmanagement = FlightManagement;
        }

        // Método para calcular el viaje.
        // Método para calcular el viaje.
        [HttpGet] // Indica que este método responde a las solicitudes HTTP GET.
        public HttpMessage<JourneyDto> CalculateJourney(string origin, string destination)
        {
            // Llama al método CalculateJourney del servicio de gestión de vuelos.
            var data = _flightmanagement.CalculateJourney(origin, destination);

            // Crea un objeto HttpMessage<JourneyDto> para enviar una respuesta HTTP.
            return new HttpMessage<JourneyDto>
            {
                StatusCode = (data != null) ? HttpStatusCode.OK : HttpStatusCode.NoContent, // Establece el estado de la respuesta HTTP.
                IsSuccess = true, // Indica si la solicitud se completó con éxito.
                Data = data // Asigna los datos del viaje al objeto HttpMessage<JourneyDto>.
            };
        }
    }
}