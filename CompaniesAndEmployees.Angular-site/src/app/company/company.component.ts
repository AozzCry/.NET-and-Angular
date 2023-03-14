import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CompanyService } from '../company.service';
import { Company, CompanyVm } from '../models';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss'],
})
export class CompanyComponent {
  list: Company[] = [];

  constructor(private companyService: CompanyService) {}

  ngOnInit(): void {
    this.companyService.getAll().subscribe((received) => {
      this.list = received;
    });
  }

  addSubmit(formItem: NgForm): void {
    formItem.value.published = new Date(formItem.value.published);

    this.companyService
      .addNew(formItem.value as CompanyVm)
      .subscribe((added) => {
        this.list.push(added);
      });
  }
}
