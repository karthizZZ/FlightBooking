import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AirlineService } from '../../service/airline.service';
import { IAirline } from '../../interface/airline-model';
import { TokenStorageService } from '../../service/token-storage.service';
@Component({
  selector: 'app-airline-list',
  templateUrl: './airline-list.component.html',
  styleUrls: ['./airline-list.component.css']
})
export class AirlineListComponent implements OnInit {

  airlineList: IAirline[] = [];
  first = 0;
  rows = 10;
  constructor(private airlineService: AirlineService,private tokenStorage: TokenStorageService,private router: Router) {}
  ngOnInit(): void {
      if (!this.tokenStorage.getToken()) {
          this.router.navigate(['/login'])
      }
      // Get Users from UserService
      this.airlineService.getUsers().subscribe(
        (data:any) => {       
          this.airlineList = data.result;
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
      return this.airlineList ? this.first === (this.airlineList.length - this.rows) : true;
  }
  isFirstPage(): boolean {
      return this.airlineList ? this.first === 0 : true;
  }

  remove(id: number) {
      this.airlineService.removeUser(id);
      // this.airlineList = this.airlineService.getUsers();
  }


}
