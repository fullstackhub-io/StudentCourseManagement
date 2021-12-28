import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin/admin.component';
import { CourseListComponent } from './admin/course/course-list/course-list.component';
import { UserListComponent } from './admin/user/user-list/user-list.component';
import { SelectCourseComponent } from './client/select-course/select-course.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path:'home',
    component: AdminComponent
  },
  {
    path:'home/managecourse',
    component: CourseListComponent
  },
  {
    path:'home/manageuser',
    component:UserListComponent
  },
  {
    path:'home/usercourse',
    component:SelectCourseComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
