using Air.Models; // Importa el espacio de nombres que contiene el modelo JourneyDto.

/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */

namespace Air.Interfaces
{
    // Definición de la interfaz IFlightManagement.
    public interface IFlightManagement
    {
        // Método para calcular un viaje. Toma un origen y un destino como parámetros y devuelve un objeto JourneyDto.
        JourneyDto CalculateJourney(string origin, string destination);
    }
}