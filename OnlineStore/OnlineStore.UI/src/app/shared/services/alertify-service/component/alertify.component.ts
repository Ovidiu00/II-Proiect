import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AlertifyService } from '../alertify.service';

@Component({
  selector: 'app-alertify',
  templateUrl: './alertify.component.html',
  styleUrls: ['./alertify.component.css']
})
export class AlertifyComponent implements OnInit {


  message$:Observable<string>;
  constructor(private alertifyService:AlertifyService) { }

  ngOnInit(): void {
    this.message$ = this.alertifyService.message$;
  }

}
