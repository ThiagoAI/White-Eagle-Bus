import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BusService } from 'src/app/shared/bus.service';
import { Trip } from '../../shared/models/trip.model';
import { TripService } from '../../shared/trip.service';

@Component({
  selector: 'app-bus-form',
  templateUrl: './bus-form.component.html'
})
export class BusFormComponent implements OnInit {

  constructor(public service:BusService,  private toastr:ToastrService) { }
  
  ngOnInit(): void {
  }

  resetForm(form: NgForm) {
    form.form.reset()
  }

  onSubmit(form: NgForm) {
    this.postBus(form)
  }
  
  postBus(form: NgForm) {
    this.service.postBus().subscribe(
      res => {
        this.resetForm(form)
        this.toastr.success('Bus creation succeded.', 'Bus Creation')
        //this.service.refreshList();
      },
      err => {         
        console.log(err)
        this.toastr.error(err.error)
      }
    )
  }
}
