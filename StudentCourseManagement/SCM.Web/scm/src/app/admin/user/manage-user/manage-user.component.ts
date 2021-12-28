import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { IUser } from 'src/app/model/user';
import { ISelectValue } from 'src/app/model/selectValue';
import { DataService } from 'src/app/service/data/data.service';
import { DBOperation, ResponseSnackbar } from 'src/app/shared/enum';
import { Util } from 'src/app/shared/util';

@Component({
  selector: 'app-manage-user',
  templateUrl: './manage-user.component.html',
  styleUrls: ['./manage-user.component.css']
})

export class ManageUserComponent implements OnInit {

  dbops: DBOperation = 1;
  modalTitle!: string;
  modalBtnTitle!: string;
  selectedOption!: string;
  user!: IUser;

  userFrm!: FormGroup;
  POST_URL: string = "http://localhost:130/User";
  RST_URL: string = "http://localhost:130/User/id";

  constructor(private _fb: FormBuilder, private _dataService: DataService, private _util: Util, public dialogRef: MatDialogRef<ManageUserComponent>) { }

  states: ISelectValue[] = [
    { value: 'AL', viewValue: 'Alabama' },
    { value: 'AK', viewValue: 'Alaska' },
    { value: 'AS', viewValue: 'American Samoa' },
    { value: 'AZ', viewValue: 'Arizona' },
    { value: 'AR', viewValue: 'Arkansas' },
    { value: 'CA', viewValue: 'California' }
  ];

  countries: ISelectValue[] = [
    { value: 'US', viewValue: 'United States' },
    { value: 'CA', viewValue: 'Canada' },
  ];

  gender: ISelectValue[] = [
    { value: 'M', viewValue: 'Male' },
    { value: 'F', viewValue: 'Female' },
  ];

  ngOnInit(): void {
    this.userFrm = this._fb.group({
    userID: [''],
    salutation: [''],
    firstName: [''],
    lastName: [''],
    dob: [''],
    age: [''],
    gender: [''],
    emailAddress: [''],
    phoneNumber: [''],
    city: [''],
    state: [''],
    zip: [''],
    country: ['']
    });

    if (this.dbops != DBOperation.create)
      this.userFrm.setValue(this.user);

    if (this.dbops == DBOperation.delete)
      this.userFrm.disable();

      if (this.dbops == DBOperation.update)
      {
       this.userFrm.controls["firstName"].disable();
       this.userFrm.controls["lastName"].disable();
       this.userFrm.controls["dob"].disable();
       this.userFrm.controls["gender"].disable();
       this.userFrm.controls["emailAddress"].disable();
      }

  }

  onSubmit(formData: any) {
    switch (this.dbops) {
      case DBOperation.create:
        delete formData.value._id;
        this._dataService.post(this.POST_URL, formData.value).subscribe(
          data => {
            if (data > 0) //Success
            {
              this._util.openSnackBar("Successfully added the user!", ResponseSnackbar.Sucess);
              this.dialogRef.close();
            }
            else {
              this._util.openSnackBar(JSON.stringify(data), ResponseSnackbar.Error);
            }
          },
          error => {
          });
        break;
      case DBOperation.update:
        this._dataService.put(this.POST_URL, formData.value).subscribe(
          data => {
            if (data > 0) //Success
            {
              this._util.openSnackBar("Successfully upated the user!", ResponseSnackbar.Sucess);
              this.dialogRef.close();
            }
            else {
              this._util.openSnackBar(JSON.stringify(data), ResponseSnackbar.Error);
            }
          },
          error => {
          });
        break;
      case DBOperation.delete:
        this._util.confirmDelete().subscribe(result => {
          if (<boolean>result == true) {
            this._dataService.delete(this.RST_URL.replace("id", formData.value.userID)).subscribe(
              data => {
                if (<boolean>data == true) //Success
                {
                  this._util.openSnackBar("Successfully deleted the user!", ResponseSnackbar.Sucess);
                  this.dialogRef.close();
                }
                else {
                  this._util.openSnackBar(JSON.stringify(data), ResponseSnackbar.Error);
                }
              },
              error => {
              });
          }
        });
        break;
    }

  }
}