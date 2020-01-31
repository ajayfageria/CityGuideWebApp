import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from '../shared/user-service.service';
import { DomSanitizer } from '@angular/platform-browser';
import { EntityDataService } from '../shared/entity-data.service';

@Component({
  selector: 'app-activities-home',
  templateUrl: './activities-home.component.html',
  styleUrls: ['./activities-home.component.css']
})
export class ActivitiesHomeComponent implements OnInit {

  activities: any;
  obj: any;
  thumbnail: any;
  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) {
    
   }

  ngOnInit() {
    this.entitydataservice.getEntities(2).subscribe(data => {
      
     
      this.activities = data;
      console.log(this.activities);
      for(var i = 0; i < this.activities.length; i++)
      {
        this.obj = this.activities[i].image;
        let objectURL = 'data:image/jpeg;base64,' + this.obj.fileContents;

        this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
     
        this.activities[i].image=this.thumbnail;
      }
      
     
    
     
    });

  }

}
