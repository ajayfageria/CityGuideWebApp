import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/shared/user-service.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
userDetails;
  constructor(private router:Router,private service:UserServiceService) { }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
res=>{  
this.userDetails=res;
},
err=>{
  console.log(err);
});
  }
  
}
