import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddOrderComponent } from './components/add-order/add-order.component';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { OrdersListComponent } from './components/orders-list/orders-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AddOrderComponent,
    OrderDetailsComponent,
    OrdersListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
