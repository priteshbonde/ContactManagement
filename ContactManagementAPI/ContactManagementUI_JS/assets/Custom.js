var ApiUrl = 'http://localhost:49809/api/Contact/';
function contactList() {
    // Call Web API to get a list of Product
    $.ajax({
        url: ApiUrl,
        type: 'GET',
        dataType: 'json',
        success: function (Contacts) {
            contactListSuccess(Contacts);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function contactListSuccess(Contacts) {
    // Iterate over the collection of data
    $.each(Contacts, function (index, Contact) {
        // Add a row to the Product table
        contactAddRow(Contact);
    });
}

function contactAddRow(Contact) {
    // Check if <tbody> tag exists, add one if not
    if ($("#contactsTable tbody").length == 0) {
        $("#contactsTable").append("<tbody></tbody>");
    }
    // Append row to <table>
    $("#contactsTable tbody").append(
        contactBuildTableRow(Contact));
}

function contactBuildTableRow(Contact) {
    var ret =
        "<tr>" +
        "<td>" + Contact.ContactID + "</td>" +
        "<td>" + Contact.FirstName + " " + Contact.LastName + "</td>"
        + "<td>" + Contact.Email + "</td>"
        + "<td>" + Contact.PhoneNumber + "</td>"
        + "<td>" + Contact.Status + "</td>"
        + "<td>" + "<button type='button' " +
        "onclick='contactGet(this);' " +
        "class='btn btn-default' " +
        "data-id='" + Contact.ContactID + "' title='Edit Contact'>" +
        "<span class='glyphicon glyphicon-edit' />"
        + "</button>"
        + "<button type='button' " +
        "onclick='ChangecontactStatus(this);' " +
        "class='btn btn-default' " +
        "data-id='" + Contact.ContactID + "' title='Change Status'>" +
        "<span class='glyphicon glyphicon-check' />"
        + "</button>" + "</td>" +
        "</tr>";
    return ret;
}

function handleException(request, message,
    error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" +
            request.responseJSON.Message + "\n";
    }
    alert(msg);
}



function updateClick() {
    // Build product object from inputs
    Contact = new Object();
    Contact.FirstName = $("#FirstName").val();
    Contact.LastName = $("#LastName").val();
    Contact.Email = $("#Email").val();
    Contact.PhoneNumber = $("#PhoneNumber").val();
    Contact.Status = $("#Status").is(":checked");//.attr("checked");
    Contact.CreatedDate = new Date();

    contactAdd(Contact);

}

function contactAdd(_Contact) {
    $.ajax({
        url: ApiUrl,
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify(_Contact),
        success: function (Contact) {
            ContactAddSuccess(Contact);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function ContactAddSuccess(Contact) {
    contactAddRow(Contact);
    formClear();
}
function formClear() {
    $("#contactId").html(0);
    $("#FirstName").val("");
    $("#LastName").val("");
    $("#Email").val("");
    $("#PhoneNumber").val("");
    $("#Status").attr("checked", false);
    $('#modal-default').modal('hide');
}
function contactGet(editButton) {
    var contactId = $(editButton).data("id");
    $.ajax({
        url: ApiUrl + contactId,
        type: 'GET',
        dataType: 'json',
        success: function (Contact) {
            contactToFields(Contact);
            $('#modal-default').modal('show');

        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function ChangecontactStatus(changeButton) {
    var contactId = $(changeButton).data("id");
    $.ajax({
        url: ApiUrl +"/Delete?id=" + contactId,
        type: 'POST',
        //dataType: 'json',
        contentType: "application/json",
        success: function (Contact) {
            $("#contactsTable").empty();
            contactList();
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function contactToFields(Contact) {

    $("#contactId").html(Contact.ContactID);
    $("#FirstName").val(Contact.FirstName);
    $("#LastName").val(Contact.LastName);
    $("#Email").val(Contact.Email);
    $("#PhoneNumber").val(Contact.PhoneNumber);
    $("#Status").attr("checked", Contact.Status);
    //$("#modal-default").toggle();
    //$('#modal-default').modal('show');
}

function onSearchClick() {
    var searchString = $("#txtSearch").val();
    $.ajax({
        url: ApiUrl + "?searchString=" + searchString,
        type: 'GET',
        contentType: "application/json",
        success: function (Contacts) {
            $("#contactsTable > tbody").html("");
            contactListSuccess(Contacts);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}