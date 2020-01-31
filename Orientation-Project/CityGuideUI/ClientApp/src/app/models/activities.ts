import { Time } from '@angular/common';

export class Activities{
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
    ticketPrice : number;
    hasElevator : number;
    activityType : string;
    noOfHoursTaken : number;
    hasWashroomFacilities : boolean;
}