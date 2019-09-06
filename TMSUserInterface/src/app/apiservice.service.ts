import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { IGeoLocations } from './igeo-locations';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {

  constructor(private http:HttpClient) { }

   public _url="/assets/data/data.json";
  // public _url="http://localhost:11890/api/values/GeoLocations";
  
  getGeoLocations():Observable<IGeoLocations[]>{
      // return [{'EmployeeId':1, 'EmployeeName':'Praveen'}
      // ,{'EmployeeId':2, 'EmployeeName':'Arshitha'},{'EmployeeId':3, 'EmployeeName':'Naveen'}];
      return this.http.get<IGeoLocations[]>(this._url);
    }

}
