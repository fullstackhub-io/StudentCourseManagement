import { Component, OnInit } from '@angular/core';
import { DBOperation } from 'src/app/shared/enum';

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
  course:any;

  constructor() { }

  ngOnInit(): void {
  }

}
