/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */

namespace Air.Interfaces
{
    // Definición de la interfaz IResponse.
    public interface IResponse
    {
        // Método asíncrono que devuelve una tarea que representa una colección dinámica de elementos.
        Task<dynamic> GetAllAsync();
    }
}
