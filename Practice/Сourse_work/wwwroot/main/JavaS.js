"use strict";

window.onload = function() {   
    //console.log("HEPL!");
    //alert("JS work!");
}
var prov =function check(ok) {

    ok = 0;
    if (document.getElementById("division").value == "no_choose") {
        alert('Введите подразделение!');
        event.preventDefault();
        ok = 1;
    }
    if (document.getElementById("service").value == "no_choose") {

        alert('Введите услугу!');
        event.preventDefault();
        ok=1;
    }
    if (document.getElementById("date").value.length == 0) {

        alert('Введите дату!');
        event.preventDefault();
        ok = 1;
    }
    if (document.getElementById("time").value.length == 0) {

        alert('Введите время!');
        event.preventDefault();
        ok = 1;
    }
    return ok;
}
function removeLoading() {
    document.getElementById("load").hidden = true;
    

    
}
function showLoading() {
    var ok;
    ok = prov();
    if (ok == 0) {
        document.getElementById("load").hidden = false;
        //document.body.style.display = "none";
        setTimeout(removeLoading, 1000);
        //setTimeout(() => document.body.style.display = "", 1000); 
    }
    //document.getElementById("load").hidden = true;
}
