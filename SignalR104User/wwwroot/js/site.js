"use strict";

var userHubConnection = new signalR.HubConnectionBuilder().withUrl("/UserHub").build();

//Hub a mesaj gönderme örneği
//contentHubConnection.invoke("SendScroll", x, y).catch(function (err) {

//    return console.error(err.toString());
//});

//Hubdan mesaj alma örneği
//contentHubConnection.on("Scroll", function (x, y) {
//    setContentScrrol(x, y);
//});



//hub bağlantı örneği

userHubConnection.start().then((response) => {
    console.log(response);
}).then(() => {

    userHubConnection.invoke("Join").then((response) => {

        for (let i = 0; i < response.length; i++) {
            addNewUser(response[i]);
        }

    }).catch((err) => {

        //TODO: Hata Alırsa Tekrar Dene butonu Koyabiliriz.
        return console.error(err.toString());
    })
});


userHubConnection.on("Disconnect", (response) => {
    document.getElementById(response.connectionId).remove();
});


userHubConnection.on("JoinNewUser", (response) => {
    addNewUser(response);
});


 
const addNewUser = (user) => {
    var li = document.createElement("li");
    li.textContent = user.userName;
    li.id = user.connectionId;
    document.getElementById("user").appendChild(li);
};



