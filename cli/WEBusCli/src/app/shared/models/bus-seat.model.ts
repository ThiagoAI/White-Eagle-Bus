import { Bus } from "./bus.model";

export class BusSeat {
    id?:number = undefined
    busId:number = -1
    seatName:string = ''
    bus: Bus = new Bus
}
