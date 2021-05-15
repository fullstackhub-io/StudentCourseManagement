import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SCMMaterialModule } from './material-module';
import { AdminComponent } from './admin/admin/admin.component';
import { ManageCourseComponent } from './admin/course/manage-course/manage-course.component';
import { CourseListComponent } from './admin/course/course-list/course-list.component';
import { UserListComponent } from './admin/user/user-list/user-list.component';
import { ManageUserComponent } from './admin/user/manage-user/manage-user.component';
import { ConfirmDeleteComponent } from './shared/messages/confirm-delete/confirm-delete.component';
import { HttpClientModule } from '@angular/common/http';
import { DataService } from './service/data/data.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Util } from './shared/util';


@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    ManageCourseComponent,
    CourseListComponent,
    UserListComponent,
    ManageUserComponent,
    ConfirmDeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SCMMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [DataService,Util],
  bootstrap: [AppComponent],
  entryComponents: [ManageCourseComponent]
})
export class AppModule { }
