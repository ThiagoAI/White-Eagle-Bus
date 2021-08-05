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
export class TripBookingService {

  constructor(private http: HttpClient) { 
    this.getTrips()
  }

  formData:TripBooking = new TripBooking
  formTrips:Trip[] = []
  formSelectedTrip?:Trip = undefined
  formSeats:BusSeat[] = []
  formSelectedSeat?:BusSeat = undefined

  setTrip() {
    // Reset bus to clear seats if no bus is found by next step
    this.formSeats = []
    this.formSelectedSeat = undefined
    this.formData.busSeatID = -1
    
    // Get bus trip
    this.formSelectedTrip = this.formTrips.find(t => t.id == this.formData.busTripID)
    if (this.formSelectedTrip) {
      const bus =  this.formSelectedTrip.bus ?  this.formSelectedTrip.bus : new Bus()
      this.formSeats = bus.seats
      this.formData.busSeatID = this.formSeats[0].id ? this.formSeats[0].id : -1
      this.formSelectedSeat = this.formSeats[0]
    }
    console.log(this.formData)
  }

  setSeat() {
    this.formSelectedSeat = this.formSeats.find(s => s.id == this.formData.busSeatID)
  }

  getTrips() {
    this.http.get(ConfigJson.busTripApi)
    .toPromise()
    .then(res => this.formTrips = res as Trip[])
  }

  canSubmit() {
    return this.formSelectedSeat && this.formSelectedTrip
  }

  postBooking() {
    return this.http.post(ConfigJson.busReservationsApi, this.formData)
  }

  resetData() {
    this.formData = new TripBooking()
    this.formSeats = []
    this.formSelectedSeat = undefined
    this.formSelectedTrip = undefined
  }
}
