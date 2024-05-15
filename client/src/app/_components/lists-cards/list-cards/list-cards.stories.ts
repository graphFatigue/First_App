import { Meta, StoryObj, applicationConfig } from '@storybook/angular';
import { HttpClientModule } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { MatDialogModule } from '@angular/material/dialog';
import { boardReducer } from 'src/app/store/boards/board.reducer';
import { StoreModule } from '@ngrx/store';
import { listsReducer } from 'src/app/store/lists/lists.reducer';
import { cardReducer } from 'src/app/store/cards/card.reducer';
import { ListCardsComponent } from './list-cards.component';
import { CardComponent } from '../../cards/card/card.component';

const decorators = [
  applicationConfig({
    providers: [
      importProvidersFrom(HttpClientModule),
      importProvidersFrom(CardComponent),
      importProvidersFrom(MatDialogModule),
      importProvidersFrom(
        StoreModule.forRoot({
          id: boardReducer,
          lists: listsReducer,
          card: cardReducer,
        }),
      ),
    ],
  }),
];

export default {
  title: 'Components/listCards',
  component: ListCardsComponent,
  tags: ['autodocs'],
  decorators: decorators,
} as Meta<ListCardsComponent>;

type ListCardsComponentStory = StoryObj<ListCardsComponent>;
export const ListCards: ListCardsComponentStory = {
  args: {
    listCards: {
      name: 'Planned',
      boardId: 1,
      id: 2,
      cards: [
        {
          name: 'card 1',
          boardId: 1,
          actions: [],
          description: 'description 1',
          priority: 'Low',
          dueDate: new Date().toString(),
          listCardsName: 'Planned',
          id: 2,
        },
        {
          name: 'card 2',
          boardId: 1,
          actions: [],
          description: 'description 2',
          priority: 'Medium',
          dueDate: new Date().toString(),
          listCardsName: 'Planned',
          id: 3,
        },
        {
          name: 'card 3',
          boardId: 1,
          actions: [],
          description: 'description 3',
          priority: 'Low',
          dueDate: new Date().toString(),
          listCardsName: 'Planned',
          id: 4,
        },
        {
          name: 'card 4',
          boardId: 1,
          actions: [],
          description: 'description 4',
          priority: 'High',
          dueDate: new Date().toString(),
          listCardsName: 'Planned',
          id: 5,
        },
      ],
    },
  },
};
