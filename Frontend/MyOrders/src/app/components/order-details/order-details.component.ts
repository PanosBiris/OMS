import { Component, Input, OnInit } from '@angular/core';
import { OrderService } from 'src/app/services/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from 'src/app/models/order.model';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentOrder: Order = {
    id: null,
    code: '',
    type: 1,  // 1 = Order, 2 = Quote
    status: 1,  // 1 = New, 2 = In Progress, 3 = Completed  
  };

  message = '';

  constructor(
    private orderService: OrderService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getOrder(this.route.snapshot.params['id']);
    }
  }

  getOrder(id: string): void {
    this.orderService.get(id).subscribe({
      next: (data) => {
        this.currentOrder = data;
        console.log(data);
      },
      error: (e) => console.error(e)
    });
  }

  updateOrder(): void {
    this.message = '';

    this.orderService
      .update(this.currentOrder.id, this.currentOrder)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message
            ? res.message
            : 'This order was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }
}
