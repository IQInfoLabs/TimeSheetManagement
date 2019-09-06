import { Component } from '@angular/core';
import { ApiserviceService } from './apiservice.service';
import { IGeoLocations } from './igeo-locations';

export interface Tile {
  color: string;
  cols: number;
  rows: number;
  text: string;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private _api:ApiserviceService){

  }

  public geoLocationData : IGeoLocations[];
  public geoData =[];
  

  ngOnInit() {
    this._api.getGeoLocations()
      .subscribe((data) => {this.geoLocationData = data;
        console.log(JSON.stringify(this.geoLocationData));
        console.log(this.geoLocationData)});   
  }

  

  title = 'TMSUserInterface';

  checked = false;
  indeterminate = false;
  labelPosition = 'after';
  disabled = false;

  tiles: Tile[] = [
    {text: 'One', cols: 3, rows: 1, color: 'lightblue'},
    {text: 'Two', cols: 1, rows: 2, color: 'lightgreen'},
    {text: 'Three', cols: 1, rows: 1, color: 'lightpink'},
    {text: 'Four', cols: 3, rows: 1, color: '#DDBDF1'},
  ];

}
