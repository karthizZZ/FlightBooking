import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AirlineService } from '../../service/airline.service';
@Component({
  selector: 'app-add-airline',
  templateUrl: './add-airline.component.html',
  styleUrls: ['./add-airline.component.css']
})
export class AddAirlineComponent implements OnInit {

  id: number = 0;
  airlineform: UntypedFormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fb: UntypedFormBuilder,
    private airlineService: AirlineService
  ) {
    this.airlineform = this.fb.group({
      airlineName: ['', [Validators.required]],
      airlineLogo: ['', [Validators.required]],
      contactNumber: ['', [Validators.required]],
      contactAddress: ['', [Validators.required]],
      airlineID:[0,[Validators.required]],
      isBlocked: [false],
    });

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = params['id'];
      if (params['id'] != null) {
        this.airlineform.get('airlineID')?.setValue(params['id']);
        this.airlineService.getUsersByID(this.id).subscribe(
          (data:any) => {       
            if(data.result != null){
              console.log(data.result);
              this.airlineform.setValue(data.result);
            }
          },
          err => {
            console.log(err);
          }
        );
        // if (data) {
        // }
      }
    });
  }

  save() {
    if (this.airlineform.invalid) // true if any form validation fail
      return
    console.log(this.airlineform.value)
    if (this.airlineform.get('airlineID')?.value === 0) {
      // on Create New User
      this.airlineService.addUser(this.airlineform.value).subscribe(
        data => {       
          console.log(data);
        },
        err => {
          console.log(err);
        }
      );
    } else {
      // on Update User info
      this.airlineService.updateUser(this.airlineform.value).subscribe(
        data => {       
          console.log(data);
        },
        err => {
          console.log(err);
        }
      );
    }

    //Redirecting to user List page after save or update
    this.router.navigate(['/airline']);
  }

}
