import { Component } from '@angular/core';
import { Order } from 'src/app/models/order.model';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-add-tutorial',
  templateUrl: './add-tutorial.component.html',
  styleUrls: ['./add-tutorial.component.css'],
})
export class AddTutorialComponent {
  order: Order = {
    Id: null,
    code: '',
    type: 1,
    status: 1,
    notes: '',
  };
  submitted = false;

  constructor(private orderService: OrderService) {}

  saveOrder(): void {
    const data = {
      code: this.order.code,
      type: 1,
      status: 1,
      notes: this.order.notes,
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
    };
  }
}
