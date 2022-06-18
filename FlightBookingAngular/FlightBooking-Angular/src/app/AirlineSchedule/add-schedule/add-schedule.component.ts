import { Component, OnInit,LOCALE_ID } from '@angular/core';
import { AirlineService } from '../../service/airline.service';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { IAirlineScheduleBase,IAirlineSeatCostDetail,IAirlineSchedule,IAirlineScheduleDay } from 'src/app/interface/airlineschedule-model';
import {MessageService} from 'primeng/api';
import {AirlinescheduleService} from '../../service/airlineschedule.service';

@Component({
  selector: 'app-add-schedule',
  templateUrl: './add-schedule.component.html',
  styleUrls: ['./add-schedule.component.css'],
  providers: [MessageService]
})
export class AddScheduleComponent implements OnInit {
  value2: string;
  cmmo="cmmo";
  availabilityType:string;
  airlineScheduleform: UntypedFormGroup;

  selectedCountry: any;

  airlines: any[];

  filteredAirlines: any[];

  selectedAirlines: any[];

  selectedCategory: any = null;
//--------------------------
  AirportList: any[];
  filteredAirportList: any[]
  filteredToAirportList: any[]

 startTime: Date = new Date();
 reachTime: Date = new Date();

 //-----------

 selectedDays: string[] = [];

 days: any[];

 city:string;

 airlineSchedule:IAirlineScheduleBase;

  constructor( private airlineService: AirlineService,private http:HttpClient,
    private fb: UntypedFormBuilder,private messageService: MessageService,
    private airlineScheduleService: AirlinescheduleService
    ){

    this.airlineScheduleform = this.fb.group({
      airline: ['', []],
      flightNo: ['',[Validators.required]],
      flightName: ['',[Validators.required]],
      fromAirport: ['',[Validators.required]],
      toAirport:['',[Validators.required]],
      startTime:['',[Validators.required]],
      reachTime:['',[Validators.required]],
      mealType:['',[Validators.required]],
      scheduleType:['',[Validators.required]],
      scheduledDays:['',[Validators.required]],
      ecNoOfSeats:['',[Validators.required]],
      ecTicketCost:['',[Validators.required]],
      bcNoOfSeats:['',[Validators.required]],
      bcTicketCost:['',[Validators.required]]
    });

    this.days = [
      { weekDay: "Sunday", id:1 },
      { weekDay: "Monday", id:2 },
      { weekDay: "Tuesday", id:3 },
      { weekDay: "Wednesday", id:4 },
      { weekDay: "Thursday", id:5 },
      { weekDay: "Friday", id:6 },
      { weekDay: "Saturday", id:7 },
    ];
  }

  ngOnInit() {
    this.http.get('https://localhost:44345/api/airline/Get').subscribe(
      (response:any)=>{
        this.airlines = response.result;
        console.log(this.airlines);
      },error=>{
        console.log(error);
      }
    );

    this.http.get('https://localhost:44345/api/airline/GetAirports').subscribe(
      (response:any)=>{
        this.AirportList = response.result;
      },error=>{
        console.log(error);
      }
    );
  }

  filterFromAirportList(event:any) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.AirportList.length; i++) {
      let airport = this.AirportList[i];
      if (airport.airportName.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(airport);
      }
    }
    this.filteredAirportList=filtered;
  }

  filterToAirportList(event:any) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.AirportList.length; i++) {
      let airport = this.AirportList[i];
      if (airport.airportName.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(airport);
      }
    }
    this.filteredToAirportList=filtered;
  }

  filterCountry(event:any) {
    let filtered: any[] = [];
    let query = event.query;
    for (let i = 0; i < this.airlines.length; i++) {
      let airline = this.airlines[i];
      if (airline.airlineName.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(airline);
      }
    }
    this.filteredAirlines=filtered;
  }

  save() {
    var formvalue = this.airlineScheduleform.value;
    let airlineScheduleData: IAirlineSchedule = {
      airlineID: formvalue.airline.airlineID,
      flightNumber: formvalue.flightNo,
      flightName: formvalue.flightName,
      fromLocation: formvalue.fromAirport.airportID,
      toLocation: formvalue.toAirport.airportID,
      startTime: formvalue.startTime,
      endTime: formvalue.reachTime,
      mealType: formvalue.mealType,
      isDaily: formvalue.scheduleType == "daily",
      isWeekdays: formvalue.scheduleType == "weekdays",
      isWeekends: formvalue.scheduleType == "weekends",
      isSpecificDays: formvalue.scheduleType == "specificdays",
      airlineScheduleID: 0
    }
    
    let seatItemBc: IAirlineSeatCostDetail = {
      seatType: "Business",
      noOfSeats: formvalue.bcNoOfSeats,
      ticketCost: formvalue.bcTicketCost,
      flightID: 0,
      tax: 0
    };
    let seatItemEc: IAirlineSeatCostDetail = {
      seatType: "Economy",
      noOfSeats: formvalue.ecNoOfSeats,
      ticketCost: formvalue.ecTicketCost,
      flightID: 0,
      tax: 0
    };
    let seatDetails: IAirlineSeatCostDetail[]=[
      seatItemBc,seatItemEc
    ];
    if(formvalue.scheduleType == 'specificdays'){
      this.airlineSchedule={
        airlineSchedule:airlineScheduleData,
        airlineSeatCostDetails:seatDetails,
        airlineScheduleDays:formvalue.scheduledDays
      }
    }else{
      this.airlineSchedule={
        airlineSchedule:airlineScheduleData,
        airlineSeatCostDetails:seatDetails
      }
    }
    
    console.log(this.airlineSchedule);
    this.airlineScheduleService.addAirlineSchedule(this.airlineSchedule).subscribe(
      data => {
        if(data.result==true){
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Data added successfully' });
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
}
