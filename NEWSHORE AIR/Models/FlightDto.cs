/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */

namespace Air.Models
{
    // Definición de la clase FlightDto.
    public class FlightDto
    {
        // Propiedad que representa el origen del vuelo.
        public String origin { get; set; }

        // Propiedad que representa el destino del vuelo.
        public String destination { get; set; }

        // Propiedad que representa el precio del vuelo.
        public double price { get; set; }

        // Propiedad que representa la información del transporte del vuelo.
        public TransportDto transport { get; set; }
    }
}