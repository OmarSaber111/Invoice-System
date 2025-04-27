export interface InvoiceCreationInterface {
    totalPrice: number,
    quantity: number,
    sellerId: number,
    buyerId: number,
    productId: number,
    payment: boolean
}
