import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public Add(num1: number, num2:number){
    return num1 + num2;
  }

  public Subtract(num1: number, num2:number){
    return num1 - num2;
  }

  public Multiply(num1: number, num2:number){
    return num1 * num2;
  }

  public Divide(num1: number, num2:number){
    return num1 / num2;
  }

  public Square(num: number){
    return num * num;
  }
}
