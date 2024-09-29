import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  readonly BaseURI = 'https://localhost:7104/api';
  constructor(private http: HttpClient) {

  }
  sendMessage(conversationId: string, message: any) {
    return this.http.post(this.BaseURI +`/chat/conversation/${conversationId}/send`, message)
  }
  getConversation(myUserId: string, targetUserId: string) {
    return this.http.get(this.BaseURI + `/chat/getConversation/${myUserId}/${targetUserId}`)
  }
  getMessages(conversationId: string) {
    return this.http.get(this.BaseURI + `/chat/conversation/${conversationId}/messages`)
  }
 

}
