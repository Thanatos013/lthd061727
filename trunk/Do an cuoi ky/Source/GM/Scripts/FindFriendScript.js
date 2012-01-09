﻿/// <reference path="google-maps-3-vs-1-0.js" />
var map;
var vietnam = new google.maps.LatLng(14.058324, 108.277199);
var initLocation;
var browserSupportFlag;
var geocoder;
var marker;
var infowindow;
var latitude;
var longitude;
var clickedPixel;
var contextmenu;
var circleOptions;
var nearbyCircle;
var nearbyLocations = new Array();
var infoList = new Array();

//ham xu ly khong dinh vi duoc
function handleNoGeolocation(errorFlag) {
    if (errorFlag == true) {
        alert("Dịch vụ định vị địa lý có lỗi!");
        initLocation = vietnam;
    }
    else {
        alert("Trình duyệt không hỗ trợ định vị địa lý!");
        initLocation = vietnam;
    }
    map.setCenter(initLocation);
}

//ham khoi tao ban do
function initialize() {
    var myOptions = {
        zoom: 16,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map"), myOptions);

    // Try W3C Geolocation (Preferred)
    if (navigator.geolocation) {
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position) {
            initLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            map.setCenter(initLocation);
            latitude = position.coords.latitude;
            longitude = position.coords.longitude;
        }, function () {
            handleNoGeolocation(browserSupportFlag);
        });
    }

    // Try Google Gears Geolocation
    else if (google.gears) {
        browserSupportFlag = true;
        var geo = google.gears.factory.create('beta.geolocation');
        geo.getCurrentPosition(function (position) {
            initLocation = new google.maps.LatLng(position.latitude, position.longitude);
            map.setCenter(initLocation);
            latitude = position.coords.latitude;
            longitude = position.coords.longitude;
        }, function () {
            handleNoGeolocation(browserSupportFlag);
        });
    }

    // Browser doesn't support Geolocation
    else {
        browserSupportFlag = false;
        handleNoGeolocation(browserSupportFlag);
    }

    //map.getDiv().appendChild(contextmenu);
}

function OnGetNearbyLocationsSuccess(response) {
    for (var i = 0; i < response.length; i++) {
        if (!geocoder) {
            geocoder = new google.maps.Geocoder();
        }
        var geocoderRequest = { address: response[i].Name };
        geocoder.geocode(geocoderRequest, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (!nearbyLocations[i]) {
                    nearbyLocations[i] = new google.maps.Marker({ map: map });
                }
                nearbyLocations[i].setPosition(results[0].geometry.location);

                if (!infoList[i]) {
                    infoList[i] = new google.maps.InfoWindow();
                }

                var content = "<input id='MaDiaDiem' type=hidden value='" + response[i].Id + "' /><br/>";
                var content = "<input id='MaNguoiDung' type=hidden value='" + response[i].UserId + "' /><br/>";
                content += "<strong><input id='TenDiaDiem' type=text  readonly='readonly' value='" + response[i].Name + "' /></strong><br/>";
                content += "Vĩ độ: <input id='ViDo' type=text readonly='readonly' value='" + results[0].geometry.location.lat() + "' /><br/>";
                content += "Kinh độ: <input id='KinhDo' type=text readonly='readonly' value='" + results[0].geometry.location.lng() + "' /><br/>";
                content += "<a href='javascript:void(0);' name='" + results[0].formatted_address + "' onclick=makeFriend()>Kết Bạn</a>&nbsp&nbsp";

                infoList[i].setContent(content);
                infoList[i].open(map, marker);

                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, nearbyLocations[i]);
                });
            }
        });
    }
}


function findMyLocation(idAddress, address, note) {
    PageMethods.GetNearbyLocations(idAddress, OnGetNearbyLocationsSuccess);
    if (!geocoder) {
        geocoder = new google.maps.Geocoder();
    }
    var geocoderRequest = { address: address };
    geocoder.geocode(geocoderRequest, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            if (!marker) {
                marker = new google.maps.Marker({ map: map });
            }
            marker.setPosition(results[0].geometry.location);

            if (!infowindow) {
                infowindow = new google.maps.InfoWindow();
            }

            var content = "<input id='MaDiaDiem' type=hidden value='" + idAddress + "' /><br/>";
            content += "<strong><input id='TenDiaDiem' type=text  readonly='readonly' value='" + address + "' /></strong><br/>";
            content += "Vĩ độ: <input id='ViDo' type=text readonly='readonly' value='" + results[0].geometry.location.lat() + "' /><br/>";
            content += "Kinh độ: <input id='KinhDo' type=text readonly='readonly' value='" + results[0].geometry.location.lng() + "' /><br/>";
            content += "Ghi chú: <input id='GhiChu' type=text readonly='readonly' value='" + note + "' /><br/><br/><br/>";

            infowindow.setContent(content);
            infowindow.open(map, marker);

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
            });

            if (!circleOptions) {
                circleOptions = {
                    strokeColor: "#FF0000",
                    strokeOpacity: 0.8,
                    strokeWeight: 2,
                    fillColor: "#FF0000",
                    fillOpacity: 0.35,
                    map: map,
                    center: results[0].geometry.location,
                    radius: 10
                };
            }

            if (!nearbyCircle) {
                nearbyCircle = new google.maps.Circle(circleOptions);
            }
        }
        else {
            alert('Không tìm thấy địa chỉ cần tìm');
        }
    });
}