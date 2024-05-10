import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './_components/home/home.component';
import { ActionsSidebarComponent } from './_components/actions/actions-sidebar/actions-sidebar.component';
import { BoardListComponent } from './_components/boards/board-list/board-list.component';
import { BoardComponent } from './_components/boards/board/board.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'boards', component: BoardListComponent},
  {path: 'boards/:id', component: BoardComponent},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
  {path: 'actions', component: ActionsSidebarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
