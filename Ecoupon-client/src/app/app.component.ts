import { Component, OnInit } from "@angular/core";
import * as singalR from "@aspnet/signalr";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {
    const connection = new singalR.HubConnectionBuilder()
      .configureLogging(singalR.LogLevel.Information)
      .withUrl("http://localhost:5000/notify")
      .build();
    connection
      .start()
      .then(function () {
        console.log("Signal R Connected");
      })
      .catch(function (err) {
        return console.error(err.toString());
      });

    connection.on("BroadcastMessage", () => {
      console.log("Message Recieved");
    });
  }
}
