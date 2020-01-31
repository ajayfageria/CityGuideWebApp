import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormBuilder, Validators } from '@angular/forms';
import {TouristplaceFormComponent} from '../admin-dashboard/touristplace-form/touristplace-form.component';
@Injectable({
  providedIn: 'root'
})
export class EntityDataService {
  

  constructor(private httpClient:HttpClient, private fb:FormBuilder) { }
  readonly url = 'https://localhost:44388/';

  public getEntities(id): Observable<any> {
    return this.httpClient.get(this.url +'api/Base/GetAll/'+ id);

  }
  public getSingleEntities(id): Observable<any> {
    return this.httpClient.get(this.url +'api/Base/EntityList/'+id);
  }
  public getTouristEntityDetails(name,id): Observable<any> {
    return this.httpClient.get(this.url + 'api/base/getentity?placename='+name+'&id=' + id );
  }

  public getSearchDetails(searchtext): Observable<any> {
    return this.httpClient.get(this.url + 'api/base/search?searchString='+searchtext);

  }
  
  getData() {
    return this.httpClient.get('/assets/config.json');
  }

 
}
