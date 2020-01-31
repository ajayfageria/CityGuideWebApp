import { Component, OnInit } from '@angular/core';
import { EntityDataService } from '../shared/entity-data.service';
import { DomSanitizer } from '@angular/platform-browser';
import { UserServiceService } from '../shared/user-service.service';
import { BlogDetails } from 'src/app/models/blogsModel'
import { Router } from '@angular/router';
import { from } from 'rxjs';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css']
})
export class BlogsComponent implements OnInit {
places: any;
obj: any;
thumbnail: any;

constructor(private entitydataservice : EntityDataService, private sanitizer: DomSanitizer,public service:UserServiceService,private router:Router) { 
  this.places = new Array<BlogDetails>();
}

ngOnInit() {
  this.entitydataservice.getSingleEntities(5).subscribe(data => {
    
   
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

