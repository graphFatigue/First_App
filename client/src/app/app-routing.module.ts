import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './_components/home/home.component';
import { ListCardsComponent } from './_components/lists-cards/list-cards/list-cards.component';
import { ActionsSidebarComponent } from './_components/actions/actions-sidebar/actions-sidebar.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
  {path: 'list-cards/:id', component: ListCardsComponent},
  {path: 'actions', component: ActionsSidebarComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
