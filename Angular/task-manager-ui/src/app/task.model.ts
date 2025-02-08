export interface Task {
  id: number;
  name: string;
  description: string;
  deadline: string;
  imageUrl?: string;
  isFavorite: boolean;
  status: string;  // ToDo, InProgress, Done
}
