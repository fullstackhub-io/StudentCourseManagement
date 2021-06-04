import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { merge } from 'rxjs';
import { startWith, switchMap, map, catchError } from 'rxjs/operators';
import { IBoughtCourse } from 'src/app/model/BoughtCourses';
import { ICourse } from 'src/app/model/course';
import { ICourseBasket } from 'src/app/model/courseBasket';
import { ICourseBasketVM } from 'src/app/model/courseBasketVM';
import { IUser } from 'src/app/model/user';
import { DataService } from 'src/app/service/data/data.service';
import { DBOperation, ResponseSnackbar } from 'src/app/shared/enum';
import { Util } from 'src/app/shared/util';

@Component({
  selector: 'app-select-course',
  templateUrl: './select-course.component.html',
  styleUrls: ['./select-course.component.css']
})
export class SelectCourseComponent implements OnInit {

  users: IUser[] = [];
  courses: ICourse[] = [];
  basket: ICourseBasket = {
    items: [],
    totalPrice: 0,
    userEmail: ''
  };
  basketVM: any = [];
  userEmails: String[] = [];
  displayedColumns: string[] = ['userEmail', 'subjects', 'totalPrice', 'delete'];

  resultsLength: number = 0;
  isLoadingResults: boolean = true;;
  isRateLimitReached: boolean = false;

  dbops: DBOperation = 1;
  modalTitle!: string;
  modalBtnTitle!: string;

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  sort!: MatSort;

  userURL: string = "http://localhost/api/User";
  courseURL: string = "http://localhost:90/api/Course";
  courseBaskeURL: string = "http://localhost:120/api/CoursesBasket";
  courseGetAllBasketURL: string = "http://localhost:120/api/CoursesBasket/GetAll";
  coursePurchaseURL: string = "http://localhost:100/api/StudentCourse";

  selectCourse!: FormGroup;

  constructor(private _fb: FormBuilder, private _dataService: DataService, private _util: Util) { }

  ngOnInit(): void {
    this.loadUsers();
    this.loadCourses();

    this.selectCourse = this._fb.group({
      user: [''],
      course: ['']
    });
  }

  private loadUsers() {
    this._dataService.get(this.userURL).subscribe(x => {
      this.users = x.userList;
      this.users.forEach(x => this.userEmails.push(x.emailAddress));
      this.loadCartData();
    });
  }

  private loadCourses() {
    this._dataService.get(this.courseURL).subscribe(x => this.courses = x.courseList);
  }

  onSubmit(formData: any) {
    let courseIDs: number[] = formData.value.course;
    let userID = formData.value.user;
    let user = this.users.find(x => x.userID == userID);
    let seletedCourses: (ICourse | undefined)[] = [];
    courseIDs.forEach(x => seletedCourses.push(this.courses.find(y => y.courseID == x)));
    this.basket.userEmail = user?.emailAddress!;
    seletedCourses.forEach(x => this.basket.items.push(x!));
    this._dataService.put(this.courseBaskeURL, this.basket).subscribe(
      data => {
        if (data == true)
        {
          this.loadCartData();
          this._util.openSnackBar("Successfully added the course to cart!", ResponseSnackbar.Sucess);
        }
        else {
          this._util.openSnackBar(JSON.stringify(data), ResponseSnackbar.Error);
        }
      },
      error => {
      });
  }

  loadCartData() {
    this.basketVM = merge()
    .pipe(
      startWith({}),
      switchMap(() => {
        this.isLoadingResults = true;
        return this._dataService.post(this.courseGetAllBasketURL, this.userEmails);
      }),
      map(data => {
        this.resetBasket();
        this.isLoadingResults = false;
        this.isRateLimitReached = false;
        this.resultsLength = data.length;
        return data;
      }),
      catchError(() => {
        this.isLoadingResults = false;
        this.isRateLimitReached = true;
        return observableOf([]);
      })
    );
  }

  buyCourse(){
    debugger;
    let courseBasket:ICourseBasketVM[]=[];
    let courses:IBoughtCourse[]=[];
    this._dataService.post(this.courseGetAllBasketURL, this.userEmails).subscribe(res =>
      {
        courseBasket = res;
       courseBasket.forEach(b => courses.push({Address:this.users.find(x=>x.emailAddress==b.userEmail)?.city
                                                                      +"|"+this.users.find(x=>x.emailAddress==b.userEmail)?.state
                                                                      +"|"+this.users.find(x=>x.emailAddress==b.userEmail)?.zip
                                                                      +"|"+this.users.find(x=>x.emailAddress==b.userEmail)?.country??"",
                                               EmailAddress:b.userEmail,
                                               FirstName:this.users.find(x=>x.emailAddress==b.userEmail)?.firstName??"",
                                               LastName:this.users.find(x=>x.emailAddress==b.userEmail)?.lastName??"",
                                               PhoneNumber:this.users.find(x=>x.emailAddress==b.userEmail)?.phoneNumber??"",
                                               Subjects:b.subjects,
                                               TotalPrice:b.totalPrice}))
       debugger
       
        this._dataService.post(this.coursePurchaseURL,courses).subscribe(x=>alert(JSON.stringify(x)));
      });
  }

  resetPaging(): void {
    this.paginator.pageIndex = 0;
  }

  resetBasket()
  {
    this.basket.items = [],
    this.basket.totalPrice = 0,
    this.basket.userEmail = '';
  }

  public gridaction(row: any): void {
    this._dataService.delete(this.courseBaskeURL+"/"+row.userEmail).subscribe(
      data => {
        if (<boolean>data == true) //Success
        {
          this.loadCartData();
          this._util.openSnackBar("Successfully deleted the course from basket!", ResponseSnackbar.Sucess);
        }
        else {
          this._util.openSnackBar(JSON.stringify(data), ResponseSnackbar.Error);
        }
      },
      error => {
      });
  }
}

function observableOf(arg0: never[]): any {
  throw new Error('Function not implemented.');
}
