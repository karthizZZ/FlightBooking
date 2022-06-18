import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { IAirlineSchedule } from 'src/app/interface/airlineschedule-model';
import { AirlinescheduleService } from 'src/app/service/airlineschedule.service';

@Component({
  selector: 'app-schedule-list',
  templateUrl: './schedule-list.component.html',
  styleUrls: ['./schedule-list.component.css'],
  providers: [MessageService]
})
export class ScheduleListComponent implements OnInit {

  scheduleList: IAirlineSchedule[] = [];
  first = 0;
  rows = 10;
  constructor(private scheduleService: AirlinescheduleService,private router: Router,
    private messageService: MessageService) {}
  ngOnInit(): void {
      this.scheduleService.getScheduleList().subscribe(
        (data:any) => {       
          this.scheduleList = data.result;
        },
        err => {
          console.log(err);
        }
      );
  }
  next() {
      this.first = this.first + this.rows;
  }
  prev() {
      this.first = this.first - this.rows;
  }
  reset() {
      this.first = 0;
  }
  isLastPage(): boolean {
      return this.scheduleList ? this.first === (this.scheduleList.length - this.rows) : true;
  }
  isFirstPage(): boolean {
      return this.scheduleList ? this.first === 0 : true;
  }

  remove(id: number) {
    this.scheduleService.removeSchedule(id).subscribe(
      (data:any) => {       
        if(data.result){
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Data deleted successfully' });
        }
      },
      err => {
        this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Some error has occured' });
      }
    );
      // this.scheduleList.removeUser(id);
      // this.airlineList = this.airlineService.getUsers();
  }

}
