
var calculateMortgage = function() {
    var amount = $('#amount').val();
    var years = $('#years').val();
    var type = $('#type').val();
    var interest = $('#interest').val() / 100;

    if (amount == null)
        return;
    if (years == null)
        return;

    $.ajax({
        url: "/api/Loan",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ Type: type, Amount: amount, RepaymentYears: years, Interest: interest }),

        success: function (data) {
            $('#paymentPlan tr').not(':first').remove();
            var html = '';
            for (var i = 0; i < data.length; i++) {
                html += '<tr><td>' + data[i].Period + '</td><td>' + data[i].TotalAmount.toFixed(0) + '</td><td>' + data[i].InterestAmount.toFixed(0) + '</td><td>' + data[i].PaymentAmount.toFixed(0) + '</td><td>' + data[i].RemainingDebt.toFixed(0) + '</td></tr>';
            }
            $('#paymentPlan tr').first().after(html);
        }
    });
}


$(document).ready(function () {
    $("#loanForm").change(function(e) {
        calculateMortgage();
    });
    calculateMortgage();
});
