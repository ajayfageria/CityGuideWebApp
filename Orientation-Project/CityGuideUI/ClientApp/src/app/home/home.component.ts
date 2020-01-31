import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserServiceService } from '../shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
 
  constructor(public service:UserServiceService,private router:Router) { }
  
  
  isRend = this.service.isRender ;
  
 
  loginStatus$: Observable<boolean>;
  userName$:Observable<string>;
  ngOnInit() {
    
    
   this.loginStatus$=this.service.isLoggedIn;
   this.userName$=this.service.currentUserName;
  

  }
  


    onLogout(){
      this.service.Logout();

    }

    rendFunc(){
      this.service.isRender = true;
      this.isRend  = this.service.isRender;
    }

    render(){
      this.service.isRender = false;
      this.isRend  = this.service.isRender;
    
    }
}
