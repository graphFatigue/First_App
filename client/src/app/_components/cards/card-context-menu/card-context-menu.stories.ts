import { Meta, StoryObj, applicationConfig } from "@storybook/angular";
import { HttpClientModule } from "@angular/common/http";
import { importProvidersFrom } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { boardReducer } from "src/app/store/boards/board.reducer";
import { StoreModule } from "@ngrx/store";
import { listsReducer } from "src/app/store/lists/lists.reducer";
import { cardReducer } from "src/app/store/cards/card.reducer";
import { CardContextMenuComponent } from "./card-context-menu.component";

const decorators = [
    applicationConfig({
      providers: [importProvidersFrom(HttpClientModule), importProvidersFrom(MatDialogModule), 
        importProvidersFrom(StoreModule.forRoot({id: boardReducer, lists: listsReducer, card: cardReducer})) ]
    })
  ];

export default {
    title: 'Components/cardContextMenu',
    component: CardContextMenuComponent,
    tags: ['autodocs'],
    decorators: decorators
} as Meta<CardContextMenuComponent>;

type CardContextMenuComponentStory = StoryObj<CardContextMenuComponent>;
export const CardContextMenu: CardContextMenuComponentStory = {
    args: {
    }
};