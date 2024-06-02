import { Component } from '@angular/core';

export interface FormField {
  label: string;
  validate(): boolean;
}

@Component({
  selector: 'app-util',
  templateUrl: './util.component.html',
  styleUrl: './util.component.css'
})
export class UtilComponent {
  static validateFormFields(fields: FormField[]) {
    return fields.map(f => f.validate()).includes(false);
  }
}
