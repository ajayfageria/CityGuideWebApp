import { Time } from '@angular/common';

export class Accomodations{
    public id : string;
    public name : string;
    public address : string;
    public categoryId : number;
    public latitude : string;
    public longitude : string;
    public altitude : string;
    public information : string;
    public nearestMetro : string;
    public openingTime : string;
    public closingTime : string;
    public entityImage : any;
    hasInternet: boolean;
    hasMeetingRooms: boolean;
    hasFitnessFacilities: boolean;
    hasParking: boolean;
    hasSwimmingPool: boolean;
    hasElevator: boolean;
    hasSecurityGuard: boolean;
    hasTv: boolean;
    luxuryLevel : number;
}