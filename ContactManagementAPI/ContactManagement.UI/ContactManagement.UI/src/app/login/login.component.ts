import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "../services/auth.service"
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    email: string;
    password: string;
    isLoginError: boolean = false;
    constructor(private router: Router, private authservice: AuthService) { }
    ngOnInit() {
    }
    OnSubmit(UserName, Password) {
        this.authservice.userAuthentication(UserName, Password).subscribe((data: any) => {
            localStorage.setItem('userToken', data.access_token);
            this.router.navigate(['/home']);
        },
            (err: HttpErrorResponse) => {
                this.isLoginError = true;
            });
    }

}
