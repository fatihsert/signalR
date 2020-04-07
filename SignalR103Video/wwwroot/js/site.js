"use strict";

var videoItem = document.getElementById("myVideo");
var videoTracktHubConnection = new signalR.HubConnectionBuilder().withUrl("/VideoTrack").build();
videoTracktHubConnection.start().then(function (response) {
    console.log(response);
}).catch(function (err) {
    return console.error(err.toString());
}).then(function () {

})

var seeking = false;

//videoTracktHubConnection.on("VideoTime", function (time) {
//    if (isUpdater) {
//        return;
//    }

//    videoItem.currentTime = time;
//});


videoItem.onseeking = function (event) {
    debugger;
    videoTracktHubConnection.invoke("Seeking", videoItem.currentTime).then(function () {
    })
    event.preventDefault();
};


videoItem.onseeked = function (event) {
    debugger;
    //videoTracktHubConnection.invoke("Seeking", videoItem.currentTime).then(function () {
    //    seeking = true;
    //}).then(function () {
    //    seeking = false;
    //});


};


videoTracktHubConnection.on("Seeking", function (currentTime) {
    debugger;
    videoItem.currentTime = currentTime;
    debugger;

});



videoItem.onplay  = function () {
    debugger;

    videoTracktHubConnection.invoke("Play", videoItem.currentTime).then(function () {
    });
}

videoTracktHubConnection.on("Play", function () {
    debugger;

    videoItem.Play();
});


videoItem.onpause = function () {
    videoTracktHubConnection.invoke("Pause", videoItem.currentTime).then(function () {
    });
}

videoTracktHubConnection.on("Pause", function () {
    videoItem.Pause();
});


videoItem.ontimeupdate = function () {

    //videoTracktHubConnection.invoke("SetVideoTime", videoItem.currentTime).then(function () {
    //    isUpdater = true;
    //}); 
};

