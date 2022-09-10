function logon() {
    $('#alert_s').fadeOut('fast');
    var username = $('#username').val();
    var password = $('#password').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Login/authenticate",
        data:JSON.stringify( {username: username, password:password}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
           // alert("You selected: " + response.AuthSuccess);
            if (response.AuthSuccess== true) {
              //  $('#alert_s').fadeOut('fast');
                location.href = "Home";
            } else {
                $('#msg').text( response.Message);
                $('#alert_s').fadeIn('fast');
                (function () {
                    $('#alert_s').fadeOut('fast');
                }, 1000);
                    
               
            }
        
        }

    });
}

function resetPassword() {
    $('#alert_s').fadeOut('fast');
    $('#alert_L').fadeOut('fast');
    var user = $('#username1').val();
    var code = $('#code').val();
    var password1 = $('#password01').val();
    var password2 = $('#password02').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Login/changepassword",
        data:JSON.stringify({username: user, otp:code,password1:password1, password2:password2}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // alert("You selected: " + response.AuthSuccess);
            if (response.AuthSuccess == true) {
                //  $('#alert_s').fadeOut('fast');

                $('#msgSuccess').text(response.Message);
                $('#alert_L').fadeIn('fast');
                (function () {
                    $('#alert_L').fadeOut('fast');
                }, 1000);
                location.href = "Login";
            } else {
                $('#msg').text(response.Message);
                $('#alert_s').fadeIn('fast');
                (function () {
                    $('#alert_s').fadeOut('fast');
                }, 1000);


            }

        }

    });
}


function register() {
    $('#alert_s').fadeOut('fast');
    $('#alert_L').fadeOut('fast');
    var username = $('#username1').val();
    var email = $('#email').val();
    var idnumber = $('#idnumber').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Login/register",
        data:JSON.stringify( {username:username, email:email,idnumber: idnumber}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            /// alert("You selected: " + response.AuthSuccess);
            if (response.AuthSuccess == true) {
             
                $('#msgSuccess').text(response.Message);
                $('#alert_L').fadeIn('fast');
                (function () {
                    $('#alert_L').fadeOut('fast');
                }, 1000);
                $('#register').hide();
                $('#confirm').show();
            } else {
                $('#msg').text(response.Message);
                $('#alert_s').fadeIn('fast');
                (function () {
                    $('#alert_s').fadeOut('fast');
                }, 1000);


            }

        }

    });
}

