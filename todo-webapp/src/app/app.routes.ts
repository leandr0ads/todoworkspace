import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { TodoListComponent } from './features/todos/todo-list/todo-list.component';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'todos', component: TodoListComponent },
      { path: '', redirectTo: 'todos', pathMatch: 'full' }
    ]
  }
];
