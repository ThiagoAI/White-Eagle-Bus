import { Component, OnInit } from '@angular/core';
import { Trip } from '../shared/models/trip.model';
import { TripService } from '../shared/trip.service';

@Component({
  selector: 'app-trip',
  templateUrl: './trip.component.html'
})
export class TripComponent implements OnInit {

  constructor(public service:TripService) { }
  
  ngOnInit(): void {
  }

}
