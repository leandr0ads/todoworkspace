import { AbstractControl, ValidationErrors } from "@angular/forms";

export function validDate(control: AbstractControl): ValidationErrors | null {
  const value = control.value;
  if (!value) return null;

  const parsed = new Date(value);
  if (isNaN(parsed.getTime())) {
    return { invalidDate: true };
  }

  return null;
}
