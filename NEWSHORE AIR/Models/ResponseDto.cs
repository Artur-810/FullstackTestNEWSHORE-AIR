/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */
namespace Air.Models
{
    // Definición de la clase ResponseDto.
    public class ResponseDto
    {
        // Propiedad que representa la estación de salida.
        public string departureStation { get; set; }

        // Propiedad que representa la estación de llegada.
        public string arrivalStation { get; set; }

        // Propiedad que representa el transportista de vuelo.
        public string flightCarrier { get; set; }

        // Propiedad que representa el número de vuelo.
        public string flightNumber { get; set; }

        // Propiedad que representa el precio del vuelo.
        public double price { get; set; }

        // Método que crea una copia del objeto ResponseDto. útil para crear copias independientes de un objeto DTO sin modificar el original.
        public ResponseDto copy()
        {
            // Crea y devuelve una nueva instancia de ResponseDto con las mismas propiedades.
            return new ResponseDto
            {
                departureStation = this.departureStation,
                arrivalStation = this.arrivalStation,
                flightCarrier = this.flightCarrier,
                flightNumber = this.flightNumber,
                price = this.price
            };
        }
    }
}