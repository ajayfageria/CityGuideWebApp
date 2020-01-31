import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-food-home',
  templateUrl: './food-home.component.html',
  styleUrls: ['./food-home.component.css']
})
export class FoodHomeComponent implements OnInit {

  foods: any;
  obj: any;
  thumbnail: any;
  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) {
    
   }

  ngOnInit() {
    this.entitydataservice.getEntities(3).subscribe(data => {
      
     
      this.foods = data;
      for(var i = 0; i < this.foods.length; i++)
      {

        this.obj = this.foods[i].image;
        let objectURL = 'data:image/jpeg;base64,' + this.obj.fileContents;

        this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
     
        this.foods[i].image=this.thumbnail;
      }
      
     
    
     
    });

  }

}
