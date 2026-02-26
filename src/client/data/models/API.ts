export interface TodoItemDTO {
    id: number;
    todoCollectionId: number;
    createdByUserId: number;
    text: string;
    createdOn: string;
    isCompleted: boolean;
    isDeleted: boolean;
}

export interface TodoCollectionDTO {
    id: number;
    createdByUserId: number;
    name?: string;
    createdOn?: string;
    isCompleted: boolean;
    isDeleted: boolean;
    todoItems: TodoItemDTO[];
}