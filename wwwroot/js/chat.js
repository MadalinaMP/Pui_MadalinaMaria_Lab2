"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;
connection.on("ReceiveMessage", function (name,surname, message, time) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var d = new Date();
    var ddate = d.getDate() + "." + d.getMonth() + "." + d.getFullYear();
    var dtime = d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
    var time = ddate + " " + dtime;
    var encodedMsg = name + " " + surname + " says " + msg + " at " + time;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});
connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var name = document.getElementById("nameInput").value;
    var surname = document.getElementById("surnameInput").value;
    var message = document.getElementById("messageInput").value;
    var time;
    connection.invoke("SendMessage", name, surname, message, time).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});