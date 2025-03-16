import { Component } from '@angular/core';
import { MenuItem } from 'src/app/models/menuItem.model';
import { MenuService } from 'src/app/services/menu.service';
import { Order } from 'src/app/models/order.model';
import { OrderItem } from 'src/app/models/orderItem.model';
import { OrderService } from 'src/app/services/order.service';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'app-add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css'],
})
export class AddOrderComponent {
  order: Order = {
    Id: null,
    code: '',
    type: 1,
    status: 1,
    notes: '',
    items:[]
  };
  submitted = false;
  menuItemId = 0;
  quantity = 0;
  specialInstructions = '';
  menuItems!: Observable<MenuItem[]>;

  constructor(private orderService: OrderService, private menuService: MenuService) {}

  ngOnInit(): void {
    this.retrieveMenuItems();
    this.generateCode();
  }

  saveOrder(): void {
    const data = {
      code: this.order.code,
      type: 1,
      status: 1,
      notes: this.order.notes,
      items: this.order.items
    };

    this.orderService.create(data).subscribe({
      next: (res) => {
        console.log(res);
        this.submitted = true;
      },
      error: (e) => console.error(e)
    });
  }

  newOrder(): void {
    this.submitted = false;
    this.order = {
      Id: null,
      code: '',
      type: 1,
      status: 1,
      notes: '',
      items: [],
    };
  }

  addHandler() {
    this.order.items = this.order.items || [];
    this.order.items.push({
      menuItemId: this.menuItemId,
      quantity: this.quantity,
      specialInstructions: this.specialInstructions
     })
  }

  retrieveMenuItems(): void {
    this.menuService.getAll().subscribe({
      next: (data) => {
        this.menuItems = new Observable(observer => observer.next(data));
        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

  generateCode(): void {
    this.order.code = Math.random().toString(36).substring(5).toUpperCase();
  }
}
