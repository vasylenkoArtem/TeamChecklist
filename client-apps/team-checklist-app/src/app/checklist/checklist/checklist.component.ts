import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CheckListStatus, ChecklistDto, ChecklistItemStatus, ChecklistType } from '../models/checklist.models';
import { ChecklistService } from '../checklist.service';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'checklist',
  templateUrl: './checklist.component.html',
  styleUrls: ['./checklist.component.css']
})
export class ChecklistComponent implements OnInit, OnDestroy {
  title = "Morning Checklist"
  checklist$: Observable<ChecklistDto> | undefined;
  checklistSubscription: Subscription | undefined;
  checklist: ChecklistDto | undefined;
  isLoading = false;
  error: string | null = null;
  checklistStatusEnum = CheckListStatus;
  checklistItemStatus = ChecklistItemStatus;

  constructor(private checklistService: ChecklistService, private snackBar: MatSnackBar) {
    this.checklist$ = this.checklistService.checklist$;
  }
  ngOnDestroy(): void {
    this.checklistSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.getChecklist(ChecklistType.Morning);

    this.checklistSubscription = this.checklistService.checklist$.subscribe(
      (checklist) => {
        this.checklist = checklist;
        this.checkAndNotifyCompletion();
      }
    );
  }

  private checkAndNotifyCompletion(): void {
    console.log("checkAndNotifyCompletion", this.checklist)
    if (this.checklist && this.checklist.status === CheckListStatus.Done) {
      this.snackBar.open('You are good to go', 'Close', { duration: 3000 });
    }
  }

  resetChecklist() {
    this.checklistService.resetChecklists(ChecklistType.Morning);
  }

  private getChecklist(typeId: ChecklistType): void {
    this.checklistService.getCheckList(typeId);
  }

  markAsDone(checklistId: string, itemId: string): void {
    this.checklistService.markItemAsDone(checklistId, itemId);
  }
}
