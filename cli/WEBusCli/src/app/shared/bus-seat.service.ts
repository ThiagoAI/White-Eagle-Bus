import { Injectable } from '@angular/core';
import { BusSeat } from './models/bus-seat.model';
import { Bus } from './models/bus.model';
import { TripBooking } from './models/trip-booking.model';
import ConfigJson from '../../../app-config.json';
import { Trip } from './models/trip.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BusSeatService {

  constructor(private http: HttpClient) { 
    this.getBusses()
  }

  formData:BusSeat = new BusSeat
  formBusses:Bus[] = []

  getBusses() {
    this.http.get(ConfigJson.busApi)
    .toPromise()
    .then(res => this.formBusses = res as Bus[])
  }

  postSeat() {
    return this.http.post(ConfigJson.busSeatsApi, this.formData)
  }

  resetData() {
    this.formData = new BusSeat()
  }
}
