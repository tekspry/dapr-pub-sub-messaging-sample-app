import { OrderState } from "./orderState";

export type Order = {    
    orderId: string; 
    productId: string;
    customerId: string;
    productCount: number;   
    orderStatus: OrderState; 
}