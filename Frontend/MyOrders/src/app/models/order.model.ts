import { OrderItem } from './orderItem.model';

export class Order {
  Id:any;
  code?: string;
  type: number = 1;
  status: number = 1;
  notes?: string;
  items?: OrderItem[];
}