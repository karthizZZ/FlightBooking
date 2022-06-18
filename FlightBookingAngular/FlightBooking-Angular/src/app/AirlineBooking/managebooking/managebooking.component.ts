import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBookingItem } from 'src/app/interface/bookingitem';
import { BookingService } from 'src/app/service/booking.service';
import { TokenStorageService } from 'src/app/service/token-storage.service';

@Component({
  selector: 'app-managebooking',
  templateUrl: './managebooking.component.html',
  styleUrls: ['./managebooking.component.css']
})
export class ManagebookingComponent implements OnInit {

  isDisabled = false;
  bookingList: IBookingItem[] = [];
  constructor(private bookingService: BookingService,private router: Router,
    private tokenStorageService: TokenStorageService
    ) { }

  ngOnInit(): void {
    this.bookingService.getBookingList(this.tokenStorageService.getUser().userID).subscribe(
      (data:any) => {       
        this.bookingList = data.result;
        console.log(this.bookingList);
      },
      err => {
        console.log(err);
      }
    );
  }

  getTimeDiff(date2:any){
    let date1=new Date();
    if(date1 > new Date(date2)){
      return false;
    }
    let difference = Math.abs(date1.getTime()-(new Date(date2)).getTime())/36e5;
    return difference > 24;
  }

  cancelTicket(pnr : any){
    this.bookingService.cancelBooking(pnr).subscribe(
      (data:any) => {       
        console.log(data);
      },
      err => {
        console.log(err);
      }
    );
  }
}
