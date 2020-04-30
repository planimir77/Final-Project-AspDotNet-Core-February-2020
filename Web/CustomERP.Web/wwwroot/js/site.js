// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#menu-toggle").click(function(e) {
    e.preventDefault();
    
    var myMenu = $("#mySidepanel").css("left");

    if (myMenu === "-245px" || myMenu ==="") {
        $("#mySidepanel").css("left", "-40px");
        $("#angle-double-right").removeClass("fas fa-angle-double-right");
        $("#angle-double-right").addClass("fas fa-angle-double-left");
    } else {
        $("#mySidepanel").css("left","-245px");
        $("#angle-double-right").removeClass("fas fa-angle-double-left");
        $("#angle-double-right").addClass("fas fa-angle-double-right");
    }

});

// -------- Sideanel expand --------------------------------------->

//function openNav() {
//    $("#mySidepanel").css("left", "-40px");
//    $("#angle-double-right").removeClass("fas fa-angle-double-right");
//    $("#angle-double-right").addClass("fas fa-angle-double-left");

//    setTimeout(function() {
//        $("#mySidepanel").css("left","-245px");
//        $("#angle-double-right").removeClass("fas fa-angle-double-left");
//        $("#angle-double-right").addClass("fas fa-angle-double-right");
//    }, 5000);

//};

