import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';
import { Activities } from 'src/app/models/activities'

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css']
})
export class ActivitiesComponent implements OnInit {
  places: any;
  obj: any;
  thumbnail: any;

  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) { 
    this.places = new Array<Activities>();
  }

  ngOnInit() {
    this.entitydataservice.getSingleEntities(2).subscribe(data => {
      
     
      this.places = data;
      console.log('temp1',this.places);
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
