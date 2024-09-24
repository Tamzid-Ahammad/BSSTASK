import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  readonly BaseURI = 'https://localhost:7104/api';
  constructor(private http: HttpClient) {

  }
  getUserReceivedMessages(userId: string) {
    return this.http.get(this.BaseURI + '/message');
  }
  deleteMessage(message: any) {
    return this.http.post(this.BaseURI + '/message', message);
  }
}