function getPaysummary() {
      //alert('Here');
    var date = $('#selectPeriod option:selected').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Home/payrollsummary",
        data: JSON.stringify({payperiod:date}),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
             // alert(data);
            $('#paysummarry').html(data);

        },
    });
}
//Leave
function getLeavesummary() {
    //alert('Here');
    //var date = $('#selectPeriod option:selected').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Home/leaveinfo",
        //data: '{payperiod:"' + date + ' "}',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            //alert(data);
            $('#leavesummarry').html(data);

        },
    });
}
    //Imprest
    function getImprestsummary() {
        //alert('Here');
        //var date = $('#selectPeriod option:selected').val();
        debugger;
        $.ajax({
            type: "POST",
            url: "/Imprest/Index",
            //data: '{payperiod:"' + date + ' "}',
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            success: function (data) {
                //alert(data);
                $('#leavesummarry').html(data);
            },
        });
}
//departmentvalue
function getDepartmentValue() {    
    var date = $('#departmentcode option:selected').val();    
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/departmentvalue",
        data: JSON.stringify({depcode:date}),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            //alert('Here ' + date);
            $('#directoratecode').html(data);
            $.each(states, function (i, departmentValue) {
                $("#directoratecode").append(
                    $('<option></option>').val(departmentValue.StateFullName).html(departmentValue.StateFullName));
            });
        },
    });
}
//sendforapproval
function sendforapproval() {
    var date = $('#imprestNo').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/sendforapproval",
        data: '{depcode:"' + date + ' "}',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            //alert('Here ' + date);            
        },
    });
}
//sendforapprovalcancel
function sendforapprovalcancel() {
    var date = $('#imprestNo').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/sendforapprovalcancel",
        data: JSON.stringify({depcode:date}),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            //alert('Here ' + date);
        },
    });
}
function addImprestLine() {
    
    var imprestNo = $('#imprestNo').val();
    var Type = $('#Type').val();
    var Amount = $('#Amount').val();
   // alert('Here ' + Type + 'par 2 ' + imprestNo+ 'par 3 '+Amount);
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/AddImprestLine",
        data: JSON.stringify({ imprestNo: imprestNo, Type: Type, Amount: Amount }),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            // alert('Here Sucess'+ data);
            $('#imprestId').html(data);
        },
    });
}
//CreateImprest
//departmentvalue
function createImprest() {
    var departmentcode = $('#departmentcode option:selected').val();
    var directoratecode = $('#directoratecode option:selected').val();
    var startDate = $('#startdate').val();
    var endDate = $('#enddate').val();
    var responsibitycenter = $('#responsibitycenter').val();
    var purposes = $('#purpose').val();
    //alert('Here ' + departmentcode);
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/createimprest",
        data: JSON.stringify({ departmentcode: departmentcode, directoratecode: directoratecode, responsibilitycenter: responsibitycenter, purposes: purposes, startdate: startDate, enddate: endDate }),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
           // alert('Here Sucess'+ data);
           $('#imprestId').html(data);           
        },
    });
}
//createimprestSurrender
function createimprestSurrender() {
    var ImprestNo = $('#ImprestCode option:selected').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/ImprestAccounting/createimprestSurrender",
        data: JSON.stringify({ ImprestNo: ImprestNo}),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
             alert('Here Sucess'+ data);
            $('#imprestId').html(data);
        },
    });
}
function updateImprest() {
    var departmentcode = $('#departmentcode option:selected').val();
    var directoratecode = $('#directoratecode option:selected').val();
    var startDate = $('#startdate').val();
    var endDate = $('#enddate').val();
    var responsibitycenter = $('#responsibitycenter').val();
    var purposes = $('#purpose').val();
    var ImprestNo = $('#ImprestNo').val();
    //alert('Here ' + departmentcode);
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/updateimprest",
        data: JSON.stringify({ ImprestNo: ImprestNo, departmentcode: departmentcode, directoratecode: directoratecode, responsibilitycenter: responsibitycenter, purposes: purposes, startdate: startDate, enddate: endDate }),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            // alert('Here Sucess'+ data);
            $('#imprestId').html(data);
        },
    });
}
function impresteditclick(ImprestNo) {
    //  alert('Here');
    $.ajax({
        type: "POST",
        url: "/Imprest/ImprestEdit",
        data: JSON.stringify({ImprestNo:ImprestNo}),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            debugger;
            $('#myModalContent').html(data);
            $('#myModal').modal(options);
            $('#myModal').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
}
function payslipPdf() {    
    var date = $('#selectPeriod option:selected').val();
        debugger;
        $.ajax({
            type: "POST",
            url: "/Home/payslipPdf",
            data: JSON.stringify({ payperiod: date }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                //alert(result);
                debugger;
                $("#reports").empty();
                $("#reports").append('<iframe src=' + result + ' style="min-height:400px; height:900px; width:100%; min-width:500px"></iframe>');
            },
        });
}
function p9Pdf() {
    var startDate = $('#startdate').val();
    var endDate = $('#enddate').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Home/p9Pdf",
        //data: '{payperiod:"' + date + ' "}',
        data: JSON.stringify({ startdate: startDate, enddate: endDate }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
           // alert(result);
            debugger;
            $("#reportsp9").empty();
            $("#reportsp9").append('<iframe src=' + result + ' style="min-height:400px; height:900px; width:100%; min-width:500px"></iframe>');
        },
    });
}
function LeaveStatementPdf() {
    var startDate = $('#startdate').val();
    var endDate = $('#enddate').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Home/LeaveStatement",
        //data: '{payperiod:"' + date + ' "}',
        //data: JSON.stringify({ startdate: startDate, enddate: endDate }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            // alert(result);
            debugger;
            $("#reportspL").empty();
            $("#reportspL").append('<iframe src=' + result + ' style="min-height:400px; height:900px; width:100%; min-width:500px"></iframe>');
        },
    });
}
//createPettyCash
function createPettyCash() {
    var departmentcode = $('#departmentcode option:selected').val();
    var directoratecode = $('#directoratecode option:selected').val();
    var bank = $('#bank option:selected').val();
    var requestedamount = $('#requestedamount').val();
    var purposes = $('#purpose').val();
    //alert('Here ' + departmentcode + ' par2 ' + directoratecode + ' par3 ' + requestedamount + ' purposes ' + purposes + ' bank ' + bank);
    debugger;
    $.ajax({
        type: "POST",
        url: "/PettyCash/createPettyCash",
        data: JSON.stringify({ departmentcode: departmentcode, directoratecode: directoratecode, purposes: purposes, amountrequested: requestedamount, bank: bank }),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            // alert('Here Sucess'+ data);
            $('#imprestId').html(data);
        },
    });
}
function updatePettyCash() {
    
    var departmentcode = $('#departmentcode option:selected').val();
    var directoratecode = $('#directoratecode option:selected').val();
    var bank = $('#bank option:selected').val();
    var requestedamount = $('#requestedamount').val();
    var purposes = $('#purpose').val();    
    var PettyCashNo = $('#PettyCashCode').val();
    //alert('Here 22 PCNO. ' + PettyCashNo + ' par2 ' + directoratecode + ' par3 ' + requestedamount + ' purposes ' + purposes + ' bank ' + bank);
    debugger;
    $.ajax({
        type: "POST",
        url: "/PettyCash/updatePettyCash",
        data: JSON.stringify({ PettyCashNo: PettyCashNo, departmentcode: departmentcode, directoratecode: directoratecode, purposes: purposes, amountrequested: requestedamount, bank: bank }),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data) {
            // alert('Here Sucess'+ data);
            $('#imprestId').html(data);
        },
    });
}
function createTraining() {
    var TrainingCode = $('#TrainingCode option:selected').val();
    debugger;
    $.ajax({
        type: "POST",
        url: "/Training/createTraining",
        data: JSON.stringify({ TrainingCode: TrainingCode }),
        //data: { departmentcode: "' + departmentcode + ' ", directoratecode: "' + directoratecode + '", purposes: "' + purposes + '", startdate: "' + startDate + '", enddate: "' + endDate + '", responsibilitycenter: "' + responsibitycenter+" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {           
            //$('#imprestId').html(data);
           //location.href = "Training";
        },
    });
}

