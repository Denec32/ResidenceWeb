import { Component, OnInit } from '@angular/core';
import { House } from '../models/house';
import { ResidenceService } from '../residence.service';

@Component({
  selector: 'app-houses-list',
  templateUrl: './houses-list.component.html',
  styleUrls: ['./houses-list.component.css']
})
export class HousesListComponent implements OnInit {
  public houses: House[] = [];


  constructor(private residenceService: ResidenceService) { 
    this.getHouses();
  }

  getHouses() {
    this.residenceService.getHouses()
      .subscribe(houses => this.houses = houses)
  }

  ngOnInit(): void {
  }

}
