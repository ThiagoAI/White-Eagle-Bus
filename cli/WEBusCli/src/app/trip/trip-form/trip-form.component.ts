import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Trip } from '../../shared/models/trip.model';
import { TripService } from '../../shared/trip.service';

@Component({
  selector: 'app-trip-form',
  templateUrl: './trip-form.component.html'
})
export class TripFormComponent implements OnInit {

  constructor(public service:TripService,  private toastr:ToastrService) { }
  
  ngOnInit(): void {
    this.service.getTripLocations()
    this.service.getBusses()
  }

  resetForm(form: NgForm) {
    form.form.reset()
    this.service.formData = new Trip()
  }

  onSubmit(form: NgForm) {
    this.postTrip(form)
  }
  
  postTrip(form: NgForm) {
    this.service.postTrip().subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Trip creation succeded.', 'Trip Creation')
        //this.service.refreshList();
      },
      err => {         
        console.log(err)
        this.toastr.error(err.error)
      }
    )
  }
}
