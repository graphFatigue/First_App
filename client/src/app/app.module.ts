import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './_components/home/home.component';
import { CardComponent } from './_components/cards/card/card.component';
import { ListCardsComponent } from './_components/lists-cards/list-cards/list-cards.component';
import { NavComponent } from './_components/nav/nav.component';
import { ActionsSidebarComponent } from './_components/actions/actions-sidebar/actions-sidebar.component';
import { FormsModule } from '@angular/forms';
import { EditCardModalWindowComponent } from './_components/cards/edit-card-modal-window/edit-card-modal-window.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import {ButtonModule} from 'primeng/button';
import { ContextMenuModule } from 'primeng/contextmenu';
import { ContextMenuComponent } from './_components/cards/context-menu/context-menu.component';
import { CreateCardModalWindowComponent } from './_components/cards/create-card-modal-window/create-card-modal-window.component';
import { DeleteCardModalWindowComponent } from './_components/cards/delete-card-modal-window/delete-card-modal-window.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardComponent,
    ListCardsComponent,
    NavComponent,
    ActionsSidebarComponent,
    EditCardModalWindowComponent,
    ContextMenuComponent,
    CreateCardModalWindowComponent,
    DeleteCardModalWindowComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    TooltipModule.forRoot(),
    MatButtonModule,
    MatDialogModule,
    ContextMenuModule,
    ButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
