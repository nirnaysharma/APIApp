$('#txtSingleNumber').on('input', function () {
    if ($("#txtSingleNumber").val().length > 0) {
        $('#submitSingleNumber').prop('disabled', false);
    }
    else {
        $('#submitSingleNumber').prop('disabled', true);
    }
});


$('#txtMultipleNumber').on('input', function () {
    if ($("#txtMultipleNumber").val().length > 0) {
        $('#submitMultipleNumbers').prop('disabled', false);
    }
    else {
        $('#submitMultipleNumbers').prop('disabled', true);
    }
});


$('#txtSingleMultipleNumber').on('input', function () {
    if ($("#txtSingleMultipleNumber").val().length > 0) {
        $('#submitSingleMultipleNumbers').prop('disabled', false);
    }
    else {
        $('#submitSingleMultipleNumbers').prop('disabled', true);
    }
});

//Checks if the value entered in the textbox is a number or not. If not, it returns false else true
function CheckNumeric(e) {
    if (window.event) // IE
    {
        if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8 && e.keyCode != 44) {
            event.returnValue = false;
            return false;
        }
    }
    else { // Firefox
        if ((e.which < 48 || e.which > 57) & e.which != 8 && e.which != 44) {
            e.preventDefault();
            return false;
        }
    }
}

$("#submitSingleNumber").click(function () {
    $("#txtMultipleNumber").val('');
    $('#submitMultipleNumbers').prop('disabled', true);
    $("#lblCombinedResults").html('');
    $("#txtSingleMultipleNumber").val('');
    var singleNumber = $("#txtSingleNumber").val();
    $.ajax({
        type: 'POST',
        url: '/Home/SingleNumberIsPrime',
        data: { "singleNumber": singleNumber },
        datatype: JSON,

        success: function (data) {
            try {
                //check if the return type is JSON or not
                var json = JSON.parse(data);
                var isPrime = $.parseJSON(json.IsPrime);
                var text = "The sum ";
                isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
                $("#lblResults").css("color", "black");
                $("#lblResults").text(text);
            } catch (e) {
                //JSON parse error, this is not json
                $("#lblResults").css("color", "red");
                $("#lblResults").text("Exception: Incorrect input");
            }
        },
        error: function (request, status, error) {
            $("#lblResults").css("color", "red");
            $("#lblResults").text("Exception: " + request.responseText);
        }
    });

});


$("#submitMultipleNumbers").click(function () {
    $("#txtSingleNumber").val('');
    $("#submitSingleNumber").prop('disabled', true);
    $("#lblCombinedResults").html('');
    $("#txtSingleMultipleNumber").val('');
    var multipleNumbers = $("#txtMultipleNumber").val();
    $.ajax({
        type: 'POST',
        url: '/Home/MultipleNumberIsPrime',
        data: { "multipleNumber": multipleNumbers },
        datatype: JSON,

        success: function (data) {
            try {
                var json = $.parseJSON(data);
                var isPrime = $.parseJSON(json.IsPrime);
                var sum = $.parseJSON(json.Sum);
                var text = "The sum of the numbers is " + sum + " and the sum ";
                isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
                $("#lblResults").css("color", "black");
                $("#lblResults").text(text);
            } catch (e) {
                $("#lblResults").css("color", "red");
                $("#lblResults").text("Exception: " + data);
            }
        },
        error: function (request, status, error) {
            $("#lblResults").css("color", "red");
            $("#lblResults").text("Exception: " + request.responseText);
        }
    });
});


$("#submitSingleMultipleNumbers").click(function () {
    $("#txtSingleNumber").val('');
    $("#submitSingleNumber").prop('disabled', true);
    $("#txtMultipleNumber").val('');
    $('#submitMultipleNumbers').prop('disabled', true);
    $("#lblResults").html('');
    $("#lblCombinedResults").text('');
    var text;
    var numbers = $("#txtSingleMultipleNumber").val();
    $.ajax({
        type: 'POST',
        url: '/Home/CombinedMethod',
        data: { "numbers": numbers },
        datatype: JSON,

        success: function (data) {
            try {
                var json = $.parseJSON(data);
                var isPrime = $.parseJSON(json.IsPrime);
                var sum = $.parseJSON(json.Sum);
                if (parseInt(sum) == 0) {
                    //It is a single number
                    text = "The sum ";
                    isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
                    $("#lblResults").css("color", "black");
                    $("#lblCombinedResults").text(text);
                }
                else {
                    //multiple numbers
                    text = "The sum of the numbers is " + sum + " and the sum ";
                    isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
                    $("#lblResults").css("color", "black");
                    $("#lblCombinedResults").text(text);
                }
            } catch (e) {
                $("#lblResults").css("color", "red");
                $("#lblResults").text("Exception: " + data);
            }
        },
        error: function (request, status, error) {
            $("#lblResults").css("color", "red");
            $("#lblResults").text("Exception: " + request.responseText);
        }
    });
});





