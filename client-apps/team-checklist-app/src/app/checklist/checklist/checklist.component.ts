import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CheckListStatus, ChecklistDto, ChecklistItemStatus, ChecklistType } from '../models/checklist.models';
import { ChecklistService } from '../checklist.service';

@Component({
  selector: 'checklist',
  templateUrl: './checklist.component.html',
  styleUrls: ['./checklist.component.css']
})
export class ChecklistComponent implements OnInit {
  title = "Morning Checklist"
  checklist: ChecklistDto | null = null;
  isLoading = false;
  error: string | null = null;
  checklistEnum = CheckListStatus;
  checklistItemStatus = ChecklistItemStatus;

  constructor(private checklistService: ChecklistService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getChecklist(ChecklistType.Morning);
  }

  private checkAndNotifyCompletion(): void {
    console.log("checkAndNotifyCompletion", this.checklist)
    if (this.checklist && this.checklist.status === CheckListStatus.Done) {
      this.snackBar.open('You are good to go', 'Close', { duration: 3000 });
    }
  }

  resetChecklist() {
    this.isLoading = true;
    this.checklistService.resetChecklists(ChecklistType.Morning).subscribe(
      data => {
        this.getChecklist(ChecklistType.Morning)
        this.isLoading = false;
      },
      err => {
        this.error = 'Error fetching checklist: ' + err.message;
        this.isLoading = false;
      }
    );
  }

  private getChecklist(typeId: ChecklistType): void {
    this.isLoading = true;
    this.checklistService.getCheckList(typeId).subscribe(
      data => {
        this.checklist = data;
        this.isLoading = false;

        this.checkAndNotifyCompletion();
      },
      err => {
        this.error = 'Error fetching checklist: ' + err.message;
        this.isLoading = false;
      }
    );
  }

  markAsDone(checklistId: string, itemId: string): void {
    this.isLoading = true;
    this.checklistService.markItemAsDone(checklistId, itemId).subscribe(
      (checklistItem) => {
        if (this.checklist?.items) {
          const index = this.checklist.items.findIndex(x => x.id === checklistItem.id);
          if (index !== -1) {
            this.checklist.items[index] = checklistItem;
          }

          this.isLoading = false;

          this.getChecklist(ChecklistType.Morning);
        }

      },
      err => {
        this.error = 'Error marking item as done: ' + err.message;
        this.isLoading = false;
      }
    );
  }
}