import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { config } from '../config';

@Injectable()
export class AuthService {

    constructor(private _http: HttpClient) { }
    _config: config = new config();
    userAuthentication(userName, password) {
        var data = "username=" + userName + "&password=" + password + "&grant_type=password";
        //var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
        return this._http.post(this._config.gettoken, data);
    }

}

