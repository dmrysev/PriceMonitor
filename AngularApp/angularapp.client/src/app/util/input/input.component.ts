import { FormField } from '../util.component';
import { Component, Input } from '@angular/core';

export class InputField implements FormField {
  isRequired = true;
  label = "";

  name = "";
  value = "";
  validationSuccessful = true;
  validationError = "";
  inputClass = "";

  constructor(label: string, isRequired = true) {
    this.name = label.replace(" ", "");
    this.label = isRequired ? label + "*" : label;
    this.isRequired = isRequired;
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

  inputChanged() {
    this.resetValidation();
  }

  validate() {
    this.resetValidation();
    if (this.isRequired && this.value.length == 0) {
      this.setValidationError("Required field");
      return false;
    }
    return true;
  }
}

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css', '../../app.component.css']
})
export class InputComponent {
  @Input() inputField = new InputField("");
}
