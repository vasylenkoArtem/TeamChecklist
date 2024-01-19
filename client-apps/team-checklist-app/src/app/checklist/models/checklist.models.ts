export interface ChecklistDto {
    id: string;
    completedDate?: Date | null;
    status: CheckListStatus; 
    items: ChecklistItemDto[]; 
}

export interface ChecklistItemDto {
    id: string;
    textDescription: string;
    status: ChecklistItemStatus;
    completedBy?: string | null;
}

export enum ChecklistItemStatus {
    ToDo,
    Done
}

export enum CheckListStatus {
    ToDo,
    InProgress,
    Done
}