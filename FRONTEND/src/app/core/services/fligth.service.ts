import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Journey } from '../model/journey';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FligthService {

  //ULR que obtiene las rutas de los vuelos
  private baseURL = "servidor/FlightManagement/CalculateJourney";

  constructor(private httpClient : HttpClient) { }

  public getFlights(journey:Journey):Observable<Journey>{
    return this.httpClient.get<Journey>(`${this.baseURL}?origin=${journey.origin}&destination=${journey.destination}`);
  }
    
}
