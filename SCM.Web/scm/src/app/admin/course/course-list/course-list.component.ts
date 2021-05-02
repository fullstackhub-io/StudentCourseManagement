import {HttpClient} from '@angular/common/http';
import {Component, ViewChild, AfterViewInit, OnInit} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {merge, Observable, of as observableOf} from 'rxjs';
import {catchError, map, startWith, switchMap} from 'rxjs/operators';
import { DataService } from 'src/app/service/data/data.service';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit { 
  
displayedColumns: string[] = ['courseID', 'courseName', 'courseShortName', 'creditHour'];
filteredAndPagedIssues:any=[];

resultsLength:number = 0;
isLoadingResults:boolean = true;;
isRateLimitReached:boolean = false;


  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

constructor(private _httpClient: HttpClient, private _dataService:DataService) {}


ngOnInit() {
  this.filteredAndPagedIssues = merge()
    .pipe(
      startWith({}),
      switchMap(() => {
        this.isLoadingResults = true;
        return this._dataService.get("http://localhost:90/api/Course");
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
}