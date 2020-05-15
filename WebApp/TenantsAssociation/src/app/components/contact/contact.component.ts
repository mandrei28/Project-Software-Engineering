import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { YourAccountService } from 'src/app/services/your-account.service';

@Component({
  selector: 'app-services',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss'],
})
export class ContactComponent implements OnInit {
  constructor(private yourAccountService: YourAccountService) {}

  ngOnInit(): void {}
  sendMessage(message: string) {
    this.yourAccountService.sendMessage(message);
  }
}
