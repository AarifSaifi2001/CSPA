import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';

import { CarDetailsComponent } from './Car/car-list/car-details/car-details.component';
import { CarListComponent } from './Car/car-list/car-list.component';
import { ListCarComponent } from './Car/car-list/list-car/list-car.component';
import { NavComponent } from './nav/nav.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CarService } from './Services/car.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserLoginComponent } from './User/user-login/user-login.component';
import { UserRegisterComponent } from './User/user-register/user-register.component';
import { AlertifyService } from './Services/alertify.service';
import { UserService } from './Services/user.service';
import { AuthService } from './Services/auth.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { from } from 'rxjs';
import { CarCardComponent } from './Car/car-list/car-card/car-card.component';
import { CommonModule } from '@angular/common';
import { NgxGalleryImage, NgxGalleryModule } from '@kolkov/ngx-gallery';
import { HttpErrorInterceptorService } from './Services/HttpErrorInterceptor.service';
import { PhotoEditorComponent } from './Car/photo-editor/photo-editor.component';
import { FileUploadModule } from 'ng2-file-upload';
import { UserCarsComponent } from './Car/car-list/user-cars/user-cars.component';
import { UserProfileComponent } from './User/user-profile/user-profile.component';
import { ChangePasswordComponent } from './User/change-password/change-password.component';

const appRoute: Routes = [

  {path:'', component: CarListComponent},
  {path:'rent-car', component: CarListComponent},
  {path:'list-car', component: ListCarComponent},
  {path: 'car-details/:id', component: CarDetailsComponent},
  {path: 'user-register', component: UserRegisterComponent},
  {path: 'user-login', component: UserLoginComponent},
  {path: 'user-cars', component: UserCarsComponent},
  {path: 'user-profile', component: UserProfileComponent},
  {path: 'change-password', component: ChangePasswordComponent}
]
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    CarListComponent,
    CarCardComponent,
    ListCarComponent,
    CarDetailsComponent,
    UserRegisterComponent,
    UserLoginComponent,
    PhotoEditorComponent,
    UserCarsComponent,
    UserProfileComponent,
    ChangePasswordComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoute),
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    CommonModule,
    NgxGalleryModule,
    FileUploadModule,
    // AgmCoreModule.forRoot({
    //   apiKey: 'AIzaSyB6aJNvCuJa8RGSL1_eBjDHULCw7Cbs09'
    // })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi: true
    },
    CarService, AlertifyService, UserService, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
