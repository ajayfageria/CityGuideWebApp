import { Component, OnInit } from '@angular/core';
import { UserServiceService } from '../shared/user-service.service';
import { EntityDataService } from '../shared/entity-data.service';
import { Tourist }  from 'src/app/models/tourist'
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tourists',
  templateUrl: './tourists.component.html',
  styleUrls: ['./tourists.component.css']
})
export class TouristsComponent implements OnInit { 
places: any;
obj: any;
thumbnail: any;

constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) { 
  this.places = new Array<Tourist>();
}

ngOnInit() {
  this.entitydataservice.getSingleEntities(1).subscribe(data => {
    
   
    this.places = data;
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

