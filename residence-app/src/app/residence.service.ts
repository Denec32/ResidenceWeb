import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Resident } from './models/resident';
import { Territory } from './models/territory';
import { EmptyHouse } from './models/empty-house';
import { House } from './models/house';

@Injectable({
  providedIn: 'root'
})
export class ResidenceService {

  private serviceUrl = 'https://localhost:7069/api/';

  constructor(
    private http: HttpClient) { }

  getResidents() : Observable<Resident[]> {
    return this.http.get<Resident[]>(this.serviceUrl + 'residents');
  }

  getTerritorialInfo(address: string | null) : Observable<Territory[]> {
    return this.http.get<Territory[]>(this.serviceUrl + 'territories/' + address);
  }

  getHouses() : Observable<House[]> {
    return this.http.get<House[]>(this.serviceUrl + 'houses');
  } 

  getEmptyHouses() : Observable<EmptyHouse[]> {
    return this.http.get<EmptyHouse[]>(this.serviceUrl + 'emptyhouses');
  } 
}
