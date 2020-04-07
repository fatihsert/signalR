"use strict";

var contentHubConnection = new signalR.HubConnectionBuilder().withUrl("/ContentHub").build();


document.getElementById("content").addEventListener("scroll", function (event) {
    var x = this.scrollLeft;
    var y = this.scrollTop;
    contentHubConnection.invoke("SendScroll",x, y).catch(function (err) {

        return console.error(err.toString());
    });

    
});

document.getElementById("btnJoin").addEventListener("click", function (event) {

    var userName = document.getElementById("txtUserName").value;
    contentHubConnection.start().then(function (response) {
        console.log(response);
    }).catch(function (err) {
        return console.error(err.toString());
    }).then(function () {
        contentHubConnection.invoke("GetContent").then(function (content) {
            document.getElementById("content").innerText = content;

            contentHubConnection.invoke("GetCurrentScroll").then(function (scrollStr) {
                var scroll = JSON.parse(scrollStr);
                setContentScrrol(scroll.X, scroll.Y);
            });
        });
    });

    event.preventDefault();
});
 
contentHubConnection.on("Scroll", function (x, y) {
    setContentScrrol(x, y);
});

function setContentScrrol(x,y) {
    document.getElementById("content").scrollLeft = x;
    document.getElementById("content").scrollTop = y;
}