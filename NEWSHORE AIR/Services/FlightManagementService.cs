using Air.Controllers;
using Air.Interfaces;
using Air.Models;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

/**
 * @author Juan-Arturo
 * @since 16/02/2024
 * 
 */


namespace Air.Services
{
    /// Clase que gestiona operaciones relacionadas con vuelos, incluida la búsqueda de la ruta más económica entre dos ciudades.
    public class FlightManagementService : IFlightManagement
    {
        private IResponse _response;
        /// Inicializa una nueva instancia de la clase FlightManagementService.
        /// <param name="Response">Implementación de la interfaz IResponse para la recuperación de datos.</param>
        public FlightManagementService(IResponse Response)
        {
            this._response = Response;
        }

        /// Calcula el viaje más económico entre dos ciudades.
        /// <param name="origin">Ciudad de origen.</param>
        /// <param name="destination">Ciudad de destino.</param>
        /// <returns>Objeto JourneyDto que representa el viaje más económico, o null si no se encuentra un viaje válido.</returns>
        public JourneyDto CalculateJourney(string origin, string destination)
        {
            try
            {
                // Intenta obtener todos los datos necesarios para calcular el viaje.
                var responseList = GetAll();

                // Busca la ruta más económica entre el origen y el destino.
                var route = FindCheapestRoute(origin, destination, responseList);

                // Si se encontró una ruta válida, construye y devuelve el viaje.
                if (route != null)
                {
                    return BuildJourney(route, origin, destination);
                }

                // Si no se encontró una ruta válida, devuelve null.
                return null;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra durante el proceso.
                // Por ejemplo,  registrar el error o lanzar una excepción.
                Console.WriteLine($"Error al calcular el viaje: {ex.Message}");

                // Devuelve null como indicación de que no se pudo calcular el viaje.
                return null;
            }
        }







        /// Recupera todas las rutas de vuelo disponibles.
        /// <returns>Lista de objetos ResponseDto que representan información de vuelo.</returns>
        private List<ResponseDto> GetAll()
        {
            try
            {
                // Intenta obtener los datos de la fuente externa de forma asíncrona.
                var data = _response.GetAllAsync().Result;

                // Deserializa los datos obtenidos en una lista de objetos ResponseDto.
                List<ResponseDto> responseList = JsonConvert.DeserializeObject<List<ResponseDto>>(data);

                // Devuelve la lista de ResponseDto.
                return responseList;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra durante el proceso.
                // Por ejemplo, el error o lanzar una excepción.
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");

                // Lanza la excepción nuevamente para que sea manejada por el código que llama a este método.
                throw;
            }
        }

        /// Encuentra la ruta de vuelo más económica utilizando el algoritmo de Dijkstra.
        /// <param name="origin">Ciudad de origen.</param>
        /// <param name="destination">Ciudad de destino.</param>
        /// <param name="routes">Lista de objetos ResponseDto que representan rutas de vuelo.</param>
        /// <returns>Lista de objetos ResponseDto que representan la ruta más económica, o null si no se encuentra una ruta válida.</returns>
        private List<ResponseDto> FindCheapestRoute(string origin, string destination, List<ResponseDto> routes)
        {
            try
            {
                // Diccionario para rastrear el costo acumulado hasta cada ciudad.
                Dictionary<string, double> costSoFar = new Dictionary<string, double>();
                costSoFar[origin] = 0;

                // Diccionario para rastrear la ruta actual hasta cada ciudad.
                Dictionary<string, List<ResponseDto>> currentRoute = new Dictionary<string, List<ResponseDto>>();
                currentRoute[origin] = new List<ResponseDto>();

                // Cola de prioridad para explorar las ciudades por su costo acumulado.
                SortedSet<Tuple<double, string>> priorityQueue = new SortedSet<Tuple<double, string>>();
                priorityQueue.Add(new Tuple<double, string>(0, origin));

                // Bucle principal del algoritmo de Dijkstra.
                while (priorityQueue.Count > 0)
                {
                    var (currentCost, currentCity) = priorityQueue.First();
                    priorityQueue.Remove(priorityQueue.First());

                    // Si la ciudad actual es el destino, se encontró la ruta más económica.
                    if (currentCity == destination)
                    {
                        return currentRoute[destination];
                    }

                    // Busca las rutas posibles desde la ciudad actual.
                    var possibleRoutes = routes.Where(r => r.departureStation == currentCity);

                    foreach (var route in possibleRoutes)
                    {
                        string nextCity = route.arrivalStation;
                        double newCost = costSoFar[currentCity] + route.price;

                        // Si es la primera vez que se visita la ciudad o se encuentra un camino más económico, actualiza la información.
                        if (!costSoFar.ContainsKey(nextCity) || newCost < costSoFar[nextCity])
                        {
                            costSoFar[nextCity] = newCost;
                            currentRoute[nextCity] = new List<ResponseDto>(currentRoute[currentCity]);
                            currentRoute[nextCity].Add(route);
                            priorityQueue.Add(new Tuple<double, string>(newCost, nextCity));
                        }
                    }
                }

                // Si no se encuentra una ruta válida, devuelve null.
                return null;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que ocurra durante el proceso.
                Console.WriteLine($"Error al encontrar la ruta más económica: {ex.Message}");
                return null;
            }
        }
        /// Construye un objeto JourneyDto que representa el viaje basado en una lista de rutas de vuelo.
        /// <param name="routes">Lista de objetos ResponseDto que representan rutas de vuelo.</param>
        /// <param name="origin">Ciudad de origen.</param>
        /// <param name="destination">Ciudad de destino.</param>
        /// <returns>Objeto JourneyDto que representa el viaje con detalles como origen, destino, precio y vuelos individuales.</returns>
        private JourneyDto BuildJourney(List<ResponseDto> routes, string origin, string destination)
        {
            // Construye el objeto JourneyDto con la información proporcionada.
            var journey = new JourneyDto
            {
                origin = origin,
                destination = destination,
                price = routes.Sum(route => route.price),
                Flights = routes.Select(route => new FlightDto
                {
                    origin = route.departureStation,
                    destination = route.arrivalStation,
                    price = route.price,
                    transport = new TransportDto
                    {
                        flightCarrier = route.flightCarrier,
                        flightNumber = route.flightNumber
                    }
                }).ToList()
            };

            return journey;
        }
    }
}