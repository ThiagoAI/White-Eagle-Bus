import { Bus } from "./bus.model"
import { TripLocation } from "./trip-location.model"

export class Trip {
    id?:number = undefined
    destination?:TripLocation = undefined
    destinationID:number = -1
    origin?:TripLocation = undefined
    originID:number = -1
    bus?:Bus = undefined
    busId:number = -1
}
