import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MenuItem } from '../models/menuItem.model';

const baseUrl = '/api/Menu/Get';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<MenuItem[]> {
    return this.http.get<MenuItem[]>(baseUrl);
  }

  get(id: any): Observable<MenuItem> {
    return this.http.get<MenuItem>(`${baseUrl}/${id}`);
  }
}
