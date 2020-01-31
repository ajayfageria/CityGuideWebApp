import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-food-detail',
  templateUrl: './food-detail.component.html',
  styleUrls: ['./food-detail.component.css']
})
export class FoodDetailComponent implements OnInit {
  place: any;
  obj: any;
  thumbnail: any;
  imgs: any;
  img: any;
  FoodCategoryId: number;

  constructor(private entitydataservice : EntityDataService,
               private sanitizer: DomSanitizer,
               public service:UserServiceService,
               private router:Router) { }

  ngOnInit() {
    
    const names = this.router.url.split("/");
  
    this.entitydataservice.getTouristEntityDetails(names[2],names[3]).subscribe(data => {
      
     
      this.place = data;
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
