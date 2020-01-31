import { Injectable } from '@angular/core';
import {BlogDetails} from '../models/blogsModel';
import { HttpClient,HttpHeaders, HttpClientModule } from '@angular/common/http';

import { Validators, FormBuilder, NgForm } from '@angular/forms';
import {Tourist} from 'src/app/models/tourist';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AdminService {
  

  constructor(private http: HttpClient, private fb: FormBuilder) {
    
   }

readonly BaseURI='https://localhost:44388/api/';


public addTourist(tourist): Observable<any> {
  
  var headers = new HttpHeaders();
       let httpOptions = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("token")
      
    });
 
   
  return this.http.post(this.BaseURI + 'tourist/addtourist', tourist, { headers: httpOptions });

}


public addAccomodation(accomodation): Observable<any> {
  
  var headers = new HttpHeaders();
   
    let httpOptions = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("token")
      
    });
 
    return this.http.post(this.BaseURI + 'Accomodation/AddAccommodation', accomodation, { headers: httpOptions });

}

public addActivities(activities): Observable<any> {
  
  var headers = new HttpHeaders();
  
    let httpOptions = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("token")
      
    });
 
   
  return this.http.post(this.BaseURI + 'Activities/AddActivities', activities, { headers: httpOptions });

}

public addBlog(blog): Observable<any> {
  
  var headers = new HttpHeaders();
    
    let httpOptions = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("token")
      
    });
 
   
  return this.http.post(this.BaseURI + 'Blog/AddBlog', blog, { headers: httpOptions });

}
public addFood(food): Observable<any> {
  
  var headers = new HttpHeaders();
   
    let httpOptions = new HttpHeaders({ 
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem("token")
      
    });
 
    
  return this.http.post(this.BaseURI + 'Food/AddFood', food, { headers: httpOptions });

}

getTouristToEdit(Id: string): Observable<any> {
  var headers = new HttpHeaders();
   
  let httpOptions = new HttpHeaders({ 
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + localStorage.getItem("token")
    
  });
 return this.http.get(this.BaseURI +'Base/GetEntity/?Id',{ headers: httpOptions });
}

}
