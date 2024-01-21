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
    ToDo = 'ToDo',
    Done = 'Done'
}

export enum CheckListStatus {
    ToDo = 'ToDo',
    InProgress = 'InProgress',
    Done = 'Done'
}

export enum ChecklistType {
    Unknown = 'Unknown',
    Morning = 'Morning'
}