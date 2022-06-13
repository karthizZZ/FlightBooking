export interface ISearchInput {
    fromAirportID: number;
    toAirportID: number;
    travelDate: Date;
    returnDate: Date;
    isRoundTrip: boolean;
    seatType: string;
    noOfTickets: number;
}