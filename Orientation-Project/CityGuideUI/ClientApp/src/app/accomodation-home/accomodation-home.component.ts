import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-accomodation-home',
  templateUrl: './accomodation-home.component.html',
  styleUrls: ['./accomodation-home.component.css']
})
export class AccomodationHomeComponent implements OnInit {

  accomodations: any;
  obj: any;
  thumbnail: any;
  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) {
    
   }

  ngOnInit() {
    this.entitydataservice.getEntities(4).subscribe(data => {
      
     
      this.accomodations = data;
      console.log(this.accomodations);
      for(var i = 0; i < this.accomodations.length; i++)
      {

        this.obj = this.accomodations[i].image;
        let objectURL = 'data:image/jpeg;base64,' + this.obj.fileContents;

        this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
     
        this.accomodations[i].image=this.thumbnail;
      }
      
     
    
     
    });

  }

}
