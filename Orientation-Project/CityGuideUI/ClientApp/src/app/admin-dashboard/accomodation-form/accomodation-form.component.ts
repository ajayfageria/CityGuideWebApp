import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { AdminService } from 'src/app/shared/admin.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Accomodations } from 'src/app/models/accomodation';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-accomodation-form',
  templateUrl: './accomodation-form.component.html',
  styleUrls: ['./accomodation-form.component.css'],
  providers: [DatePipe]

})
export class AccomodationFormComponent implements OnInit {



  accomodation : Accomodations;
  constructor( private formBuilder: FormBuilder,private service:AdminService,private datePipe: DatePipe ) {
    this.accomodation = new Accomodations();
   }

  
   ngOnInit() {

  }

       
    
  addAccomodationEntity(){
  var d = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
  console.log(d);
  
 var newOpeningTime = ( d + 'T' + (this.accomodation.openingTime).toString() + ':00.000');
 var newClosingTime = (d + 'T' + (this.accomodation.closingTime).toString() + ':00.000');
 console.log("new Opening date",newOpeningTime);
 console.log("new Closing date",newClosingTime);
 this.accomodation.openingTime = newOpeningTime;
 this.accomodation.closingTime = newClosingTime;
    this.service.addAccomodation(this.accomodation).subscribe(data => {
     
    })
  }
}
    