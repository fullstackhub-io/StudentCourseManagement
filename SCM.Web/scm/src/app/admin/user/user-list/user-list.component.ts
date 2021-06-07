import { Component, ViewChild, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge, of as observableOf } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { IUser } from 'src/app/model/user';
import { DataService } from 'src/app/service/data/data.service';
import { DBOperation } from 'src/app/shared/enum';
import { ManageUserComponent } from '../manage-user/manage-user.component';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})

// firstName: String,
// lastName: String,
// dob: Date,
// age: number,
// gender: String,
// emailAddress: String,
// phoneNumber: String,
// city: String,
// state: String,
// zip: String,
// country: String

export class UserListComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'age','gender','emailAddress','address', 'edit', 'delete'];
  filteredAndPagedIssues: any = [];

  resultsLength: number = 0;
  isLoadingResults: boolean = true;;
  isRateLimitReached: boolean = false;

  dbops: DBOperation = 1;
  modalTitle!: string;
  modalBtnTitle!: string;
  user:any;

  GET_URL:string = "http://localhost:130/User";

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  constructor(private _dataService: DataService, private dialog: MatDialog) { }


  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.filteredAndPagedIssues = merge()
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoadingResults = true;
          return this._dataService.get(this.GET_URL);
        }),
        map(data => {
          // Flip flag to show that loading has finished.
          this.isLoadingResults = false;
          this.isRateLimitReached = false;
          this.resultsLength = data.userList.length;
          return data.userList;
        }),
        catchError(() => {
          this.isLoadingResults = false;
          // Catch if the GitHub API has reached its rate limit. Return empty data.
          this.isRateLimitReached = true;
          return observableOf([]);
        })
      );
  }

  resetPaging(): void {
    this.paginator.pageIndex = 0;
  }


  public gridaction(actn: DBOperation, row: any): void {

    switch (actn) {
      case DBOperation.create:
        this.addCourse();
        break;
      case DBOperation.update:
        this.editCourse(row);
        break;
      case DBOperation.delete:
        this.deleteCourse(row);
        break;
    }
  }

     addCourse() {
      this.dbops = DBOperation.create;
      this.modalTitle = "Add New User";
      this.modalBtnTitle = "Add";
      this.openDialog();
    }
     editCourse(user: IUser) {
      this.dbops = DBOperation.update;
      this.modalTitle = "Edit User";
      this.modalBtnTitle = "Update";
      this.user = user;
      this.openDialog();
    }
     deleteCourse(user: IUser) {
      this.dbops = DBOperation.delete;
      this.modalTitle = "Confirm to Delete?";
      this.modalBtnTitle = "Delete";
      this.user = user;
      this.openDialog();
    }

    openDialog() {
      let dialogRef = this.dialog.open(ManageUserComponent);
      dialogRef.componentInstance.dbops = this.dbops;
      dialogRef.componentInstance.modalTitle = this.modalTitle;
      dialogRef.componentInstance.modalBtnTitle = this.modalBtnTitle;
      dialogRef.componentInstance.user = this.user;
  
      dialogRef.afterClosed().subscribe(() => {
        this.loadData();
      });
    }
  }