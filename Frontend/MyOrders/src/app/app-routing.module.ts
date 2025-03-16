import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersListComponent } from './components/orders-list/orders-list.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { AddOrderComponent } from './components/add-order/add-order.component';

const routes: Routes = [
  { path: '', redirectTo: 'orders', pathMatch: 'full' },
  { path: 'orders', component: OrdersListComponent },
  { path: 'orders/:id', component: OrderDetailsComponent },
  { path: 'add', component: AddOrderComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
