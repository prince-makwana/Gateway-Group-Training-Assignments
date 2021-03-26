import { Branch } from './branch.model';

describe('Branch.Model', () => {
  it('should create a Branch instance', () => {
    expect(new Branch(1, "ABC", "XYZ")).toBeTruthy();
  });
});
