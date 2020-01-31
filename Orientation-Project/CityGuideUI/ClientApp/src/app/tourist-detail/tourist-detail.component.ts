import { Component, OnInit,AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from '../shared/user-service.service';
import { DomSanitizer } from '@angular/platform-browser';
import { EntityDataService } from '../shared/entity-data.service';
import { MapModule, MapAPILoader, BingMapAPILoaderConfig, BingMapAPILoader, WindowRef, DocumentRef, MapServiceFactory, BingMapServiceFactory } from "angular-maps";

@Component({
  selector: 'app-tourist-detail',
  templateUrl: './tourist-detail.component.html',
  styleUrls: ['./tourist-detail.component.css']
})
export class TouristDetailComponent implements OnInit {
  place: any;
  obj: any;
  thumbnail: any;
  img: any;
  Id: number;
  imgs:any;

  bingMapKey:string='AodPKbPz6ovYDYmKGuHtZNHwnHqqXQcsItBG02GdZ62Xmd7nSPhzap5imtqOeyNE';
  public show:boolean = false;
  public buttonName:any = 'Show map';
  constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) { }

  ngOnInit() {
    
    const names = this.router.url.split("/");
    console.log(names);
    this.Id = 1;
    this.entitydataservice.getTouristEntityDetails(names[2],this.Id).subscribe(data => {
      
     
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
 
  toggle() {
    this.show = !this.show;

  
    if(this.show) 
      this.buttonName = "Hide map";
    else
      this.buttonName = "Show map";
  }
 
}


