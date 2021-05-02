
import { Injectable } from "@angular/core";
import {MatDialog} from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';
import { Observable } from "rxjs";
import { ResponseSnackbar } from "./enum";
import { ConfirmDeleteComponent } from "./messages/confirm-delete/confirm-delete.component";

@Injectable()
export class Util {
    constructor(private snackBar: MatSnackBar,public dialog: MatDialog) { }

    openSnackBar(message: string, action: ResponseSnackbar): void {
        let dur = action == (ResponseSnackbar.Error || ResponseSnackbar.Pending) ? -1 : 2000;
        this.snackBar.open(message, action.toString(), {
            duration: dur,
        });
    }

    confirmDelete(): Observable<any> {
        let dialogRef = this.dialog.open(ConfirmDeleteComponent, {
          width: '500px'
        });
        return dialogRef.afterClosed();
      }

      getEnumArray(enumObj: any) {
        return Object.keys(enumObj).map(function (type) {
          return enumObj[type];
        });
      }
      
}