import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { validDate } from '../../../shared/utility/date.validator';

@Component({
  selector: 'app-todo-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './todo-form.component.html',
  styleUrl: './todo-form.component.css'
})
export class TodoFormComponent {
    private fb = new FormBuilder();

    @Output() saved = new EventEmitter<any>();

    form = this.fb.group({
      title: ['', Validators.required],
      description: [''],
      dueDate: ['', validDate]
    });

  submit() {
    if (this.form.invalid) {
      alert("Título é obrigatório!");
      return;
    }

    const { title, description, dueDate } = this.form.value;

    if (!description) {
      const r = confirm("Descrição está vazia. Deseja continuar mesmo assim?");
      if (!r) return;
    }

    if (!dueDate) {
      const r = confirm("Data não foi informada. Deseja continuar mesmo assim?");
      if (!r) return;
    }

    this.saved.emit(this.form.value);
    this.form.reset();
  }
}
