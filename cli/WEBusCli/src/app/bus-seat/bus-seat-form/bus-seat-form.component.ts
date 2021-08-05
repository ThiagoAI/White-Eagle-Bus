import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BusSeatService } from 'src/app/shared/bus-seat.service';
import { Trip } from '../../shared/models/trip.model';
import { TripService } from '../../shared/trip.service';

@Component({
  selector: 'app-bus-seat-form',
  templateUrl: './bus-seat-form.component.html'
})
export class BusSeatFormComponent implements OnInit {

  constructor(public service:BusSeatService,  private toastr:ToastrService) { }
  
  ngOnInit(): void {
  }

  resetForm(form: NgForm) {
    form.form.reset()
  }

  onSubmit(form: NgForm) {
    this.postSeat(form)
  }
  
  postSeat(form: NgForm) {
    this.service.postSeat().subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Seat creation succeded.', 'Seat Creation')
        //this.service.refreshList();
      },
      err => {         
        console.log(err)
        this.toastr.error(err.error)
      }
    )
  }
}
