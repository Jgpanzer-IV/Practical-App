import { Component, OnInit } from '@angular/core';
import { timeInterval } from 'rxjs';

@Component({
  selector: 'app-secret-point',
  templateUrl: './secret-point.component.html',
  styleUrls: ['./secret-point.component.css'],
})
export class SecretPointComponent implements OnInit {
  showSecret: boolean = false;
  accessRecording = Array();

  secretMessage = 'My Password!!!';

  constructor() {}

  ngOnInit(): void {}

  onPrivateAccess() {
    this.showSecret = true;
    this.accessRecording.push(new Date());
    setTimeout(() => {
      this.showSecret = false;
    }, 2000);
  }
}
