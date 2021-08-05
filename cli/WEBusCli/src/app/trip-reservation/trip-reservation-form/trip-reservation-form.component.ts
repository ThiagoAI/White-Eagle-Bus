import { formatCurrency } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Bus } from 'src/app/shared/models/bus.model';
import { TripBooking } from 'src/app/shared/models/trip-booking.model';
import { Trip } from 'src/app/shared/models/trip.model';
import { TripBookingService } from 'src/app/shared/trip-reservation.service';

@Component({
  selector: 'app-trip-reservation-form',
  templateUrl: './trip-reservation-form.component.html'
})
export class TripBookingFormComponent implements OnInit {

  constructor(public service: TripBookingService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.getTrips()
  }

  onSelectTrip(event: Event){
    this.service.setTrip() 
  }

  onSelectSeat(event: Event) {
    this.service.setSeat()
  }

  resetForm(form: NgForm) {
    form.form.reset()
    this.service.resetData()
  }

  onSubmit(form: NgForm) {
    this.postBooking(form)
    // Test for booking concurrency conflict
    this.postBooking(form)
  }

  postBooking(form: NgForm) {
    this.service.postBooking().subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Your seat has been booked.', 'Seat Booking')
        //this.service.refreshList();
      },
      err => {
        console.log(err)
        this.toastr.error(err.error)
      }
    )
  }

}
