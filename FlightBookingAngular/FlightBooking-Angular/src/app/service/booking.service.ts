import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BookingDetails } from '../interface/booking-model';
import { Observable } from 'rxjs';

const bookSchedule_Api = 'https://localhost:5050/api/airlineschedule/';
const booking_Api = 'https://localhost:5050/api/booking/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) { }

  bookSchedule(bookingDetails: BookingDetails): Observable<any> {
    return this.http.post(bookSchedule_Api + 'BookSchedule',bookingDetails , httpOptions);
  }

  getBookingList(id:any): Observable<any> {
    return this.http.get(booking_Api + 'GetList/'+ id,  httpOptions);
  }

  cancelBooking(pnr:string): Observable<any> {
    return this.http.put(booking_Api + 'Cancel/'+ pnr,  httpOptions);
  }
}
