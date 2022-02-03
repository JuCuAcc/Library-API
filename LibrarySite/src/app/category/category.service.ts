import { Injectable } from '@angular/core';

import {Observable } from 'rxjs';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import {Category } from './category';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  url = localStorage.getItem('url');
  constructor(private _http: HttpClient) { }

  getAllCategory(): Observable<Category[]> {
    return this._http.get<Category[]>(this.url + '/Category/GetCategories');
  }

  getCategoryById(id:any): Observable<any> {
    return this._http.get<Category[]>(this.url + '/Category/GetCategory/' + id);
  }

  createCategory(category: Category): Observable<Category> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.post<Category>(this.url + '/Category/InsertCategory/', category, httpOptions);
  }

  updateCategory(id:any, category: Category): Observable<Category> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.put<Category>(this.url + '/Category/UpdateCategory/' + id, category, httpOptions);
  }

  deleteCategoryById(id: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this._http.delete<number>(this.url + '/Category/DeleteCategory/' + id, httpOptions);
  }
}
