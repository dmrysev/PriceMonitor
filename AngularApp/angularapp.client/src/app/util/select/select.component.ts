import { FormField } from '../util.component';
import { Component, Input } from '@angular/core';

export class SelectField<Item, Value> implements FormField {
  isRequired = true;
  label = "";
  items: Item[] = [];
  selectedItem?: Value = undefined;

  name = "";
  validationSuccessful = true;
  validationError = "";
  inputClass = "";

  getValue: (item: Item) => Value;
  getViewName: (item: Item) => string;

  constructor(label: string, items: Item[], getValue: (item: Item) => Value, getViewName: (item: Item) => string, isRequired = true) {
    this.name = label.replace(" ", "");
    this.label = isRequired ? label + "*" : label;
    this.isRequired = isRequired;
    this.items = items;
    this.getValue = getValue;
    this.getViewName = getViewName;
  }

  resetValidation() {
    this.validationSuccessful = true;
    this.validationError = "";
    this.inputClass = "";
  }

  setValidationError(errorMessage: string) {
    this.validationSuccessful = false;
    this.validationError = errorMessage;
    this.inputClass = "error";
  }

  selectChanged() {
    this.resetValidation();
  }

  validate() {
    this.resetValidation();
    if (this.isRequired && this.selectedItem == undefined) {
      this.setValidationError("Required field");
      return false;
    }
    return true;
  }
}

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.css', '../../app.component.css']
})
export class SelectComponent {
  static emptySelectField() { return new SelectField<any, any>("", [], () => null, () => ""); }
  @Input() field = SelectComponent.emptySelectField();
}
