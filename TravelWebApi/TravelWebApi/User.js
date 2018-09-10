/***************************************Activity*****************************************/
var GetAllActivity = () => {
    AllActivityAjaxCall();
}
var AllActivityAjaxCall = () => {
    //var server = "/api/activity/get/";
    $.ajax({
        url: "/api/activity/get/",
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {

        if ($('#activityDiv').is(':empty')) {
            response.forEach((activity) => {
                var SaveId = "Save" + activity.Id;
                $("#activityDiv").append("<p> Name: " + activity.Name + "</p>");
                $("#activityDiv").append("<p> Price: " + activity.Price + "</p>");
                $("#activityDiv").append("<button id =" + activity.Id + ">Book</button>");
                $("#activityDiv").append("<button id =" + SaveId + ">Save</button>");

                document.getElementById(activity.Id).addEventListener("click", () => {
                    BookAjaxCall(activity.Id, "Activity");
                });
                document.getElementById(SaveId).addEventListener("click", () => {
                    SaveAjaxCall(activity.Id, "Activity");
                });
            });
        }
    });
};
/***************************************Hotel*****************/
var GetAllHotels = () => {
    HotelAllAjaxCall();
}

var HotelAllAjaxCall = () => {
    var server = "/api/hotel/get/";
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {

        if ($('#hotelsDiv').is(':empty')) {
            response.forEach((hotel) => {
                var SaveId = "Save" + hotel.Id;
                $("#hotelsDiv").append("<div> Name: " + hotel.Name + " Price:" + hotel.Price + " Address: " + hotel.Address +" ");
                $("#hotelsDiv").append("<button id =" + hotel.Id + ">Book</button>");
                $("#hotelsDiv").append("<button id =" + SaveId + ">Save</button>");
                $("#hotelsDiv").append("</p>");


                document.getElementById(hotel.Id).addEventListener("click", () => {
                    BookAjaxCall(hotel.Id,"Hotel");
                });
                document.getElementById(SaveId).addEventListener("click", () => {
                    SaveAjaxCall(hotel.Id, "Hotel");
                });
            });
        }
    });
};

var BookAjaxCall = (id, product) => {
    var server;
    if (product === "Hotel") {
        server = "/api/hotel/book/" + id;
    }
    else if (product === "Air") {
        server = "/api/air/book/" + id;
    }
    else if (product === "Car") {
        server = "/api/car/book/" + id;
    }
    else if (product === "Activity") {
        server = "/api/activity/book/" + id;
    }
    $.ajax({
        url: server,
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { alert("Booked Successfully"); });
};

var SaveAjaxCall = (id, product) => {
    var server;
    if (product === "Hotel") {
        server = "/api/hotel/save/" + id;
    }
    else if (product === "Air") {
        server = "/api/air/save/" + id;
    }
    else if (product === "Car") {
        server = "/api/car/save/" + id;
    }
    else if (product === "Activity") {
        server = "/api/activity/save/" + id;
    }
    $.ajax({
        url: server,
        type: 'PUT',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => { alert("Saved Successfully"); });
};

var GetAllFlights = () => {
    FlightAllAjaxCall();
}
FlightAllAjaxCall = () => {
    var server = "/api/air/get/";
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        if ($('#AirDiv').is(':empty')) {
            response.forEach((flight) => {
                var SaveId = "Save" + flight.Id;
                $("#AirDiv").append("<p>" + flight.Name + "</p>");
                $("#AirDiv").append("<button id =" + flight.Id + ">Book</button>");
                $("#AirDiv").append("<button id =" + SaveId + ">Save</button>");

                document.getElementById(flight.Id).addEventListener("click", () => {
                    BookAjaxCall(flight.Id,"Air");
                });
                document.getElementById(SaveId).addEventListener("click", () => {
                    SaveAjaxCall(flight.Id, "Air");
                });
            });
        }
    });
};
//////////////////////////////////GetAllCars()////////////////////////////////////////////
var GetAllCars = () => {
    AllCarsAjaxCall();
}

AllCarsAjaxCall = () => {
    var server = "/api/car/get/";
    $.ajax({
        url: server,
        type: 'GET',
        contentType: 'application/json',
        dataType: 'json',
        success: function (result) {
            console.log("success");
            console.log(result);
        },
        error: function (reason) {
            console.log("had a failure");
            console.log(reason);
        }
    }).done((response) => {
        if ($('#CarDiv').is(':empty')) {
            response.forEach((Car) => {
                var SaveId = "Save" + Car.Id;
                $("#CarDiv").append("<p>" + Car.Name + "</p>");
                $("#CarDiv").append("<button id =" + Car.Id + ">Book</button>");
                $("#CarDiv").append("<button id =" + SaveId + ">Save</button>");

                document.getElementById(Car.Id).addEventListener("click", () => {
                    BookAjaxCall(Car.Id,"Car");
                });
                document.getElementById(SaveId).addEventListener("click", () => {
                    SaveAjaxCall(Car.Id, "Car");
                });
            });
        }
    });
};