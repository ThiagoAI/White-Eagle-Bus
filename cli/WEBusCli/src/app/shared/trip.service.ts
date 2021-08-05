import { Injectable } from '@angular/core';
import { BusSeat } from './models/bus-seat.model';
import { Bus } from './models/bus.model';
import { TripLocation } from './models/trip-location.model';
import { Trip } from './models/trip.model';
import ConfigJson from '../../../app-config.json';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TripService {

  constructor(private http: HttpClient) { 
  }
  
  formData:Trip = new Trip
  formLocations:TripLocation[] = []
  formBusses:Bus[] = []

  getTripLocations() {
    this.http.get(ConfigJson.busTripLocationApi)
    .toPromise()
    .then(res => this.formLocations = res as TripLocation[]);
  }

  getBusses() {
    this.http.get(ConfigJson.busApi)
    .toPromise()
    .then(res => this.formBusses = res as Bus[])
  }

  postTrip() {
    return this.http.post(ConfigJson.busTripApi, this.formData)
  }

  // refreshList() {
  //   this.http.get(ConfigJson.busTripApi)
  //     .toPromise()
  //     .then(res =>this.list = res as PaymentDetail[]);
  // }
}
