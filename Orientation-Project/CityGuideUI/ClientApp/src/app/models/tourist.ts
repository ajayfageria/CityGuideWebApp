import { Time } from '@angular/common'

export class Tourist {
    id : string;
    name : string;
    address: string;
    latitude: number;
    longitude: number;
    altitude: string;
    information:string;
    nearestMetro: string;
    openingTime: string;
    closingTime: string;
    entityImage: any;
    public ticketPrice : number;
    public hasWifi : boolean;
    public hasPark : boolean;
    public hasSwimmingPool : boolean;
    public hasParking : boolean;
    public hasElevator : boolean;
    public hasMedical : boolean;
    public hasTrekking : boolean;
}
