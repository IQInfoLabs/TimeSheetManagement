import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { IGeoLocations } from './igeo-locations';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {

  private _url: string = "http://localhost:11890/api/values/GeoLocations";

  constructor(private http:HttpClient) { }

  getGeoLocations(): Observable<IGeoLocations[]>{
    return this.http.get<IGeoLocations[]>(this._url)
  }
}
