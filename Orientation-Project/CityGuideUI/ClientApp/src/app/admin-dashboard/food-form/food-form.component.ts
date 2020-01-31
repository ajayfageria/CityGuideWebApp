import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormsModule} from '@angular/forms';
import { AdminService } from 'src/app/shared/admin.service';
import { DatePipe } from '@angular/common';
import { Food } from 'src/app/models/food';

@Component({
  selector: 'app-food-form',
  templateUrl: './food-form.component.html',
  styleUrls: ['./food-form.component.css'],
  providers: [DatePipe]

})

export class FoodFormComponent implements OnInit {

  food : Food
  constructor( private formBuilder: FormBuilder,private service:AdminService, private datePipe : DatePipe) {
    this.food = new Food();
   }

  ngOnInit() {

  
  }
  

  
  addFoodEntity(){
    
  
    var d = this.datePipe.transform(new Date(), 'yyyy-MM-dd');
    
   var newOpeningTime = ( d + 'T' + (this.food.openingTime).toString() + ':00.000');
   var newClosingTime = (d + 'T' + (this.food.closingTime).toString() + ':00.000');
   console.log("new Opening date",newOpeningTime);
   console.log("new Closing date",newClosingTime);
   this.food.openingTime = newOpeningTime;
   this.food.closingTime = newClosingTime;
    this.service.addFood(this.food).subscribe(data => {
      
    })
  }
}
