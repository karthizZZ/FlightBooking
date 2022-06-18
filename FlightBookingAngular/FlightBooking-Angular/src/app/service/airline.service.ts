import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IAirline } from '../interface/airline-model';

const airline_Api = 'https://localhost:5050/api/airline/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AirlineService {

private airlineList: IAirline[] = [] ;

constructor(private http: HttpClient) {}
getUsers() {
  return this.http.get(airline_Api + 'Get' , httpOptions);
  // this.http.get('https://localhost:44345/api/airline/Get').subscribe(
  //     (response:any)=>{
  //       this.airlineList = response.result;
  //       console.log(this.airlineList);
  //     },error=>{
  //       console.log(error);
  //     }
  //   );
  //   return this.airlineList
}
getUsersByID(id: number) {
    return this.http.get(airline_Api + 'Get/'+id , httpOptions)
    // return this.airlineList.find(x => x.airlineID == id)
}
addUser(airline: IAirline) {
  airline.contactNumber = airline.contactNumber.toString();
  return this.http.post(airline_Api + 'Add',airline , httpOptions);
}
updateUser(airline: IAirline) {
    // const airlineIndex = this.airlineList.findIndex(x => x.airlineID == airline.airlineID);
    // if (airlineIndex != null && airlineIndex != undefined) {
    //     this.airlineList[airlineIndex] = airline;
    // }
    airline.contactNumber = airline.contactNumber.toString();
    return this.http.put(airline_Api + 'Update',airline , httpOptions);

}
removeUser(id: number) {
    this.airlineList = this.airlineList.filter(x => x.airlineID != id);
}
}
