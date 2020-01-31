import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/shared/user-service.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  constructor(private service:UserServiceService) { }

  ngOnInit() {

    }
  }

