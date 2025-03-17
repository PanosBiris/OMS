import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from '../models/order.model';

const baseUrl = '/api/Order';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(private http: HttpClient) {}

  getOrdersByCustomerId(customerId: any): Observable<Order[]> {
    return this.http.get<Order[]>(`${baseUrl}/GetOrdersByCustomerId/?customerId=${customerId}`);
  }

  get(id: any): Observable<Order> {
    return this.http.get<Order>(`${baseUrl}/GetOrderById/?orderId=${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(`${baseUrl}/create`, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }
}
