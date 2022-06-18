import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HomeComponent } from './home/home.component';
import { UserListComponent } from './user-list/user-list.component';
import { AddUserComponent } from './add-user/add-user.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { SliderModule } from 'primeng/slider';
import { UserService } from './service/user.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AirlineListComponent } from './AirlineManagement/airline-list/airline-list.component';
import { AddAirlineComponent } from './AirlineManagement/add-airline/add-airline.component';
import { AddScheduleComponent } from './AirlineSchedule/add-schedule/add-schedule.component';

import {RadioButtonModule} from 'primeng/radiobutton';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { AutotestComponent } from './AirlineSchedule/autotest/autotest.component';
import {InputTextModule} from 'primeng/inputtext';
import {ToastModule} from 'primeng/toast';

import { TimepickerModule} from 'ngx-bootstrap/timepicker';
import {MultiSelectModule} from 'primeng/multiselect';
import { ToastComponent } from './toast/toast.component';
import { DropdownModule } from 'primeng/dropdown';
import {InputNumberModule} from 'primeng/inputnumber';
// import { AccordionModule } from 'primeng/accordion';
import { AccordionModule } from 'ngx-bootstrap/accordion';

import { AirlineBookingComponent } from './AirlineBooking/airline-booking/airline-booking.component';
import { ManagebookingComponent } from './AirlineBooking/managebooking/managebooking.component';
import { ScheduleListComponent } from './AirlineSchedule/schedule-list/schedule-list.component';
import { AuthInterceptor } from './helpers/auth.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    UserListComponent,
    AddUserComponent,
    NavigationBarComponent,
    LoginComponent,
    RegisterComponent,
    AirlineListComponent,
    AddAirlineComponent,
    AddScheduleComponent,
    AutotestComponent,
    ToastComponent,
    AirlineBookingComponent,
    ManagebookingComponent,
    ScheduleListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ButtonModule,
    TableModule,
    CalendarModule,
    SliderModule,
    FormsModule,
    ReactiveFormsModule,
    RadioButtonModule,
    AutoCompleteModule,
    InputTextModule,
    TimepickerModule,
    MultiSelectModule,
    ToastModule,
    DropdownModule,
    InputNumberModule,
    AccordionModule.forRoot()
  ],
  providers: [UserService,    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
