import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { AuthService } from './services/auth.service';
import { ContactService } from './services/contact.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { FilterPipe } from './pipes/filter.pipe';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    
    {
        path: 'login', component: LoginComponent,
    },
    { path: '', redirectTo: '/login', pathMatch: 'full' }

];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
      FilterPipe
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ToastrModule.forRoot(),
      BrowserAnimationsModule,
      RouterModule.forRoot(appRoutes),
      HttpModule,
      NgxPaginationModule,
      //NgbModule.forRoot()
  ],
  providers: [AuthService,
      AuthGuard,
      ContactService
      ,
      {
          provide: HTTP_INTERCEPTORS,
          useClass: AuthInterceptor,
          multi: true
      }],
  bootstrap: [AppComponent]
})
export class AppModule { }
