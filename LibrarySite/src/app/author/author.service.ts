import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Author } from './author';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  url = localStorage.getItem('url');

  constructor(private _http: HttpClient) { }

  getAllAuthor(): Observable<Author[]> {
    return this._http.get<Author[]>(this.url + '/Author/GetAuthors');
  }

  getAuthorById(id: any): Observable<any> {
    return this._http.get<Author>(this.url + '/Author/GetAuthor/' + id);
  }

  createAuthor(author: Author): Observable<Author> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.post<Author>(this.url + '/Author/InsertAuthor/', author, httpOptions);
  }

  updateAuthor(id: any, author: Author): Observable<Author> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.put<Author>(this.url + '/Author/UpdateAuthor/' + id, author, httpOptions);
  }

  deleteAuthor(id: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.delete<number>(this.url + '/Author/DeleteAuthor/' + id, httpOptions);
  }

}
