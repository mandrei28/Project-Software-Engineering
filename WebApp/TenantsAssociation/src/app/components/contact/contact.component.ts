import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-services',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss'],
})
export class ContactComponent implements OnInit {
  constructor(private userService: UserService) {}

  ngOnInit(): void {}
  sendMessage(message: string) {
    this.userService.sendMessage(message);
  }
}
