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
export class BusService {

  constructor(private http: HttpClient) { 
  }

  formData:Bus = new Bus

  canSubmit() {
    return this.formData.name
  }

  postBus() {
    return this.http.post(ConfigJson.busApi, this.formData)
  }

  resetData() {
    this.formData = new Bus()
  }
}
