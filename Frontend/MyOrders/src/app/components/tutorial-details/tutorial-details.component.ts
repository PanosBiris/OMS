import { Component, Input, OnInit } from '@angular/core';
import { OrderService } from 'src/app/services/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from 'src/app/models/order.model';

@Component({
  selector: 'app-tutorial-details',
  templateUrl: './tutorial-details.component.html',
  styleUrls: ['./tutorial-details.component.css'],
})
export class TutorialDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentOrder: Order = {
    Id: null,
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

  updatePublished(status: boolean): void {
    const data = {
      code: this.currentOrder.code,
      notes: this.currentOrder.notes
    };

    this.message = '';

    this.orderService.update(this.currentOrder.Id, data).subscribe({
      next: (res) => {
        console.log(res);        
        this.message = res.message
          ? res.message
          : 'The status was updated successfully!';
      },
      error: (e) => console.error(e)
    });
  }

  updateOrder(): void {
    this.message = '';

    this.orderService
      .update(this.currentOrder.Id, this.currentOrder)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.message = res.message
            ? res.message
            : 'This tutorial was updated successfully!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteOrder(): void {
    this.orderService.delete(this.currentOrder.Id).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/tutorials']);
      },
      error: (e) => console.error(e)
    });
  }
}
