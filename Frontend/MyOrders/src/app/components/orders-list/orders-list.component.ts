import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models/order.model';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css'],
})
export class OrdersListComponent implements OnInit {
  orders?: Order[];
  currentOrder: Order = { Id: null, type: 1, status: 1 };
  currentIndex = -1;
  title = '';

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.retrieveOrders();
  }

  retrieveOrders(): void {
    this.orderService.getOrdersByCustomerId('00000000-0000-0000-0000-000000000000').subscribe({
      next: (data) => {
        this.orders = data;
        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

  refreshList(): void {
    this.retrieveOrders();
    this.orders = [];
    this.currentIndex = -1;
  }

  setActiveOrder(order: Order, index: number): void {
    this.currentOrder = order;
    this.currentIndex = index;
  }
}
