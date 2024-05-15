import { Meta, StoryObj, applicationConfig } from "@storybook/angular";
import { HttpClientModule } from "@angular/common/http";
import { importProvidersFrom } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { EditCardModalWindowComponent } from "./edit-card-modal-window.component";

const decorators = [
    applicationConfig({
      providers: [
        {provide: MatDialogRef,
        useValue:{}},
        {provide: MAT_DIALOG_DATA, useValue: {} },
        importProvidersFrom(HttpClientModule), importProvidersFrom(MatDialogModule)]
    })
  ];

export default {
    title: 'Components/editModalCard',
    component: EditCardModalWindowComponent,
    tags: ['autodocs'],
    decorators: decorators
} as Meta<EditCardModalWindowComponent>;

type EditCardModalWindowComponentStory = StoryObj<EditCardModalWindowComponent>;
export const EditCardModalWindow: EditCardModalWindowComponentStory = {
    args: {
        cardModel: {name: "name", description:"description", priority:"Low", dueDate: new Date().toString(), listCardsName:"Planned", id: 2}
    }
};