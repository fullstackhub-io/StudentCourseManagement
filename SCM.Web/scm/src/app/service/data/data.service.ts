import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class DataService {

  //SERVER_URL = environment.production;

  constructor(public _http: HttpClient) { }

  get(url: string): Observable<any> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.get(url, { headers: headers });
  }

  post(url: string, model: any): Observable<any> {
    let body = JSON.stringify(model);
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.post(url, body, { headers: headers });
  }

  put(url: string, model: any): Observable<any> {
    let body = JSON.stringify(model);
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.put(url, body, { headers: headers });
  }

  delete(url: string): Observable<any> {
    let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this._http.delete(url, { headers: headers });
  }

  upload(url: string, model: any): Observable<any> {
    let body = model;
    let headers = new HttpHeaders({ 'Content-Type': 'multipart/form-data' });
    return this._http.post(url, body);
  }

}