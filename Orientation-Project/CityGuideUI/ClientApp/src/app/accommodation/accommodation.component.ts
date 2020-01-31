import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import {  Accomodations } from 'src/app/models/accomodation';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-accommodation',
  templateUrl: './accommodation.component.html',
  styleUrls: ['./accommodation.component.css']
})
export class AccommodationComponent implements OnInit {
  places: any;
  obj: any;
  thumbnail: any;

  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) {
    this.places = new Array<Accomodations>();
   }

  ngOnInit() {
   // getting all Accomodations entities
    this.entitydataservice.getSingleEntities(4).subscribe(data => {
      
     
      this.places = data;
      console.log(this.places);
      for(var i = 0; i < this.places.length; i++)
      {

        this.obj = this.places[i].image;
        let objectURL = 'data:image/jpeg;base64,' + this.obj.fileContents;

        this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
     
        this.places[i].image=this.thumbnail;
      }
      
     
    
     
    });

  }
  render()
  {
    
    this.service.isRender = false;
  }

}
