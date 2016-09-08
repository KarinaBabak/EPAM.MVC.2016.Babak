$(function () {

    var currentSide = $(".faction-header h2").text();

    $("#btnChangeSide").click(function () {
        if (currentSide == "Light") {
            $("body").css('background', '#696969');
        }
        else {
            alert("Lol. There is no way out! PS. Your HR department has been contacted");
        }
    });

  

})