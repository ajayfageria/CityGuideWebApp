import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserServiceService } from 'src/app/shared/user-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formModel = {
    UserName: '',
    Password: ''
  }
  constructor(private service:UserServiceService,private router:Router) { }

  ngOnInit() {
    if(localStorage.getItem('token')!=null)
    this.router.navigateByUrl('/profile');
  }

onSubmit(form:NgForm){
this.service.login(form.value).subscribe(
(res:any)=>{
  if(res.Role == "Traveller")
  {
    localStorage.setItem('token',res.token);
    this.router.navigateByUrl('/profile');

  }
  else
  {
    localStorage.setItem('token',res.token);
    this.router.navigateByUrl('/admin-dashboard');

  }
  
 
  
}, 
err=>{
  if (err.status == 400)
  console.log("Incorrect username or password.', 'Authentication failed.");
else
  console.log(err);
}


);
}
}
