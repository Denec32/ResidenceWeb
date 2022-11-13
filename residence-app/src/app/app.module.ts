import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {HttpClientModule} from '@angular/common/http';
import { ResidentsListComponent } from './residents-list/residents-list.component';
import { HousesListComponent } from './houses-list/houses-list.component';
import { EmptyHousesListComponent } from './empty-houses-list/empty-houses-list.component';
import { TerritorialInfoComponent } from './territorial-info/territorial-info.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    ResidentsListComponent,
    HousesListComponent,
    EmptyHousesListComponent,
    TerritorialInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
