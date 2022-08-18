import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getTokens(){
    return this.http.get<IPagination>(this.baseUrl + 'token');
  }
}
