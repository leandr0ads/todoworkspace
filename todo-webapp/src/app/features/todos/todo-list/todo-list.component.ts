import { Component, OnInit, inject, signal, computed } from '@angular/core';
import { NgFor, NgIf, DatePipe } from '@angular/common';
import { TodoService } from '../../../shared/services/todo.service';
import { Todo } from '../../../shared/models/todo.model';
import { StatusPipe } from '../../../shared/pipes/status.pipe';
import { TodoFormComponent } from '../todo-form/todo-form.component';
import { ToastsComponent } from '../../../shared/elements/toast/toast.component';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [NgFor, NgIf, DatePipe, StatusPipe, TodoFormComponent, ToastsComponent],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css'
})
export class TodoListComponent implements OnInit {

  private api = inject(TodoService);
  todos = signal<Todo[]>([]);
  selected = signal<Todo | null>(null);
  showAddModal = signal(false);
  showConfirmDelete = signal(false);

  selectedSet = signal<Set<string>>(new Set());


  selectedCount = computed(() => this.selectedSet().size);
  selectAllChecked = computed(() => {
  return this.selectedCount() > 0 && this.selectedCount() === this.todos().length;
});
  showConfirmBulkDelete = signal(false);
  
  ngOnInit() { this.load(); }

  load() {
    this.api.list().subscribe(data => {
      this.todos.set(data);
      this.selectedSet.set(new Set());
    });
  }

  toggleSelect(id: string, checked: boolean) {
    const s = new Set(this.selectedSet());
    if (checked) s.add(id);
    else s.delete(id);
    this.selectedSet.set(s);
  }

  toggleSelectAll(checked: boolean) {
  const s = new Set<string>();

  if (checked) {
    this.todos().forEach(t => s.add(t.id));
  }

  this.selectedSet.set(s);
}

  openConfirmBulkDelete() {
  this.showConfirmBulkDelete.set(true);
}

deleteSelectedBulkConfirmed() {
  const ids = [...this.selectedSet()];
  ids.forEach(id => {
    this.api.delete(id).subscribe(() => {
      this.load();
    });
  });

  ToastsComponent.show("Selecionados removidos!");
  this.closeModals();
}

  openAdd() { this.showAddModal.set(true); }
  seeDetails(todo: Todo) { this.selected.set(todo); }

  closeModals() {
  this.selected.set(null);
  this.showAddModal.set(false);
  this.showConfirmDelete.set(false);
  this.showConfirmBulkDelete.set(false);
  }

  create(data: any) {
    this.api.create(data).subscribe(() => {
      ToastsComponent.show("Criado!");
      this.load();
      this.closeModals();
    });
  }

  confirmDelete() { this.showConfirmDelete.set(true); }

  deleteSelected() {
    const t = this.selected();
    if (!t) return;

    this.api.delete(t.id).subscribe(() => {
      ToastsComponent.show("Removido!");
      this.load();
      this.closeModals();
    });
  }

  toggle(t: Todo) {
    this.api.toggle(t.id, !t.isCompleted).subscribe(() => {
      ToastsComponent.show("Atualizado!");
      this.load();
    });
  }
}
