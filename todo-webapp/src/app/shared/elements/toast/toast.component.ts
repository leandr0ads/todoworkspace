import { Component } from '@angular/core';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-toasts',
  standalone: true,
  imports: [NgFor],
  templateUrl: './toast.component.html',
  styleUrl: './toast.component.css'
})
export class ToastsComponent {

  static instance: ToastsComponent;
  messages: string[] = [];

  constructor() { ToastsComponent.instance = this; }

  static show(msg: string) {
    ToastsComponent.instance.messages.push(msg);
    setTimeout(() => {
      ToastsComponent.instance.messages.shift();
    }, 3000);
  }
}
