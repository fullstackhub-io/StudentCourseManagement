import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ICourse } from 'src/app/model/course';
import { DataService } from 'src/app/service/data/data.service';
import { DBOperation, ResponseSnackbar } from 'src/app/shared/enum';
import { Util } from 'src/app/shared/util';

@Component({
  selector: 'app-manage-course',
  templateUrl: './manage-course.component.html',
  styleUrls: ['./manage-course.component.css']
})
export class ManageCourseComponent implements OnInit {

  dbops: DBOperation = 1;
  modalTitle!: string;
  modalBtnTitle!: string;
  selectedOption!: string;
  course!: ICourse;

  courseFrm!: FormGroup;
  POST_URL: string = "http://localhost:90/api/Course";
  RST_URL: string = "http://localhost:90/api/Course/id";
  GET_ALL_URL: string = "http://localhost:90/api/Course"

  constructor(private _fb: FormBuilder, private _dataService: DataService, private _util: Util, public dialogRef: MatDialogRef<ManageCourseComponent>) { }

  ngOnInit(): void {
    this.courseFrm = this._fb.group({
      courseID: [''],
      courseName: ['', [Validators.required, Validators.maxLength(50)]],
      courseShortName: ['', [Validators.required, Validators.maxLength(50)]],
      creditHour: [''],
      price: [''],
      dateAdded: [''],
      dateUpdated: ['']
    });

    if (this.dbops != DBOperation.create)
      this.courseFrm.setValue(this.course);

    if (this.dbops == DBOperation.delete)
      this.courseFrm.disable();

    /*  if (this.dbops == DBOperation.update)
       this.courseFrm.controls["MenuCode"].disable(); */

  }

  onSubmit(formData: any) {
    switch (this.dbops) {
      case DBOperation.create:
        delete formData.value._id;
        this._dataService.post(this.POST_URL, formData.value).subscribe(
          data => {
            if (data > 0) //Success
            {
              this._util.openSnackBar("Successfully added the course!", ResponseSnackbar.Sucess);
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
              this._util.openSnackBar("Successfully upated the course!", ResponseSnackbar.Sucess);
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
            this._dataService.delete(this.RST_URL.replace("id", formData.value.courseID)).subscribe(
              data => {
                if (<boolean>data == true) //Success
                {
                  this._util.openSnackBar("Successfully deleted the course!", ResponseSnackbar.Sucess);
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