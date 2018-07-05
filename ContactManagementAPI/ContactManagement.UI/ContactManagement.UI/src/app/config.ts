export class config {
    private baseUrl: string = 'http://localhost:49809/';
    public gettoken: string = this.baseUrl + 'api/token';
    public GetContactsUrl: string = this.baseUrl + 'api/contact';
    public changeContactStatusUrl: string = this.baseUrl + 'api/contact';
}
