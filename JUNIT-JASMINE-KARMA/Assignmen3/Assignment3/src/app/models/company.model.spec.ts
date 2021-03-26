import { Company } from './company.model';

describe('Company.Model', () => {
  it('should create a Company instance', () => {
    expect(new Company(1, "ABC", "abc@gmail.com", 10, "XYZ", true, 1)).toBeTruthy();
  });
});
