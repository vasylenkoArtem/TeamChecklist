import { Component, OnInit } from '@angular/core';
import { ChecklistService, ChecklistType } from './checklist/checklist.service';
import { ChecklistDto } from './checklist/models/checklist.models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'team-checklist-app';
  checklist: ChecklistDto | null = null;
  isLoading = false;
  error: string | null = null;

  constructor(private checklistService: ChecklistService) { }

  ngOnInit(): void {
    this.getChecklist(ChecklistType.Morning);
  }

  private getChecklist(typeId: ChecklistType): void {
    this.isLoading = true;
    this.checklistService.getCheckList(typeId).subscribe(
      data => {
        
        this.checklist = data;
        this.isLoading = false;
      },
      err => {
        console.log(err)
        this.error = err;
        this.isLoading = false;
      }
    );
  }
}
