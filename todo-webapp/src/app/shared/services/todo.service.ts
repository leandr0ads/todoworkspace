import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Todo } from '../models/todo.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class TodoService {

  private http = inject(HttpClient);
  private base = 'https://localhost:7115/api/Todo';

  list(): Observable<Todo[]> {
    return this.http.get<Todo[]>(this.base);
  }

  create(data: any): Observable<Todo> {
    return this.http.post<Todo>(this.base, data);
  }

  delete(id: string) {
    return this.http.delete(`${this.base}/${id}`);
  }

  toggle(id: string, value: boolean) {
    return this.http.patch(`${this.base}/${id}/complete?completed=${value}`, {});
  }
}
