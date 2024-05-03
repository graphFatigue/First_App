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
  count:number=1

  constructor(private actionsService: ActionsService){}

  ngOnInit(): void {
    this.getActions();
  }

  getActions(){
    this.actionsService.getActions().subscribe({
      next: response => this.actions = response.items
    })
  }

  convertToLocalDate(responseDate: any) {
    try {
        if (responseDate != null) {
            var dt = new Date(responseDate)
            return String('on ' + dt.toUTCString().split(' ').slice(0,3).join(' ') + ' at ' + dt.toTimeString().split(' ')[0].split(':').slice(0,2).join(':'));
        } else {
            return null;
        }
    } catch (error) {
        return responseDate;
    }
}

}
