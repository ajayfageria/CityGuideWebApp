import { Component, OnInit } from '@angular/core';
import { EntityDataService } from 'src/app/shared/entity-data.service';

@Component({
  selector: 'app-searchbarentity',
  templateUrl: './searchbarentity.component.html',
  styleUrls: ['./searchbarentity.component.css']
})
export class SearchbarentityComponent implements OnInit {
entitylist;
tourist=1;


  constructor(private service:EntityDataService) { }
  
  public show:boolean = true;
  public show1:boolean = false;
  ngOnInit() {
    if(this.show1)
    this.show=!this.show;
  }
  getSearchedItem(){
    this.show=!this.show;
    this.show1=!this.show1;
    
    var searchtext = ((document.getElementById("getSearchData") as HTMLInputElement).value);
    console.log(searchtext)
    this.service.getSearchDetails(searchtext).subscribe(
      res=>{  
        this.entitylist=res;
        console.log(this.entitylist)
        },
        err=>{
          console.log(err);
        });

}
}