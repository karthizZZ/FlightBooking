
    export interface PassengerList {
        bookingRefNumber?: number;
        PassengerName: string;
        Gender: string;
        Age: number;
    }

    export interface BookedSeatList {
        refID?: number;
        BookingNumber?: number;
        SeatNumber: number;
    }

    export interface BookingDetails {
        id?: number;
        messageCreated?: Date;
        bookingID?: number;
        AirlineID: number;
        FlightNumber: number;
        AirlineName: string;
        BookingDate: Date;
        MealType: string;
        NoOfPassengers: number;
        Email: string;
        SeatType: string;
        pnr?: string;
        PaymentStatus?: string;
        IsCancelled?: boolean;
        CreatedUserID?: number;
        CreatedDate?: Date;
        FromAirport?:string;

        ToAirport?:string;

        FromLocation?:string;

        ToLocation?:string;
        ticketCost?:number;
        tax?:number;
        PassengerList: PassengerList[];
        BookedSeatList: BookedSeatList[];  
    }


