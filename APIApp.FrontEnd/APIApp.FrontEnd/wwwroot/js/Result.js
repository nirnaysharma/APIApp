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
            var json = $.parseJSON(data);
            var isPrime = $.parseJSON(json.IsPrime);
            var text = "The sum ";
            isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
            //console.log(text);
            $("#lblResults").text(text);
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
            var json = $.parseJSON(data);
            var isPrime = $.parseJSON(json.IsPrime);
            var sum = $.parseJSON(json.Sum);
            var text = "The sum of the numbers is " + sum + " and the sum ";
            isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
            //console.log(text);
            $("#lblResults").text(text);
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
                var json = $.parseJSON(data);
                var isPrime = $.parseJSON(json.IsPrime);
                var sum = $.parseJSON(json.Sum);
                if (parseInt(sum) == 0) {
                    //It is a single number
                    text = "The sum ";
                    isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
                    $("#lblCombinedResults").text(text);
                }
                else {
                    //multiple numbers
                    text = "The sum of the numbers is " + sum + " and the sum ";
                    isPrime == true ? text += " is a Prime number" : text += " is NOT a Prime number";
                    $("#lblCombinedResults").text(text);
                }
            }
        });
    });




