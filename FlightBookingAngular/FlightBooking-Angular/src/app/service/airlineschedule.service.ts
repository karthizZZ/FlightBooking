import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAirlineScheduleBase } from '../interface/airlineschedule-model';

const Schedule_Api = 'https://localhost:5050/api/airlineschedule/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AirlinescheduleService {

  constructor(private http: HttpClient) { }

  addAirlineSchedule(airlineSchedule: IAirlineScheduleBase): Observable<any> {
    return this.http.post(Schedule_Api + 'Add',airlineSchedule , httpOptions);
  }

  getScheduleList():Observable<any> {
    // return this.http.get(Schedule_Api + 'Add' , httpOptions);
    return this.http.get('https://localhost:44345/api/airlineschedule/Get', httpOptions)
  }

  removeSchedule(id:any):Observable<any> {
    return this.http.put('https://localhost:44345/api/airlineschedule/Delete/' +id , httpOptions)
  }
}
