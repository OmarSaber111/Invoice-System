import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.model';
import { Router } from '@angular/router';
import { ProductsService } from '../../Services/products.service';
@Component({
  selector: 'app-product-carousel',
  standalone: true,
  imports: [],
  templateUrl: './product-carousel.component.html',
  styleUrl: './product-carousel.component.scss'
})
export class ProductCarouselComponent implements OnInit{
  constructor(private router:Router, private productService:ProductsService){ }
  ngOnInit(): void {
    this.getAllProducts();
  }

  products:Product[] = [];
  selectedProduct:Product={} as Product;

  getAllProducts(): void {
    this.productService.getAllProducts().subscribe({
      next: (res) => {
        this.products = res.Data;
      },
      error: (err) => {
        console.error('Failed to load products', err);
      }
    });
  }

}
