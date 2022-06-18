import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddUserComponent } from './add-user/add-user.component';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './user-list/user-list.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AddAirlineComponent } from './AirlineManagement/add-airline/add-airline.component';
import { AirlineListComponent } from './AirlineManagement/airline-list/airline-list.component';
import { AddScheduleComponent } from './AirlineSchedule/add-schedule/add-schedule.component';
import { AirlineBookingComponent } from './AirlineBooking/airline-booking/airline-booking.component';
import { ManagebookingComponent } from './AirlineBooking/managebooking/managebooking.component';
import { ScheduleListComponent } from './AirlineSchedule/schedule-list/schedule-list.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'user', component: UserListComponent },
  { path: 'add-user', component: AddUserComponent },
  { path: 'update-user/:id', component: AddUserComponent },
  { path: 'home', component: HomeComponent },
  { path: 'airline', component: AirlineListComponent },
  { path: 'add-airline', component: AddAirlineComponent },
  { path: 'update-airline/:id', component: AddAirlineComponent },
  { path: 'add-schedule', component: AddScheduleComponent },
  { path: 'book-flight', component: AirlineBookingComponent },
  { path: 'managebooking', component: ManagebookingComponent },
  { path: 'schedulelist', component: ScheduleListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }