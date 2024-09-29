import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { UserService } from '../services/user.service';
import { MessageService } from '../services/message.service';
import { Guid } from 'guid-typescript';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
 
  
})
export class HomeComponent implements OnInit {
  loggedInUser = JSON.parse(localStorage.getItem("login-user"))
  users: any;
  token= localStorage.getItem("token");
  chatUser: any;
  conversation: any;
  messages: any[] = [];
  displayMessages: any[] = []
  message: string
  hubConnection: HubConnection;
  connectedUsers: any[] = []
  readonly chatHubUrl = 'https://localhost:7104/chathub';
  constructor(private router: Router, private service: UserService, private messageService: MessageService, private http: HttpClient) { }

  ngOnInit() {
   
    this.service.getAll().subscribe(
      (user: any) => {
        if (user) {
          this.users = user.filter(x => x.email !== this.loggedInUser.email);
          this.users.forEach(item => {
            item['isActive'] = false;
          })
          this.makeItOnline();
        }
      },
      err => {
        console.log(err);
      },
    );

    this.message = ''
    this.hubConnection = new HubConnectionBuilder().withUrl(this.chatHubUrl,
      {
        accessTokenFactory: () => localStorage.getItem('token') ? localStorage.getItem('token') : ''
      }).build();
    const self = this
    this.hubConnection.start()
      .then(() => {

        
     
      })
      .catch(err => console.log(err));

    this.hubConnection.on('MessageDeleted', (conversationId, messageId) => {
      if (this.conversation.id == conversationId) {
        this.messages = this.messages.filter(x => x.id != messageId);
      }
    })

    this.hubConnection.on('SendMessage', (receiverUserId: string, message:any) => {
      console.log(message)
      if (this.conversation.id == message.conversationId) {
        this.messages.push(message);
      }
    })
  }

  SendMessage() {
    if (this.message != '' && this.message.trim() != '') {
      const msg = {
        userId: this.chatUser.id,
        text: this.message,
      };

      // Send message to backend using HTTP POST

      this.messageService.sendMessage(this.conversation.id, msg).subscribe(() => {
          this.message = '';
        }, err => {
          console.error(err);
        });
    }
  }

  openChat(user) {

    this.chatUser = user;
    this.messageService.getConversation(this.loggedInUser.id, user.id).subscribe((data) => {
      this.conversation  = data;
      this.messageService.getMessages(this.conversation.id).subscribe((messages: any[]) => {
        this.messages = messages;
      })
    });
   
  }

  makeItOnline() {
    if (this.connectedUsers && this.users) {
      this.connectedUsers.forEach(item => {
        var u = this.users.find(x => x.userName == item.username);
        if (u) {
          u.isOnline = true;
        }
      })
    }
  }



  onLogout() {
    this.hubConnection.invoke("RemoveOnlineUser", this.loggedInUser.id)
      .then(() => {
        this.messages.push('User Disconnected Successfully')
      })
      .catch(err => console.error(err));
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }


}

