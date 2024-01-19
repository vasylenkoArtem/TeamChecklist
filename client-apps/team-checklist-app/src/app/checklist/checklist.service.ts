import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChecklistDto } from './models/checklist.models';
import { ApiService } from '../api/api.service';

@Injectable({
    providedIn: 'root'
})
export class ChecklistService {
    private baseUrl = 'checklists';

    constructor(private apiService: ApiService) { }

    public getCheckList(typeId: ChecklistType): Observable<ChecklistDto> {
        return this.apiService.get<ChecklistDto>(`${this.baseUrl}/${typeId}`);
    }

    public resetChecklist(typeId: ChecklistType): Observable<ChecklistDto> {
        return this.apiService.post<ChecklistDto>(`${this.baseUrl}/${typeId}/reset`, null);
    }

    public markItemAsDone(checklistId: string, itemId: string): Observable<ChecklistDto> {
        return this.apiService.post<ChecklistDto>(`${this.baseUrl}/${checklistId}/item/${itemId}/mark-as-done`, null);
    }
}

export enum ChecklistType {
    Unknown,
    Morning
}
