
    export interface IAirlineSchedule {
        airlineScheduleID: number;
        airlineID: number;
        flightNumber: string;
        flightName: string;
        fromLocation: number;
        toLocation: number;
        startTime: Date;
        endTime: Date;
        mealType: string;
        isDaily: boolean;
        isWeekdays: boolean;
        isWeekends: boolean;
        isSpecificDays: boolean;
    }

    export interface IAirlineSeatCostDetail {
        flightID: number;
        seatType: string;
        noOfSeats: number;
        ticketCost: number;
        tax: number;
    }

    export interface IAirlineScheduleDay {
        airlineScheduleID: number;
        weekDay: string;
    }

    export interface IAirlineScheduleBase {
        airlineSchedule: IAirlineSchedule;
        airlineSeatCostDetails: IAirlineSeatCostDetail[];
        airlineScheduleDays?: IAirlineScheduleDay[];
    }


