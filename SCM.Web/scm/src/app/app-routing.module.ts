import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseListComponent } from './admin/course/course-list/course-list.component';
import { UserListComponent } from './admin/user/user-list/user-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path:'home',
    component: UserListComponent
  },
  {
    path:'admin/managemenu',
    component: CourseListComponent
  },
  {
    path:'admin/usermsg',
    component:UserListComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
