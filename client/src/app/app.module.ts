import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { HttpClientModule, provideHttpClient, withFetch} from '@angular/common/http';
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
import { CreateCardModalWindowComponent } from './_components/cards/create-card-modal-window/create-card-modal-window.component';
import { DeleteCardModalWindowComponent } from './_components/cards/delete-card-modal-window/delete-card-modal-window.component';
import { ListContextMenuComponent } from './_components/lists-cards/list-context-menu/list-context-menu.component';
import { CardContextMenuComponent } from './_components/cards/card-context-menu/card-context-menu.component';
import { EditListModalWindowComponent } from './_components/lists-cards/edit-list-modal-window/edit-list-modal-window.component';
import { DeleteListModalWindowComponent } from './_components/lists-cards/delete-list-modal-window/delete-list-modal-window.component';
import { CreateListCardsModalWindowComponent } from './_components/lists-cards/create-list-modal-window/create-list-modal-window.component';
import { ViewCardModalWindowComponent } from './_components/cards/view-card-modal-window/view-card-modal-window.component';
import { RouterModule } from '@angular/router';
import { BoardListComponent } from './_components/boards/board-list/board-list.component';
import { BoardComponent } from './_components/boards/board/board.component';
import { BoardContextMenuComponent } from './_components/boards/board-context-menu/board-context-menu.component';
import { CreateBoardModalWindowComponent } from './_components/boards/create-board-modal-window/create-board-modal-window.component';
import { DeleteBoardModalWindowComponent } from './_components/boards/delete-board-modal-window/delete-board-modal-window.component';
import { EditBoardModalWindowComponent } from './_components/boards/edit-board-modal-window/edit-board-modal-window.component';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { EffectsModule } from '@ngrx/effects';
import { ListsEffects } from './store/lists/lists.effects';
import { boardReducer } from './store/boards/board.reducer';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CardComponent,
    ListCardsComponent,
    NavComponent,
    ActionsSidebarComponent,
    EditCardModalWindowComponent,
    EditListModalWindowComponent,
    CardContextMenuComponent,
    CreateCardModalWindowComponent,
    CreateListCardsModalWindowComponent,
    DeleteCardModalWindowComponent,
    DeleteListModalWindowComponent,
    ListContextMenuComponent,
    ViewCardModalWindowComponent,
    BoardListComponent,
    BoardComponent,
    BoardContextMenuComponent,
    CreateBoardModalWindowComponent,
    DeleteBoardModalWindowComponent,
    EditBoardModalWindowComponent
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
    ButtonModule,
    StoreModule.forRoot({id: boardReducer}),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    EffectsModule.forRoot([ListsEffects])
  ],
  providers: [    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
