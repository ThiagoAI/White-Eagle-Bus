import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TripBookingComponent } from './trip-reservation/trip-reservation.component';
import { TripFormComponent } from './trip/trip-form/trip-form.component';
import { TripComponent } from './trip/trip.component';
import { TripBookingFormComponent } from './trip-reservation/trip-reservation-form/trip-reservation-form.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { BusComponent } from './bus/bus.component';
import { BusSeatComponent } from './bus-seat/bus-seat.component';
import { BusFormComponent } from './bus/bus-form/bus-form.component';
import { BusSeatFormComponent } from './bus-seat/bus-seat-form/bus-seat-form.component';

const routes: Routes = [
  { path: 'trips', component: TripComponent },
  { path: 'booking', component: TripBookingComponent },
  { path: 'busses', component: BusComponent },
  {path: 'busseats', component: BusSeatComponent }
];

@NgModule({
  declarations: [
    TripFormComponent,
    AppComponent,
    TripBookingComponent,
    TripComponent,
    TripBookingFormComponent,
    BusComponent,
    BusSeatComponent,
    BusFormComponent,
    BusSeatFormComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    FormsModule,
    BrowserModule,
    HttpClientModule ,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
