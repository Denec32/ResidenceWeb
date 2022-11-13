import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmptyHousesListComponent } from './empty-houses-list/empty-houses-list.component';
import { HousesListComponent } from './houses-list/houses-list.component';
import { ResidentsListComponent } from './residents-list/residents-list.component';
import { TerritorialInfoComponent } from './territorial-info/territorial-info.component';

const routes: Routes = [
  {path: 'residents', component: ResidentsListComponent},
  {path: '', component: ResidentsListComponent},
  {path: 'houses', component: HousesListComponent},
  {path: 'empty-houses', component: EmptyHousesListComponent},
  {path: 'territory', component: TerritorialInfoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
