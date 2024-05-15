import { Meta, StoryObj, applicationConfig } from "@storybook/angular";
import { HttpClientModule } from "@angular/common/http";
import { importProvidersFrom } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { boardReducer } from "src/app/store/boards/board.reducer";
import { StoreModule } from "@ngrx/store";
import { listsReducer } from "src/app/store/lists/lists.reducer";
import { cardReducer } from "src/app/store/cards/card.reducer";
import { ViewCardModalWindowComponent } from "./view-card-modal-window.component";

const decorators = [
    applicationConfig({
      providers: [
        {provide: MatDialogRef,
        useValue:{}},
        {provide: MAT_DIALOG_DATA, useValue: {} },
        importProvidersFrom(HttpClientModule), importProvidersFrom(MatDialogModule), importProvidersFrom(MatDialogRef),
        importProvidersFrom(StoreModule.forRoot({id: boardReducer, lists: listsReducer, card: cardReducer}))]
    })
  ];

export default {
    title: 'Components/modalCard',
    component: ViewCardModalWindowComponent,
    tags: ['autodocs'],
    decorators: decorators
} as Meta<ViewCardModalWindowComponent>;

type ViewCardModalWindowComponentStory = StoryObj<ViewCardModalWindowComponent>;
export const ViewCardModalWindow: ViewCardModalWindowComponentStory = {
    args: {
        card: {name: "name", boardId:2, actions:[], description:"description", priority:"Low", dueDate: new Date().toString(), listCardsName:"Planned", id: 2}
    }
};