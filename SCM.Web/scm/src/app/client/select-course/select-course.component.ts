import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ICourse } from 'src/app/model/course';
import { ICourseBasket } from 'src/app/model/courseBasket';
import { IUser } from 'src/app/model/user';
import { DataService } from 'src/app/service/data/data.service';
import { ResponseSnackbar } from 'src/app/shared/enum';
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

  userURL: string = "http://localhost/api/User";
  courseURL: string = "http://localhost:90/api/Course";
  courseBasketAddURL:string = "http://localhost:120/api/CoursesBasket";

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
    this._dataService.get(this.userURL).subscribe(x => this.users = x.userList);
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
    //seletedCourses.forEach(x => this.basket.totalPrice += x?.price!);
    seletedCourses.forEach(x => this.basket.items.push(x!));
    debugger;
  this._dataService.put(this.courseBasketAddURL,this.basket).subscribe(
    data => {
      if (data > 0) //Success
      {
        this._util.openSnackBar("Successfully upated the course!", ResponseSnackbar.Sucess);
      }
      else {
        this._util.openSnackBar(JSON.stringify(data), ResponseSnackbar.Error);
      }
    },
    error => {
    });
  }
}