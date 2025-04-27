import { provideHttpClient } from '@angular/common/http';
declare var bootstrap: { Modal: { new(arg0: HTMLElement): any; getInstance: (arg0: HTMLElement) => any; }; };
// correct that statment
import { ProductsService } from './../../Services/products.service';
import { Product } from './../../models/product.model';
import { Component, OnInit } from '@angular/core';
import { Seller } from '../../models/seller.model';
import { RouterLink } from '@angular/router';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { SellerService } from '../../Services/seller.service';

@Component({
  selector: 'app-front-store',
  standalone: true,
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './front-store.component.html',
  styleUrl: './front-store.component.scss'
})
export class FrontStoreComponent implements OnInit {
  govername: string = "";
  productDetails: boolean = false;
  seller: Seller = {} as Seller;
  selectedProduct: Product = {} as Product;
  products: Product[] = [];
  sellerId = parseInt(localStorage.getItem('sellerId') || '0', 10);
  isEditing: boolean = false;
  curName : string = "";
  curAmount : number=0;
  curPrice : number=0;
  // Form Controls
  productNameControl = new FormControl('');
  amountControl = new FormControl(0);
  priceControl = new FormControl(0);

  constructor(private productsService: ProductsService,private sellerService:SellerService) {}

  ngOnInit(): void {
    this.getAllProducts();

      // get the seller by the sent id
      this.sellerService.getSellerById(this.sellerId).subscribe({
      next: (response) => {
      this.seller=response.Data
      },
      error: (err) => {
      console.error('Failed to fetch seller:', err);
  }
      });
  }

  //Get all products
  getAllProducts():void{
    // get all the products by the seller id
this.productsService.getProductsBySellerId(this.sellerId).subscribe({
  next: (response) => {
    this.products = response.Data;
    console.log('Products loaded:', this.products);
  },
  error: (err) => {
    console.error('Failed to fetch products:', err);
  }
    });
  }

  openAddProductModal(sellerId: number): void {
    // Reset form controls
    this.productNameControl.setValue('');
    this.amountControl.setValue(0);
    this.priceControl.setValue(0);

    // Show modal using Bootstrap
    const modalElement = document.getElementById('productModal');
    if (modalElement) {
      const modalInstance = new bootstrap.Modal(modalElement);
      modalInstance.show();
    }
  }

  onSubmit(): void {
    const newProduct = {
      name: this.productNameControl.value || '',
      amount: this.amountControl.value || 0,
      price: this.priceControl.value || 0,
      sellerId: this.sellerId,
    };
    console.log('Submitting product:', newProduct);
    this.productsService.createProduct(newProduct).subscribe({
      next: (createdProduct) => {
        this.products.push(createdProduct.Data);
        console.log('Full API response:', createdProduct);
        console.log('Created product data:', createdProduct?.Data);
        this.closeModal();
      },
      error: (err) => {
        console.error('Error creating product:', err);
      }
    });
  }
  closeModealDetails():void{
    const modalElement = document.getElementById('productDetailsModal');
    if (modalElement) {
      const modalInstance = bootstrap.Modal.getInstance(modalElement);
      modalInstance.hide();
    }
  }
  closeModal(): void {
    const modalElement = document.getElementById('productModal');
    if (modalElement) {
      const modalInstance = bootstrap.Modal.getInstance(modalElement);
      modalInstance.hide();
    }
  }

  openModal(product: Product) {
    this.selectedProduct = product;
    const modalElement = document.getElementById('productDetailsModal');
    if (modalElement) {
      const modalInstance = new bootstrap.Modal(modalElement);
      modalInstance.show();
    }
  }
  deleteProduct(id:number):void{
    this.productsService.deleteProduct(id).subscribe({
      next:(response)=>{
        console.log(response.Data);
            this.closeModealDetails();
            this.getAllProducts();
      },
      error(err){
        console.log('Faild to delete ',err)
      }
    });
  }
  editProduct(product:Product){
    this.isEditing = true;
    this.curAmount=product.amount;
    this.curName = product.name;
    this.curPrice = product.price;
    if (this.isEditing && this.selectedProduct) {
      this.productNameControl.setValue(this.selectedProduct.name);
      this.amountControl.setValue(this.selectedProduct.amount);
      this.priceControl.setValue(this.selectedProduct.price);
    }
  }
  saveProduct(id:number):void{
    const toEdit : Product = {
      id:id,
      name:this.productNameControl.value?this.productNameControl.value:this.selectedProduct.name,
      amount:this.amountControl.value?this.amountControl.value:this.selectedProduct.amount,
      price:this.priceControl.value?this.priceControl.value:this.selectedProduct.price,
      sellerId:this.sellerId,
      sellerName:this.seller.name
    }
    this.productsService.updateProduct(toEdit).subscribe({
      next: (response) =>{
        console.log('updated product',toEdit);
        this.isEditing=false;
        // clear all form controls
        this.productNameControl.reset();
        this.amountControl.reset();
        this.priceControl.reset();
        this.selectedProduct.name = toEdit.name;
        this.selectedProduct.amount = toEdit.amount;
        this.selectedProduct.price = toEdit.price
        this.getAllProducts()
      },
      error:(err) =>{
        console.log('Failed to update product:',err);
      }
    })
  }
}
