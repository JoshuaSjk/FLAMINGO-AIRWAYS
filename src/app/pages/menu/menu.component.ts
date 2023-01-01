import { Component, OnInit } from '@angular/core';
import { SearchFlightDetailsService } from 'src/app/services/search-flight-details.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})

export class MenuComponent implements OnInit{
  
  constructor(private service: SearchFlightDetailsService){}

  origin: string = '';
  destination: string = '';
  departureDate: string = '';
  Flights: any

  ngOnInit(): void{
    this.Flights=this.service;
  }

  bookTicket(flight: any) {
    // Perform booking process for the given flight
    console.log(`Booking ticket for flight ${flight.flightNumber}`);
  }

  searchFlights() {
  }
  

}
