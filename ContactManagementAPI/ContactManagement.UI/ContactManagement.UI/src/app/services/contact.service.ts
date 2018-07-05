import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { config } from '../config';
import { Contact } from '../contact.model';

@Injectable()
export class ContactService {

    constructor(private _http: Http) { }
    _config: config = new config();;
    getContacts(): Observable<Contact[]> {
        return this._http.get(this._config.GetContactsUrl)
            .map((result: Response) => <Contact[]>result.json())
            // .catch((error:any)=> this.handleerror)
            ;
    }

    postContact(contact: Contact) {
        var body = JSON.stringify(contact);
        var headerOptions = new Headers({ 'Content-Type': 'application/json' });
        var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
        return this._http.post(this._config.GetContactsUrl, body, requestOptions);
    }

    changeContactStatus(contactId: number)
    {
        var body = JSON.stringify(contactId);
        var headerOptions = new Headers({ 'Content-Type': 'application/json' });
        var requestOptions = new RequestOptions({ method: RequestMethod.Post, headers: headerOptions });
        return this._http.post(this._config.changeContactStatusUrl + "/Delete?id=" + contactId, body, requestOptions);
    }
    handleerror() {

    }

}
