export interface Todo {
  id: string;
  title: string;
  description?: string | null;
  dueDate?: string | null;
  isCompleted: boolean;
  createdAt: string;
  updatedAt?: string | null;
}
