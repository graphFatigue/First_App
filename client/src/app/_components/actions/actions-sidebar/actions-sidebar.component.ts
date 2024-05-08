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
  page: number = 1
  length: number = 0

  constructor(private actionsService: ActionsService){}

  ngOnInit(): void {
    this.loadActions();
  }

  loadActions(){
    this.actionsService.loadActionsWithNumPage(this.page).subscribe({
      next: response => {
        this.actions = this.actions.concat(response.items);
        this.length=response.totalCount;
      }
    })
    this.page+=1
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
