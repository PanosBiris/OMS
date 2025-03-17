import { OrderItem } from './orderItem.model';

export class Order {
  id:any;
  code?: string;
  orderTime?: Date;
  type: number = 1;
  status: number = 1;
  notes?: string;
  items?: OrderItem[];
}