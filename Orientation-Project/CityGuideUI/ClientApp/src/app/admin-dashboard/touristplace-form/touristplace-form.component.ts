import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { AdminService } from 'src/app/shared/admin.service';
import {Tourist} from 'src/app/models/tourist';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-touristplace-form',
  templateUrl: './touristplace-form.component.html',
  styleUrls: ['./touristplace-form.component.css'],
  providers: [DatePipe]
})

export class TouristplaceFormComponent implements OnInit {

  selectedFile = null;
  onFileSelected(){

  }

  tourist : Tourist;
  

  constructor( private formBuilder: FormBuilder,private service:AdminService,private datePipe: DatePipe ) {
    this.tourist = new Tourist();
   }

  ngOnInit() {
  }
  addTouristEntity(){
    
  
    var d = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    
   var newOpeningTime = ( d + 'T' + (this.tourist.openingTime).toString() + ':00.000');
   var newClosingTime = (d + 'T' + (this.tourist.closingTime).toString() + ':00.000');
   console.log("new Opening date",newOpeningTime);
   console.log("new Closing date",newClosingTime);
   this.tourist.openingTime = newOpeningTime;
   this.tourist.closingTime = newClosingTime;
    this.service.addTourist(this.tourist).subscribe(data => {
     
    })
  }

}
