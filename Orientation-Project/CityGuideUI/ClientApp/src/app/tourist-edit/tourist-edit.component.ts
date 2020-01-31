import { Component, OnInit } from '@angular/core';
import { AdminService } from '../shared/admin.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Tourist } from '../models/tourist';

@Component({
  selector: 'app-tourist-edit',
  templateUrl: './tourist-edit.component.html',
  styleUrls: ['./tourist-edit.component.css']
})
export class TouristEditComponent implements OnInit {

  tourist: Tourist;
  // router: any;

  constructor(private _service : AdminService , private http : HttpClient,private router:Router) { }

  ngOnInit() {
    this.getTouristToEdit();

    var tourist = new Tourist();
  }

  getTouristToEdit() {
    const names = this.router.url.split("/");
    console.log(names);
   this._service.getTouristToEdit(names[2]).subscribe(data =>
      
      // this.tourist = data
      console.log("getTouristTo edit",data)
    );
  }

}