function editimprest() {
    debugger;
    var implines = [];
    $("#tbodyimprestline1 tr").each(function () {
        var row = $(this);
        //var Statement = {};
        var leverage = row.find("td:eq(0) select option:selected").val();
       // alert(leverage);
        if (leverage != undefined) {
            
            var rowdata = row.find("td:eq(0) select option:selected").val() + "??" + row.find("td:eq(1) input[type='text']").val() + "??" + row.find("td:eq(2) input[type='number']").val() + "??" + row.find("td:eq(3) select option:selected").val() + "??" + row.find("td:eq(4) input[type='number']").val() + "??" + row.find("td").eq(5).text();
        }
        else {
            var rowdata = row.find("td").eq(0).text() + "??" + row.find("td").eq(1).text() + "??" + row.find("td").eq(2).text() + "??" + row.find("td").eq(3).text() + "??" + row.find("td").eq(4).text()+"??"+ row.find("td").eq(5).html();
        }
        implines.push(rowdata);
    });
    debugger;
    $.ajax({
        type: "POST",
        url: "/Imprest/updateimprestheader",
        data: JSON.stringify({ fundcode: $('#fundcode101 option:selected').val(), programcode: $('#programcode101 option:selected').val(), purpose: $('#description3').val(), implines: implines, budgetdimension: $('#budgetlinecode101 option:selected').val(), departmentdimension: $('#departmentdimension1 option:selected').val(), budgetdescription: $('#budgetcategory101 option:selected').val(), missionno: $('#editmissionproposal option:selected').val(), purchaseNo: $('#purchasereq101 option:selected').val(), document: $('#pno1').text() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.status == true) {

                alert('Imprest saved successfully');
                window.location.href = '/Imprest/index';
            } else {



            }

        }

    });
}
function removeline(row) {
    var rowdelete = $(row).closest('tr');
    $.ajax({
        type: "POST",
        url: "/Imprest/deleteline",
        data: JSON.stringify({ line: rowdelete.find("td:eq(3)").html(), document: rowdelete.find("td:eq(4)").html() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.status == true) {

                $(row).closest('tr').remove();
            } else {

                alert(response.mesasge)

            }

        }

    });



}


