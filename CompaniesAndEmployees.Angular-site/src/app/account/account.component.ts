import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from '../account.service';
import { UserLogin, UserRegister } from '../models';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss'],
})
export class AccountComponent {
  constructor(private accountService: AccountService) {}

  register(formItem: NgForm): void {
    this.accountService.register(formItem.value as UserRegister).subscribe();
  }

  login(formItem: NgForm): void {
    this.accountService.login(formItem.value as UserLogin).subscribe();
  }
}
