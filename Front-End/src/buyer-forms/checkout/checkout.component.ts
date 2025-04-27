import { ActivatedRoute, Router } from '@angular/router';
import { Product } from './../../models/product.model';
import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../Services/products.service';
import { InvoiceService } from '../../Services/invoice.service';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-checkout',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent implements OnInit {
  product: Product = {} as Product;
  quantity : number = 1;
  totalPrice: number = 0;
  sellerId: number = 0;
  buyerId: number= 0;
  buyerIdStr : string | null =null;
  productId: number = 0;
  payment: boolean = false;
  quantityControl = new FormControl();

  constructor(private route: ActivatedRoute,private productService:ProductsService,private invoiceService:InvoiceService,private router:Router) {}
  saveQuantity():void{
    this.quantity = this.quantityControl.value;
    this.totalPrice = this.quantity*this.product.price;
  }
  ngOnInit() {
    this.buyerIdStr = localStorage.getItem("buyerId");
    this.buyerId = this.buyerIdStr? parseInt(this.buyerIdStr,10):0;
    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      this.productId = idParam ? Number(idParam) : 0;
      if (!idParam) {
        console.error('No product ID provided in the route');
      }
      this.productService.getProductById(this.productId).subscribe({
        next: (res) => {
          this.product = res.Data;
        },
        error: (err) => {
          console.error(err);
        }
      });
    });
  }
  Paycheckout(){
    if(this.product.amount>= this.quantity){
      this.product.amount -= this.quantity;
    this.productService.updateProduct(this.product).subscribe({
      next:(res)=>{
        console.log(res);
      },
      error:(err)=>{console.log(err)}
    });

    this.invoiceService.createInvoice({
      totalPrice:this.product.price,
      sellerId: this.product.sellerId,
      productId: this.product.id,
      quantity:this.quantity,
      buyerId : this.buyerId,
    payment: true
    }).subscribe({
      next:()=>{
        this.router.navigate(['/buyerinvoices', this.buyerId]);
      },
      error:(err)=>{console.log(err)}
    });
    }
    else{
      alert("Quantity out of stock!");
    }

  }
  AddToCart(){
    if(this.product.amount>= this.quantity){
      this.invoiceService.createInvoice({
        totalPrice:this.product.price,
        sellerId: this.product.sellerId,
        productId: this.product.id,
        quantity:this.quantity,
        buyerId : parseInt(localStorage.getItem("buyerId") ?? "0", 10),
      payment: false
      }).subscribe({
        next:()=>{
          this.router.navigate(['/buyerinvoices', this.buyerId]);
        },
        error:(err)=>{console.log(err)}
      });
    }
    else{
      alert("Quantity out of stock!");
    }
  }
}
