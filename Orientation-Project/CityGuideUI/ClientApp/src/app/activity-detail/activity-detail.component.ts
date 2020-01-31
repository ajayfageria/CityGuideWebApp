import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-activity-detail',
  templateUrl: './activity-detail.component.html',
  styleUrls: ['./activity-detail.component.css']
})
export class ActivityDetailComponent implements OnInit {
  place: any;
  obj: any;
  thumbnail: any;
  img: any;
  imgs:any;
  ActivityCategoryId: number;

  constructor(private entitydataservice : EntityDataService,
               private sanitizer: DomSanitizer,
               public service:UserServiceService,
               private router:Router) { }

  ngOnInit() {
    
    const names = this.router.url.split("/");
    this.ActivityCategoryId =2;
    this.entitydataservice.getTouristEntityDetails(names[2],this.ActivityCategoryId).subscribe(data => {
      
     
      this.place = data;
      console.log(this.place);
      var i=0;
     // console.log(this.place);
      //console.log(this.place.Images.length , 'AJay');
       for( i = 0; i < this.place.Images.length; i++)
        {

          this.obj = this.place.Images[i];
        
          let objectURL = 'data:image/jpeg;base64,' + this.obj.fileContents;

          this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
      
          this.imgs=this.thumbnail;
          if(i==0)
          {
            this.img=this.imgs;
          }
       
        }  

       
     
    });
  }

}
