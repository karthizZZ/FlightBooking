
    export interface IBookingItem {
        bookingID: number;
        airlineID: number;
        flightNumber: string;
        airlineName: string;
        bookingDate: Date;
        mealType: string;
        noOfPassengers: number;
        email: string;
        seatType: string;
        pnr: string;
        paymentStatus?: any;
        isCancelled: boolean;
        createdUserID: number;
        createdDate: Date;
        passengerList?: any;
        bookedSeatList?: any;
        fromAirport?:string;

        toAirport?:string;

        FromLocation?:string;

        ToLocation?:string;
        ticketCost:number;
        tax:number;
    }



