import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'status',
  standalone: true
})
export class StatusPipe implements PipeTransform {
  transform(value: boolean) {
    return value ? '✅ Concluída' : '⏳ Pendente';
  }
}
