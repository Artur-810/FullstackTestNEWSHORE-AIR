/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */

namespace Air.Models
{
    // Definición de la clase JourneyDto.
    public class JourneyDto
    {
        // Propiedad que representa el origen del viaje.
        public string origin { get; set; }

        // Propiedad que representa el destino del viaje.
        public string destination { get; set; }

        // Propiedad que representa el precio del viaje.
        public double price { get; set; }

        // Propiedad que representa una lista de vuelos en el viaje.
        public List<FlightDto> Flights { get; set; }
    }
}