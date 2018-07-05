import { Component, OnInit, ElementRef, ViewChild, ViewContainerRef} from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Contact } from '../contact.model';
import { ContactService } from '../services/contact.service';
import * as $ from 'jquery';
//import { ModalDialogService } from 'ngx-modal-dialog';
//import * from '@type/bootstrap';
@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    userClaims: any;
    contacts: Contact[] = [];
    contact: Contact = new Contact();
    searchString: string;
    ModalTitle: string;
    IsPopupVisible: boolean = false;
    private element: JQuery;
    itemsPerPage: number = 5;
    @ViewChild('modaldefault') myModal: ElementRef;
    constructor(private router: Router,
                private userService: AuthService,
                private contactservice: ContactService,
                private el: ElementRef) {
        
    }

    ngOnInit() {
        this.contactservice.getContacts().subscribe(t => { this.contacts = t })
        this.ModalTitle = "Add Contact";
        this.element = $('modal-default');
        
    }
   
    Logout() {
        localStorage.removeItem('userToken');
        this.router.navigate(['/login']);
    }

    savePatient()
    {
        this.contactservice.postContact(this.contact)
            .subscribe(data => {
                this.contactservice.getContacts().subscribe(t => { this.contacts = t })
                alert('New Record Added Succcessfully');
            });
        this.IsPopupVisible = false;
        this.close();
    }
    onChangeStatusClick(ContactId)
    {
        this.contactservice.changeContactStatus(ContactId)
            .subscribe(data => {
                this.contactservice.getContacts().subscribe(t => { this.contacts = t })
                alert('Status Changed Succcessfully');
            })
    }
    onEditPatientClick(contact)
    {
        this.ModalTitle = "Edit Contact";
        this.contact = contact;
        this.IsPopupVisible = true;
        //this.open()
    }
    onSearchChange()
    {
        this.contacts.filter(t => t.FirstName.startsWith(this.searchString)
            || t.LastName.startsWith(this.searchString));
    }

    onAddPatientClick()
    {
        this.contact = new Contact();
        this.ModalTitle = "Add Contact";
        this.IsPopupVisible = true;
       // this.open()
    }
    //open(content) {
    //    this.contact = new Contact();
    //    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
    //       // this.closeResult = `Closed with: ${result}`;
    //    }, (reason) => {
    //      //  this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    //    });
    //}
    //open(): void {
    //    //this.myModal.nativeElement.show();
    //    //$('body').addClass('modal-open');
    //    //jQuery(this.myModal.nativeElement).modal('show');
    //    this.element.show();
     
    //}

    // close modal
    close(): void {
        //this.myModal.nativeElement.hide();
        //this.element.hide();
        //$("#modal-default").modal("hide");
        //$('body').removeClass('modal-open');
        //jQuery(this.myModal.nativeElement).modal('show');
    }
}
