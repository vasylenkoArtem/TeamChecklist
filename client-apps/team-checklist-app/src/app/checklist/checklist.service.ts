import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ChecklistDto, ChecklistItemDto, ChecklistType } from './models/checklist.models';
import { ApiService } from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class ChecklistService {
  private baseUrl = 'checklists';

  private _checklist = new BehaviorSubject<ChecklistDto>({} as ChecklistDto);
  public readonly checklist$: Observable<ChecklistDto> = this._checklist.asObservable();
  private _isLoading = new BehaviorSubject<boolean>(false);
  public readonly isLoading$: Observable<boolean> = this._isLoading.asObservable();

  constructor(private apiService: ApiService) { }

  resetChecklist() {
    this._checklist.next({} as ChecklistDto);
  }

  public getCheckList(typeId: ChecklistType) {
    this._isLoading.next(true);
    let query = this.apiService.get<ChecklistDto>(`${this.baseUrl}/${typeId}`)
    query.subscribe(data => {
      this._checklist.next(data);
      this._isLoading.next(false);
    });
  }

  public resetChecklists(typeId: ChecklistType) {
    this._isLoading.next(true);
    let query = this.apiService.post<ChecklistDto>(`${this.baseUrl}/${typeId}/reset`, null);
    query.subscribe(_ => {
      this._isLoading.next(false);
      this.getCheckList(ChecklistType.Morning)
    });
  }

  public markItemAsDone(checklistId: string, itemId: string) {
    this._isLoading.next(true);
    let query = this.apiService.post<ChecklistItemDto>(`${this.baseUrl}/${checklistId}/item/${itemId}/mark-as-done`, null);
    query.subscribe(data => {
      let currentChecklist = this._checklist.getValue();
      let itemToUpdate = currentChecklist.items.find(i => i.id === itemId);
      if (itemToUpdate) {
        itemToUpdate.status = data.status;
        itemToUpdate.completedBy = data.completedBy;
      }
      this._checklist.next(currentChecklist);

      this._isLoading.next(false);

      this.getCheckList(ChecklistType.Morning)
    });
  }
}
