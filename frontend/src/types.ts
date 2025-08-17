export enum ListItemStatus{
    Todo,
    Done
}

export interface User {
  id: string;
  name: string;
}

export interface List {
  id: string;
  name: string;
}

export interface ListItem {
  id: string;
  title: string;
  status: ListItemStatus
  listId: string
}

export interface UpdateStatusRequest {
    id: string
    status: ListItemStatus
}