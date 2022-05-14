import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject } from 'rxjs';
import { AlertifyComponent } from './component/alertify.component';

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor(private snackbar:MatSnackBar) { }

  private messagesSubject:BehaviorSubject<string> = new BehaviorSubject<string>('');
  public message$ = this.messagesSubject.asObservable();

  private durationInSeconds = 2.5;

  public success(message:string,durationInSeconds:number = this.durationInSeconds){
    this.messagesSubject.next(message);

    this.snackbar.openFromComponent(AlertifyComponent, {
      duration: durationInSeconds* 1000,
      panelClass: ['base-snackbar','green-snackbar']
    });
  }

  public error(message:string,durationInSeconds:number = this.durationInSeconds){
    this.messagesSubject.next(message);

    this.snackbar.openFromComponent(AlertifyComponent, {
      duration: durationInSeconds* 1000,
      panelClass: ['base-snackbar','red-snackbar']
    });
  }


}
