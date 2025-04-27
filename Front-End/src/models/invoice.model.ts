export interface Invoice {
    id: number,
    totalPrice: number,
    quantity: number,
    sellerId: number,
    buyerId: number,
    productId: number,
    productPrice:number,
    payment: boolean,
    createdAt: Date
  }
