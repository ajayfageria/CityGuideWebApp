import { Component, OnInit } from '@angular/core';
import { AdminService } from 'src/app/shared/admin.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { BlogDetails } from 'src/app/models/blogsModel';

@Component({
  selector: 'app-blogs-form',
  templateUrl: './blogs-form.component.html',
  styleUrls: ['./blogs-form.component.css']
})
export class BlogsFormComponent implements OnInit {
  registerBlogForm: FormGroup;

  constructor(private service:AdminService,private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.registerBlogForm=this.formBuilder.group({
      Name: ['', Validators.required],
      Description: ['', Validators.required]
    })
  }
  onSubmit(){
 
       
    
      }
    
    }