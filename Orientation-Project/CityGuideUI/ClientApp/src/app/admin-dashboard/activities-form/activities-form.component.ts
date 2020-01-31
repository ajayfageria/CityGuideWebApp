import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Activities } from 'src/app/models/activities';

@Component({
  selector: 'app-activities-form',
  templateUrl: './activities-form.component.html',
  styleUrls: ['./activities-form.component.css'],
  providers: [DatePipe]
})
export class ActivitiesFormComponent implements OnInit {

  activities : Activities;

  constructor(private service:AdminService,private formBuilder: FormBuilder, private datePipe: DatePipe) {
    this.activities = new Activities();
   }

  ngOnInit() {
  
  }
    
  addActivitiesEntity(){var d = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
  console.log(d);
  
 var newOpeningTime = ( d + 'T' + (this.activities.openingTime).toString() + ':00.000');
 var newClosingTime = (d + 'T' + (this.activities.closingTime).toString() + ':00.000');
 console.log("new Opening date",newOpeningTime);
 console.log("new Closing date",newClosingTime);
 this.activities.openingTime = newOpeningTime;
 this.activities.closingTime = newClosingTime;
    this.service.addActivities(this.activities).subscribe(data => {
    })
  }
}
    
