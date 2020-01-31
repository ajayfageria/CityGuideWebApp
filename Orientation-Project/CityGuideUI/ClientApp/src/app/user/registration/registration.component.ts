import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { UserServiceService } from 'src/app/shared/user-service.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: []
})
export class RegistrationComponent implements OnInit {

  constructor(public service:UserServiceService) { }


  ngOnInit() {
  }
  onSubmit() {
  
    this.service.register().subscribe(
      (res: any) => {
     
        if (res.succeeded) {
          this.service.formModel.reset();
         console.log("success")
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                console.log("already exist")
                break;
              default:
                console.log("failed")
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
