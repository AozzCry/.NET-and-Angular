import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EmployeeService } from '../employee.service';
import { Employee, EmployeeVm } from '../models';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent {
  list: Employee[] = [];
  pick: Employee | undefined;
  search: string | undefined;
  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.employeeService.getAll().subscribe((received) => {
      this.list = received;
    });
  }

  addSubmit(formItem: NgForm): void {
    this.employeeService
      .addNew(formItem.value as EmployeeVm)
      .subscribe((added) => {
        this.list.push(added);
      });
  }
  deleteSubmit(employeeId: number): void {
    this.employeeService.deleteById(employeeId).subscribe((deleted) => {
      this.list = this.list.filter(({ id }) => id !== deleted.id);
    });
  }
}
