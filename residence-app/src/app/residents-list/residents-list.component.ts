import { Component, OnInit } from '@angular/core';
import { ResidenceService } from '../residence.service';
import { Resident } from '../models/resident';

@Component({
  selector: 'app-residents-list',
  templateUrl: './residents-list.component.html',
  styleUrls: ['./residents-list.component.css']
})
export class ResidentsListComponent implements OnInit {
  public residents: Resident[] = [];

  constructor(private residenceService: ResidenceService) { 
    this.getResidents();
  }

  getResidents() {
    this.residenceService.getResidents()
      .subscribe(residents => this.residents = residents)
  }

  ngOnInit(): void {
  }

}
