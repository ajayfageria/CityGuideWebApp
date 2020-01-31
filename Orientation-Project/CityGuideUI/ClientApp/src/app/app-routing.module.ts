import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TouristsComponent } from './tourists/tourists.component';
import { LogohomeComponent } from './logohome/logohome.component';
import { ActivitiesComponent } from './activities/activities.component';
import { FoodComponent } from './food/food.component';
import { AccommodationComponent } from './accommodation/accommodation.component';
import { BlogsComponent } from './blogs/blogs.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { ProfileComponent } from './user/profile/profile.component';
import { AuthGuard } from './auth/auth.guard';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AccomodationFormComponent } from './admin-dashboard/accomodation-form/accomodation-form.component';
import { ActivitiesFormComponent } from './admin-dashboard/activities-form/activities-form.component';
import { BlogsFormComponent } from './admin-dashboard/blogs-form/blogs-form.component';
import { FoodFormComponent } from './admin-dashboard/food-form/food-form.component';
import { TouristplaceFormComponent } from './admin-dashboard/touristplace-form/touristplace-form.component';
import { TouristDetailComponent } from './tourist-detail/tourist-detail.component';
import { ActivityDetailComponent } from './activity-detail/activity-detail.component';
import { FoodDetailComponent } from './food-detail/food-detail.component';
import { AccomodationDetailComponent } from './accomodation-detail/accomodation-detail.component';
import { MapviewComponent } from './tourist-detail/mapview/mapview.component';
import { SearchbarentityComponent } from './logohome/searchbarentity/searchbarentity.component';
import { TouristEditComponent } from './tourist-edit/tourist-edit.component';




const routes: Routes = [
  { path: '', redirectTo: '/logohome', pathMatch: 'full' },
  {path:'logohome',component:LogohomeComponent,
  children:[

    {path:'searchbarentity',component:SearchbarentityComponent}
  ]
},
  {path:'home',component:LogohomeComponent},
  {path:'tourists',component:TouristsComponent},
  {path:'activities',component:ActivitiesComponent},
  {path:'tourist-detail/:placename/1',component:TouristDetailComponent,
  children:[

    {path:'mapview',component:MapviewComponent}
  ]
},
  {path:'activity-detail/:placename/2',component:ActivityDetailComponent},
  {path:'food-detail/:placename/3',component:FoodDetailComponent},
  {path:'accommodation-detail/:placename/4',component:AccomodationDetailComponent},
  {path:'accommodation',component:AccommodationComponent},
  {path:'food',component:FoodComponent},
  {path:'tourist-edit/:id',component:TouristEditComponent},
  
  {path:'blogs',component:BlogsComponent},
  {path:'about-us',component:AboutUsComponent},
  {path:'profile',component:ProfileComponent,canActivate:[AuthGuard]},
  {path:'user',component:UserComponent,
  children:[

    {path:'registration',component:RegistrationComponent},
    {path:'login',component:LoginComponent},
]},



  {path:'admin-dashboard',component:AdminDashboardComponent,canActivate:[AuthGuard],
  children:[

    {path:'accomodation-form',component:AccomodationFormComponent},
    {path:'activities-form',component:ActivitiesFormComponent},
    {path:'blogs-form',component:BlogsFormComponent},
    {path:'food-form',component:FoodFormComponent},
    {path:'touristplace-form',component:TouristplaceFormComponent},
]}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
