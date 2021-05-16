import { Component, ViewChild, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge, of as observableOf } from 'rxjs';
import { catchError, map, startWith, switchMap } from 'rxjs/operators';
import { ICourse } from 'src/app/model/course';
import { DataService } from 'src/app/service/data/data.service';
import { DBOperation } from 'src/app/shared/enum';
import { ManageCourseComponent } from '../manage-course/manage-course.component';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  displayedColumns: string[] = ['courseName', 'courseShortName', 'creditHour', 'edit', 'delete'];
  filteredAndPagedIssues: any = [];

  resultsLength: number = 0;
  isLoadingResults: boolean = true;;
  isRateLimitReached: boolean = false;

  dbops: DBOperation = 1;
  modalTitle!: string;
  modalBtnTitle!: string;
  course:any;

  GET_URL:string = "http://localhost:90/api/Course";

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
          this.resultsLength = data.courseList.length;
          return data.courseList;
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
      this.modalTitle = "Add New Course";
      this.modalBtnTitle = "Add";
      this.openDialog();
    }
     editCourse(course: ICourse) {
      this.dbops = DBOperation.update;
      this.modalTitle = "Edit Course";
      this.modalBtnTitle = "Update";
      this.course = course;
      this.openDialog();
    }
     deleteCourse(course: ICourse) {
      this.dbops = DBOperation.delete;
      this.modalTitle = "Confirm to Delete?";
      this.modalBtnTitle = "Delete";
      this.course = course;
      this.openDialog();
    }

    openDialog() {
      let dialogRef = this.dialog.open(ManageCourseComponent);
      dialogRef.componentInstance.dbops = this.dbops;
      dialogRef.componentInstance.modalTitle = this.modalTitle;
      dialogRef.componentInstance.modalBtnTitle = this.modalBtnTitle;
      dialogRef.componentInstance.course = this.course;
  
      dialogRef.afterClosed().subscribe(() => {
        this.loadData();
      });
    }
  }