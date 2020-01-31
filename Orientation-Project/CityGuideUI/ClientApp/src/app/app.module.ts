import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { TouristsComponent } from './tourists/tourists.component';
import { ActivitiesComponent } from './activities/activities.component';
import { LogohomeComponent } from './logohome/logohome.component';
import { FoodComponent } from './food/food.component';
import { AccommodationComponent } from './accommodation/accommodation.component';
import { BlogsComponent } from './blogs/blogs.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserServiceService } from './shared/user-service.service';
import { HttpClientModule, HttpClient } from "@angular/common/http";
import { LoginComponent } from './user/login/login.component';
import { TouristsHomeComponent } from './tourists-home/tourists-home.component';
import { ProfileComponent } from './user/profile/profile.component';
import { ActivitiesHomeComponent } from './activities-home/activities-home.component';
import { AccomodationHomeComponent } from './accomodation-home/accomodation-home.component';
import { FoodHomeComponent } from './food-home/food-home.component';
import {AdminDashboardComponent} from './admin-dashboard/admin-dashboard.component';
import {AccomodationFormComponent} from './admin-dashboard/accomodation-form/accomodation-form.component';
import {ActivitiesFormComponent} from './admin-dashboard/activities-form/activities-form.component';
import {BlogsFormComponent} from './admin-dashboard/blogs-form/blogs-form.component';
import {FoodFormComponent} from './admin-dashboard/food-form/food-form.component';
import {TouristplaceFormComponent} from './admin-dashboard/touristplace-form/touristplace-form.component';
import { AdminService } from './shared/admin.service';
import { TouristDetailComponent } from './tourist-detail/tourist-detail.component';
import { ActivityDetailComponent } from './activity-detail/activity-detail.component';
import { AccomodationDetailComponent } from './accomodation-detail/accomodation-detail.component';
import { FoodDetailComponent } from './food-detail/food-detail.component';
import { MapviewComponent } from './tourist-detail/mapview/mapview.component';
import { SearchbarentityComponent } from './logohome/searchbarentity/searchbarentity.component';
import { TouristEditComponent } from './tourist-edit/tourist-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TouristsComponent,
    ActivitiesComponent,
    LoginComponent,
    LogohomeComponent,
    FoodComponent,
    AccommodationComponent,
    BlogsComponent,
    AboutUsComponent,
    UserComponent,
    RegistrationComponent,
   TouristsHomeComponent,
   ProfileComponent,
   ActivitiesHomeComponent,
   AccomodationHomeComponent,
   FoodHomeComponent,
   AdminDashboardComponent,
   AccomodationFormComponent,
   ActivitiesFormComponent,
   BlogsFormComponent,
   FoodFormComponent,
   TouristplaceFormComponent,
   TouristDetailComponent,
   ActivityDetailComponent,
   AccomodationDetailComponent,
   FoodDetailComponent,
   MapviewComponent,
   SearchbarentityComponent,
   TouristEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule ,
    FormsModule ,
    
  ],
  providers: [UserServiceService, AdminService,HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
