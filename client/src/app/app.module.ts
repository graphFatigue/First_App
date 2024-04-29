import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { CardComponent } from './cards/card/card.component';
import { ListCardsComponent } from './lists-cards/list-cards/list-cards.component';
import { NavComponent } from './nav/nav.component';
import { ActionsSidebarComponent } from './actions/actions-sidebar/actions-sidebar.component';
import { FormsModule } from '@angular/forms';
import { EditCardModalWindowComponent } from './cards/edit-card-modal-window/edit-card-modal-window.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardComponent,
    ListCardsComponent,
    NavComponent,
    ActionsSidebarComponent,
    EditCardModalWindowComponent
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
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