function removelineAll(row, line,doc) {
    debugger;
    var rowdelete = $(row).closest('tr');
    $.ajax({
        type: "POST",
        url: "/Imprest/deleteline",
        data: JSON.stringify({ line: line, document: doc }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.status == true) {

                $(row).closest('tr').remove();
            } else {

                alert(response.mesasge)

            }

        }

    });



}


function deleteAttachment(attachmentNos, documentNos, target) {

    console.log(attachmentNos);
    console.log(documentNos);
    console.log(target);
    var attachmentNos1 = attachmentNos;
    var documentNos1 = documentNos;
    debugger;
    $.ajax({
        //   beforeSend: startAnimation(target),
        type:"POST",
        url: "/Upload/deleteuploads",
        data: JSON.stringify({ documentNo: documentNos1, attachmentNo: attachmentNos1 }),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (result) { $('#'+target+'').html(result); },
        //   complete: stopAnimation(target)
    });
}
function removeEmptyLine(row) {
    $(row).closest('tr').remove();
}

function purchaserequest1111111112() {
    var implines = [];
    debugger;
    $("#tbodyimprestline2 tr").each(function () {
        var row = $(this);
        
        var leverage = row.find("td:eq(0) select option:selected").val();
        // alert(leverage);
        if (leverage != undefined) {

            var rowdata = row.find("td:eq(0) select option:selected").val() + "??" + row.find("td:eq(1) input[type='text']").val() + "??" + row.find("td:eq(2) input[type='number']").val() + "??" + row.find("td:eq(3) select option:selected").val() + "??" + row.find("td:eq(4) input[type='number']").val() + "??" + row.find("td").eq(5).text();
        }
        else {
            var rowdata = row.find("td").eq(0).text() + "??" + row.find("td").eq(1).text() + "??" + row.find("td").eq(2).text() + "??" + row.find("td").eq(3).text() + "??" + row.find("td").eq(4).text() + "??" + row.find("td").eq(5).text();
        }

        implines.push(rowdata);
    });
  
    debugger;
    $.ajax({
        type: "POST",
        url: "/Purchase/Updateimprestheader1",
        data: JSON.stringify({ fundcode: $('#programcode0002 option:selected').val(), programcode: $('#department0002 option:selected').val(), purpose: $('#description0002').val(), implines: implines, daterequired: $('#daterequired0002').val(), budgetdimension: $('#budgetdimension0002 option:selected').val(), departmentdimension: $('#departmentdimension0002 option:selected').val(), budgetdescription: $('#budgetdescription0002 option:selected').val(), missiono: $('#missionno0002 option:selected').val(), no: $('#reqno000211101010').text() }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            if (response.status == true) {

                alert('Purchase requisition saved successfully');
                window.location.href = '/Purchase/openpurchases';

            } else {



            }

        }

    });
}

function validateiens(rowline) {
    debugger;
    var row = $(rowline).closest('tr');
    var totals = 0;
  
    totals = row.find("td:eq(2) input[type='number']").val() * row.find("td:eq(3) input[type='number']").val() * row.find("td:eq(4) input[type='number']").val();
  //  alert(totals);
    row.find("td:eq(6) input[type='number']").val(totals);
    var sum = 0;
    $('.totalprice').each(function () {
        if ($(this).val() !== "")
            sum += parseInt($(this).val(), 10);
    });
    $('.priceTotal').val(sum);
    var sum1 = 0;
    $('.totalprice1').each(function () {
        if ($(this).val() !== "")
            sum1 += parseInt($(this).val(), 10);
        
    });
    $('.priceTotal1').val(sum1);
  //  alert(sum);
}

function LoadData(target, url) {
    debugger;
    $.ajax({
     //   beforeSend: startAnimation(target),
        url: url,
        success: function (result) { $(target).html(result); },
     //   complete: stopAnimation(target)
    });
}

function startAnimation(target) {
    //..add a loading image on top of the target  
}

function stopAnimation(target) {
    // remove the animation gif or stop the spinning, etc.
}

function loadropdown(target, url) {
    $.ajax({
        //   beforeSend: startAnimation(target),
        url: url+'?valor=' + url,
        success: function (result) { $(target).html(result); },
        //   complete: stopAnimation(target)
    });
}

function loadropdown1(target, url, id) {
    $.ajax({
        //   beforeSend: startAnimation(target),
        url: url + '?fundcode=' + $('#'+id+'').val(),
        success: function (result) { $(target).html(result); },
        //   complete: stopAnimation(target)
    });
}