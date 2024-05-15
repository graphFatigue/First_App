import { Meta, StoryObj, applicationConfig } from '@storybook/angular';
import { HttpClientModule } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef,
} from '@angular/material/dialog';
import { boardReducer } from 'src/app/store/boards/board.reducer';
import { StoreModule } from '@ngrx/store';
import { listsReducer } from 'src/app/store/lists/lists.reducer';
import { cardReducer } from 'src/app/store/cards/card.reducer';
import { DeleteCardModalWindowComponent } from './delete-card-modal-window.component';
import { MatButtonModule } from '@angular/material/button';

const decorators = [
  applicationConfig({
    providers: [
      { provide: MatDialogRef, useValue: {} },
      { provide: MAT_DIALOG_DATA, useValue: {} },
      importProvidersFrom(HttpClientModule),
      importProvidersFrom(MatDialogModule),
      importProvidersFrom(MatButtonModule),
      importProvidersFrom(MatDialogRef),
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
  title: 'Components/deleteModalCard',
  component: DeleteCardModalWindowComponent,
  tags: ['autodocs'],
  decorators: decorators,
} as Meta<DeleteCardModalWindowComponent>;

type DeleteCardModalWindowComponentStory =
  StoryObj<DeleteCardModalWindowComponent>;
export const Card: DeleteCardModalWindowComponentStory = {
  args: {},
};
