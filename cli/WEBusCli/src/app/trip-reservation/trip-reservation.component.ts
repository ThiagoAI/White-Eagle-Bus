import { Component, OnInit } from '@angular/core';
import { Trip } from '../shared/models/trip.model';
import { TripBookingService } from '../shared/trip-reservation.service';

@Component({
  selector: 'app-trip-reservation',
  templateUrl: './trip-reservation.component.html'
})
export class TripBookingComponent implements OnInit {

  constructor(public service: TripBookingService) { }

  ngOnInit(): void {
  }

  formVisible(): boolean {
    return this.service.formData.busTripID < 0
  }

  showForm(trip:Trip) {
    this.service.formData.busTripID = trip.id ? trip.id : -1
    this.service.setTrip()
  }

}
