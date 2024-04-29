import { Component, OnInit } from '@angular/core';
import { ActionModel } from 'src/app/_models/action/actionModel';
import { ActionsService } from 'src/app/_services/actions.service';

@Component({
  selector: 'app-actions-sidebar',
  templateUrl: './actions-sidebar.component.html',
  styleUrls: ['./actions-sidebar.component.css']
})
export class ActionsSidebarComponent implements OnInit{
  actions : ActionModel[] = []

  constructor(private actionsService: ActionsService){}

  ngOnInit(): void {
    this.getActions();
  }

  getActions(){
    this.actionsService.getActions().subscribe({
      next: response => this.actions = response.items
    })
  }

}
