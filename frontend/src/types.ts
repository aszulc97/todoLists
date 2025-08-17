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
  status: boolean; //0 - todo; 1 - done
}
