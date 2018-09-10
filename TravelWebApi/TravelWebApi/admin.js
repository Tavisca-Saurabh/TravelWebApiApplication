
Product = {};

var PostHotel = () => {
    var name = $("#name").val();
    var price = $("#price").val();
    var address = $("#address").val();
    var starRating = $("#starRating").val();

    Product.Name = name;
    Product.Price = price;
    Product.Address = address;
    Product.StarRating = starRating;

    ajaxCall(Product);
};

var appendData = (response) => {
    $("#showResponse").append("<p>" + response.Name + "</p>")
}

var ajaxCall = (Product) => {

    $.ajax({
        url: "/api/hotel/add",
        data: JSON.stringify(Product),
        type: 'POST',
        contentType: 'application/json',
        //crossDomain: true,
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { appendData(response) });
};

var PostFlight = () => {
    var name1 = $("#name1").val();
    var price1 = $("#price1").val();
    var from = $("#from").val();
    var to = $("#to").val();
    var departureDate = $("#departureDate").val();
    var arrivalDate = $("#arrivalDate").val();

    Product.Name = name1;
    Product.Price = price1;
    Product.From = from;
    Product.To = to;
    Product.DepartureDate = departureDate;
    Product.ArrivalDate = arrivalDate;

    PostFlightajaxCall(Product);
};

var PostFlightajaxCall = (Product) => {

    $.ajax({
        url: "/api/air/add",
        data: JSON.stringify(Product),
        type: 'POST',
        contentType: 'application/json',
        //crossDomain: true,
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { alert("Successfully Added"); });
};

/********************************Car********************************/
var PostCar = () => {
    var name = $("#nameCar").val();
    var price = $("#priceCar").val();
    var from = $("#fromCar").val();
    var to = $("#toCar").val();
    var departureDate = $("#departureDateCar").val();
    var arrivalDate = $("#arrivalDateCar").val();

    Product.Name = name;
    Product.Price = price;
    Product.From = from;
    Product.To = to;
    Product.DepartureDate = departureDate;
    Product.ArrivalDate = arrivalDate;

    PostCarajaxCall(Product);
};

var PostCarajaxCall = (Product) => {

    $.ajax({
        url: "/api/car/add",
        data: JSON.stringify(Product),
        type: 'POST',
        contentType: 'application/json',
        //crossDomain: true,
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { alert("Successfully Added"); });
};

/*************************************Activity***************************/

var PostActivity = () => {
    var name = $("#nameActivity").val();
    var price = $("#priceActivity").val();
    var location = $("#locationActivity").val();
    var date = $("#dateActivity").val();
    var duration = $("#durationActivity").val();

    Product.Name = name;
    Product.Price = price;
    Product.Location = location;
    Product.Date = date;
    Product.Duration = duration;

    PostActivityajaxCall(Product);
};

var PostActivityajaxCall = (Product) => {

    $.ajax({
        url: "/api/activity/add",
        data: JSON.stringify(Product),
        type: 'POST',
        contentType: 'application/json',
        //crossDomain: true,
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { alert("Successfully Added"); });
};