import { Component, OnInit } from '@angular/core';
import { EmptyHouse } from '../models/empty-house';
import { ResidenceService } from '../residence.service';

@Component({
  selector: 'app-empty-houses-list',
  templateUrl: './empty-houses-list.component.html',
  styleUrls: ['./empty-houses-list.component.css']
})
export class EmptyHousesListComponent implements OnInit {
  public emptyHouses: EmptyHouse[] = [];


  constructor(private residenceService: ResidenceService) { 
    this.getEmptyHouses();
  }

  getEmptyHouses() {
    this.residenceService.getEmptyHouses()
      .subscribe(houses => this.emptyHouses = houses)
  }

  ngOnInit(): void {
  }
}
