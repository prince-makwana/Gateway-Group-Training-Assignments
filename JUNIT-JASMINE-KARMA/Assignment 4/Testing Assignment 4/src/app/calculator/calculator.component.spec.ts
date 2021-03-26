import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculatorComponent } from './calculator.component';

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalculatorComponent ]
    })
    .compileComponents();

    component = new CalculatorComponent();
  });

  afterEach(() => {
    component = null;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Addition', () => {
    let num1 = 2;
    let num2 = 3;

    let result = component.Add(num1, num2);
    expect(result).toEqual(5);
  });

  it('Addition', () => {
    let num1 = 2;
    let num2 = 3;

    let result = component.Add(num1, num2);
    expect(result).toEqual(5);
  });

  it('Addition', () => {
    let num1 = 2;
    let num2 = 3;

    let result = component.Add(num1, num2);
    expect(result).toEqual(5);
  });

  it('Subtraction', () => {
    let num1 = 10;
    let num2 = 5;

    let result = component.Subtract(num1, num2);
    expect(result).toEqual(5);
  });

  it('Multiplication', () => {
    let num1 = 2;
    let num2 = 3;

    let result = component.Multiply(num1, num2);
    expect(result).toEqual(6);
  });

  it('Division', () => {
    let num1 = 10;
    let num2 = 5;

    let result = component.Divide(num1, num2);
    expect(result).toEqual(2);
  });

});
