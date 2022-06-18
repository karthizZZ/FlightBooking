import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAirport } from '../interface/airport-model';
import { ISearchInput } from '../interface/searchinput-model';
import { ISearchResult } from '../interface/searchresult-model';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  airportList: IAirport[];
  triptype: any="one-way";
  searchInput: ISearchInput;
  searchResult: ISearchResult[];

  bookingDate:Date;
  ticketNumbers:number;
  seatType:string ;

  constructor(private http:HttpClient, private router:Router) { }

  ngOnInit(): void {
    this.http.get('https://localhost:44345/api/airline/GetAirports').subscribe(
      (response:any)=>{
        this.airportList = response.result;
        console.log(this.airportList);
      },error=>{
        console.log(error);
      }
    );
  }

  onClickSubmt(inputData:any){
    this.http.post('https://localhost:44345/api/airlineschedule/Search', {
      fromAirportID:inputData.fromairport,
      toAirportID:inputData.toairport,
      travelDate:inputData.departingdate,
      returnDate: inputData.returningdate,
      isRoundTrip: inputData.flighttype=='roundtrip',
      seatType: inputData.seattype,
      noOfTickets: inputData.noofticket
    }, httpOptions).subscribe(
      (response:any)=>{
        this.searchResult = response.result;
        console.log(response.result);
      },error=>{
        console.log(error);
      }
    );
    console.log(inputData);
  }

  bookTicket(obj:ISearchResult){
    obj.ticketNumbers = this.ticketNumbers;
    obj.bookingDate=this.bookingDate;
    obj.seatType = this.seatType;
    this.router.navigate(['/book-flight', {my_object: JSON.stringify(obj)}])
    .then(() => {
      
    });
  }
}
