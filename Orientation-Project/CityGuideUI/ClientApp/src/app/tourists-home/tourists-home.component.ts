import { Component, OnInit } from '@angular/core';
import { Tourist } from 'src/app/models/tourist';
import { EntityDataService } from 'src/app/shared/entity-data.service';
import { from } from 'rxjs';
import { DomSanitizer } from '@angular/platform-browser';
import { stringify } from 'querystring';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tourists-home',
  templateUrl: './tourists-home.component.html',
  styleUrls: ['./tourists-home.component.css']
})
export class TouristsHomeComponent implements OnInit {
 
  places: any;
  obj: any;
  thumbnail: any;
  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) {
    this.places = new Array<Tourist>();
    
   }

  ngOnInit() {
    this.entitydataservice.getEntities(1).subscribe(data => {
      
     
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
