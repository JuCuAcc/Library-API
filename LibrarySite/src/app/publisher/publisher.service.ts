import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Publisher } from './publisher';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  url = localStorage.getItem('url');
  constructor(private _http: HttpClient) { }

  getAllPublisher(): Observable<Publisher[]> {
    return this._http.get<Publisher[]>(this.url + '/Publisher/GetPublishers');
  }

  getPublisherById(id: any): Observable<any> {
    return this._http.get<Publisher[]>(this.url + '/Publisher/GetPublisher/' + id);
  }

  createPublisher(publisher: Publisher): Observable<Publisher> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.post<Publisher>(this.url + '/Publisher/InsertPublisher/', publisher, httpOptions);
  }

  updatePublisher(id: any, publisher: Publisher): Observable<Publisher> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.put<Publisher>(this.url + '/Publisher/UpdatePublisher/' + id, publisher, httpOptions);
  }

  deletePublisherById(id: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.delete<number>(this.url + '/Publisher/DeletePublisher/' + id, httpOptions);
  }
}
