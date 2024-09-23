import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  readonly BaseURI = environment.apiBaseUrl;
  constructor(private http: HttpClient) {

  }
  getUserReceivedMessages(userId: string) {
    return this.http.get(this.BaseURI + '/message');
  }
  deleteMessage(message: any) {
    return this.http.post(this.BaseURI + '/message', message);
  }
}
