import { Meta, StoryObj, applicationConfig } from "@storybook/angular";
import { HttpClientModule } from "@angular/common/http";
import { importProvidersFrom } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { boardReducer } from "src/app/store/boards/board.reducer";
import { StoreModule } from "@ngrx/store";
import { listsReducer } from "src/app/store/lists/lists.reducer";
import { cardReducer } from "src/app/store/cards/card.reducer";
import { BoardComponent } from "./board.component";
import { ActivatedRoute } from "@angular/router";

const decorators = [
    applicationConfig({
      providers: [
        {provide: ActivatedRoute,
        useValue:{}},
        importProvidersFrom(HttpClientModule), importProvidersFrom(MatDialogModule), importProvidersFrom(ActivatedRoute),
        importProvidersFrom(StoreModule.forRoot({id: boardReducer, lists: listsReducer, card: cardReducer})) ]
    })
  ];

export default {
    title: 'Components/board',
    component: BoardComponent,
    tags: ['autodocs'],
    decorators: decorators
} as Meta<BoardComponent>;

type BoardComponentStory = StoryObj<BoardComponent>;
export const Board: BoardComponentStory = {
    args: {
        board: {id: 1, name: "My board", listsCards:[            
            {name: "Planned", boardId:1, id: 2, cards:[
            {name: "card 1", boardId:1, actions:[], description:"description 1", priority:"Low", dueDate: new Date().toString(), listCardsName:"Planned", id: 2},
            {name: "card 2", boardId:1, actions:[], description:"description 2", priority:"Medium", dueDate: new Date().toString(), listCardsName:"Planned", id: 3},
            {name: "card 3", boardId:1, actions:[], description:"description 3", priority:"Low", dueDate: new Date().toString(), listCardsName:"Planned", id: 4},
            {name: "card 4", boardId:1, actions:[], description:"description 4", priority:"High", dueDate: new Date().toString(), listCardsName:"Planned", id: 5},
        ]}], cards:[]}
    }
};