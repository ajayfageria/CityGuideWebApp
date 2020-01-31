import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  isRender:boolean=true;
 
  constructor(private fb:FormBuilder,private http:HttpClient,private router:Router) { }
  private loginStatus =new BehaviorSubject<boolean>(this.checkLoginStatus());
  private userName=new BehaviorSubject<string>(localStorage.getItem('username'));
  private userRole=new BehaviorSubject<string>(localStorage.getItem('userRole'));
readonly BaseURI='https://cityguidedelhi.azurewebsites.net/api';
  formModel=this.fb.group({
    UserName: ['', Validators.required],
    Email: ['',Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
    })

  });

  
register(){
     
  var body={
    UserName:this.formModel.value.UserName,
    Email:this.formModel.value.Email,
    FullName:this.formModel.value.FullName,
    Password:this.formModel.value.Passwords.Password,

  };
 
 return  this.http.post(this.BaseURI+'/ApplicationUser/Register',body);
}
login(formData){
  return  this.http.post<any>(this.BaseURI+'/ApplicationUser/login',formData).pipe(

    map(result=>{
      if(result&&result.token){
       
        this.loginStatus.next(true);
        localStorage.setItem('loginStatus','1');
        localStorage.setItem('jwt',result.token);
        localStorage.setItem('userName',result.username);
        localStorage.setItem('userRole',result.userRole);
      }
      return result;
    })
  );
}

Logout(){  
    
  localStorage.removeItem('token');
  localStorage.removeItem('jwt');
  localStorage.removeItem('username');
  localStorage.removeItem('expiration');
  localStorage.setItem('loginStatus','0');
  

  this.router.navigateByUrl('/user/login')
  }

checkLoginStatus():boolean{
  var loginCookie=localStorage.getItem("loginStatus");
  if(loginCookie=="1"){
    return true;
  }
return false;
}
loggedIn(){
  return !!localStorage.getItem('token')
}
getToken(){
return localStorage.getItem('token')


}
get isLoggedIn(){
return this.loginStatus.asObservable();
}
get currentUserName(){
  return this.userName.asObservable();
}
get currentUserRole(){
  return this.userRole.asObservable();
}
getUserProfile(){
  console.log("tokenHeader");
  var tokenHeader=new HttpHeaders({'Authorization':'Bearer '+localStorage.getItem('token')});
  console.log(tokenHeader);
  return this.http.get(this.BaseURI+'/user/getUserProfile',{headers:tokenHeader});
}

}
