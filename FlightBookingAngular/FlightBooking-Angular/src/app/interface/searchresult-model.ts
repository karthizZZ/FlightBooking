export interface ISearchResult {
    airlineScheduleID: number;
    airlineID: number;
    airlineName: string;
    flightName: string;
    flightNumber: string;
    fromAirport: string;
    toAirport: string;
    startTime: Date;
    reachTime: Date;
    airlineLogo: string;
    mealsAvailable: string;
    ticketPrice: number;
    tax: number;
}