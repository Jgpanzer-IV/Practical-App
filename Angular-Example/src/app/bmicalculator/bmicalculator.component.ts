import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bmi-calculator',
  templateUrl: './bmicalculator.component.html',
  styleUrls: ['./bmicalculator.component.css'],
})
export class BMICalculatorComponent implements OnInit {
  weight: number = 0;
  height: number = 0;
  BMI: number = 0;

  age: number = 0;
  username: string;

  calculateable: boolean = false;
  completeMessage: string = '';

  constructor() {}

  ngOnInit(): void {}

  heightInput(event: any) {
    this.height = parseFloat((<HTMLInputElement>event.target).value);
  }

  weightInput(event: any) {
    this.weight = parseFloat((<HTMLInputElement>event.target).value);
  }

  onUpdateValue() {
    if (this.weight != 0 && this.height != 0) {
      this.BMI = this.weight / (this.height * this.height);
      if (this.username) {
        this.completeMessage =
          'Hello ' +
          this.username +
          ' Your BMI is ' +
          this.BMI +
          ' With your age at ' +
          this.age;
        this.calculateable = true;
      }
    }
  }

  clearValue() {
    this.username = '';
    this.weight = 0;
    this.height = 0;
    this.BMI = 0;
    this.age = 0;
    this.calculateable = false;
    this.completeMessage = '';
  }
}
