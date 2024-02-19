import { Component, OnInit } from '@angular/core';
import { Journey } from '../model/journey';
import { Flight } from '../model/flight';
import { FligthService } from '../services/fligth.service';

@Component({
  selector: 'app-search-fligth',
  templateUrl: './search-fligth.component.html',
  styleUrls: ['./search-fligth.component.css']
})
export class SearchFligthComponent implements OnInit {

  journey : Journey = new Journey();
  flightList : Flight[] = [];

  constructor(private fligthService:FligthService) { }

  ngOnInit(): void {
  }

  searchFlight(){
    this.fligthService.getFlights(this.journey).subscribe(result => {
      if (result !== null){
        this.flightList = result.flights;
      }
    });
  }

  canShowTable(){
    return this.flightList.length >0;
  }

}
