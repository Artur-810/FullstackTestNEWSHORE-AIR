using System.Net; // Importa el espacio de nombres necesario para utilizar HttpStatusCode.

/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */


namespace Air.Models
{
    // Definición de la clase HttpMessage<T>.
    public class HttpMessage<T>
    {
        // Propiedad que representa el código de estado HTTP de la respuesta.
        public HttpStatusCode StatusCode { get; set; }

        // Propiedad que indica si la solicitud se completó con éxito.
        public bool IsSuccess { get; set; } = true;

        // Propiedad que contiene los datos de la respuesta, parámetro de tipo genérico permite que las clases, métodos y estructuras sean más flexibles.
        public T Data { get; set; }
    }
}