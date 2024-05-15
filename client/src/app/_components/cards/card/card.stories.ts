import { Meta, StoryObj, applicationConfig } from "@storybook/angular";
import { CardComponent } from "./card.component";
import { HttpClientModule } from "@angular/common/http";
import { importProvidersFrom } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { boardReducer } from "src/app/store/boards/board.reducer";
import { StoreModule } from "@ngrx/store";
import { listsReducer } from "src/app/store/lists/lists.reducer";
import { cardReducer } from "src/app/store/cards/card.reducer";

const decorators = [
    applicationConfig({
      providers: [importProvidersFrom(HttpClientModule), importProvidersFrom(MatDialogModule), 
        importProvidersFrom(StoreModule.forRoot({id: boardReducer, lists: listsReducer, card: cardReducer})) ]
    })
  ];

export default {
    title: 'Components/card',
    component: CardComponent,
    tags: ['autodocs'],
    decorators: decorators
} as Meta<CardComponent>;

type CardComponentStory = StoryObj<CardComponent>;
export const Card: CardComponentStory = {
    args: {
        card: {name: "name", boardId:2, actions:[], description:"description", priority:"Low", dueDate: new Date().toString(), listCardsName:"Planned", id: 2},
        listsCards:[
            {name: "List 1", boardId:1, id: 2, cards:[]},
            {name: "List 2", boardId:1, id: 3, cards:[]},
            {name: "List 4", boardId:1, id: 4, cards:[]},
        ]
    }
};