import { Customer } from "./customer";
import { Order } from "./order"; 

export type OrderDetails ={
    orderDate: Date;
    customerDetails: Customer;
    orders: Array<Order>[];
}