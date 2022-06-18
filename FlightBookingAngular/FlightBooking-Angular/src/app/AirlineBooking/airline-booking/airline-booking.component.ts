import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';  
import { ActivatedRoute, Router } from '@angular/router';
import { BookedSeatList, BookingDetails, PassengerList } from 'src/app/interface/booking-model';
import { BookingService } from 'src/app/service/booking.service';
import {MessageService} from 'primeng/api';
import { TokenStorageService } from 'src/app/service/token-storage.service';

@Component({
  selector: 'app-airline-booking',
  templateUrl: './airline-booking.component.html',
  styleUrls: ['./airline-booking.component.css'],
  providers: [MessageService]
})
export class AirlineBookingComponent implements OnInit {

  customerInfo : FormGroup;
  genderList: any[];
  objj:any;
  mealList: any[]
  noTicket:any = 1;
  constructor(private formBuilder : FormBuilder,private route:ActivatedRoute,
    private bookingService:BookingService, private messageService: MessageService,
    private tokenStorageService: TokenStorageService,
    private router:Router){
    this.genderList = [
      {name: 'Male', id:1},
      {name: 'Female', id:2},
      {name: 'Other', id: 3}
  ];
  this.mealList = [
    {name: 'Veg', id:1},
    {name: 'NonVeg', id:2},
    {name: 'None', id: 3}
   ];
  }

  ngOnInit(){
    debugger
    this.customerInfo = this.formBuilder.group({
      fullName : [],
      email : [],
      mealType : [],
      noOfTickets : [],
      products : this.formBuilder.array([])
    })
    this.setDefaultData();
    this.objj = JSON.parse(this.route.snapshot.paramMap.get('my_object')!);
    console.log(this.objj);
  }

  addProduct(name = "", gender = "",age=""){
    let products = this.customerInfo.get('products') as FormArray;
    products.push(this.formBuilder.group({
      name : [name, [Validators.required]],
      gender : [gender, [Validators.required]],
      age:[, [Validators.required]],
    }));
  }

  createCustomerInfo(){
    // console.log('data is ', this.customerInfo.value);
    // this.customerInfo.markAllAsTouched();

    var formValue = this.customerInfo.value;
    let passengerList: PassengerList[]=[];
    for(var item of formValue.products){
      let passengerDetails: PassengerList={
        PassengerName:item.name,
        Gender:item.gender.name,
        Age:item.age
      }
      passengerList.push(passengerDetails);
    }
    let seatDetails:BookedSeatList[] = [];
     for(let i=1;i<=formValue.noOfTickets;i++){
       let seatDetail: BookedSeatList = {
         SeatNumber:i
       }
       seatDetails.push(seatDetail);
     }
     let bookingDeatsils: BookingDetails = {
      AirlineID: this.objj.airlineID,
      FlightNumber: this.objj.flightNumber,
      AirlineName: this.objj.airlineName,
      BookingDate: this.objj.bookingDate,
      MealType: formValue.mealType.name,
      NoOfPassengers: formValue.noOfTickets,
      Email: formValue.email,
      SeatType: this.objj.seatType,
      CreatedDate: new Date(),
      FromAirport: this.objj.fromAirport,
      ToAirport:this.objj.toAirport,
      PassengerList: passengerList,
      BookedSeatList: seatDetails,
      ticketCost: this.objj.ticketPrice,
      tax:this.objj.tax,
      CreatedUserID:this.tokenStorageService.getUser().userID
     }
     console.log(bookingDeatsils);

     this.bookingService.bookSchedule(bookingDeatsils).subscribe(
      data => {
        if(data.isSuccess==true){
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Data added successfully' });
          this.router.navigate(['/home'])
        }else{
          this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Some error has occured' });
        }
        console.log(data);
      },
      err => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Some error has occured' });
      }
    );
  }

  setDefaultData(){
    this.addProduct("", "","");
  }

  get aliasesArrayControl() {
    return (this.customerInfo.get('products') as FormArray).controls;
  }

  deleteDetails(lessonIndex: number) {
    (this.customerInfo.get('products') as FormArray).removeAt(lessonIndex);
  }
}
