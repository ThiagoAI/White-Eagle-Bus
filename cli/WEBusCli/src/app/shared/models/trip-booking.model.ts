import { BusSeat } from "./bus-seat.model";
import { Trip } from "./trip.model";

export class TripBooking {
    id?:number = undefined
    busSeatID:number = -1
    busSeat?:BusSeat = undefined
    busTripID:number = -1
    busTrip?:Trip = undefined
}