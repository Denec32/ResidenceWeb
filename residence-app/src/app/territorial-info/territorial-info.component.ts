import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Territory } from '../models/territory';
import { ResidenceService } from '../residence.service';

@Component({
  selector: 'app-territorial-info',
  templateUrl: './territorial-info.component.html',
  styleUrls: ['./territorial-info.component.css']
})
export class TerritorialInfoComponent implements OnInit {

  public territories: Territory[] = [];
  address = new FormControl('');

  constructor(private residenceService: ResidenceService) { 
    
  }

  getTerritorialInfo() {
    this.residenceService.getTerritorialInfo(this.address.value)
      .subscribe(territories => this.territories = territories)
  }

  ngOnInit(): void {
  }

}
