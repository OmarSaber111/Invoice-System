import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { ApiResponse } from '../models/api-response.model';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {
;
constructor(private httpclient:HttpClient) {}

api_url = 'http://invoice.somee.com/api/Product';

   // Get all products
   getAllProducts(): Observable<ApiResponse<Product[]>> {
    return this.httpclient.get<ApiResponse<Product[]>>('http://invoice.somee.com/api/Product/Get-All-Products');
  }

  // Get all products by seller id
  getProductsBySellerId(sellerId: number): Observable<ApiResponse<Product[]>> {
    return this.httpclient.get<ApiResponse<Product[]>>(`${this.api_url}/Get-All-Products-BySellerId/${sellerId}`);
  }


  // Get a product by ID
  getProductById(id: number): Observable<ApiResponse<Product>> {
    return this.httpclient.get<ApiResponse<Product>>(`http://invoice.somee.com/api/Product/Get-Product-ById/${id}`);
  }

  // Create a new product
  createProduct(product: {
    name: string,
      amount: number,
      price: number
      sellerId:number,
  }): Observable<ApiResponse<Product>> {
    return this.httpclient.post<ApiResponse<Product>>('http://invoice.somee.com/api/Product/Create-Product', product);
  }

  // Update an existing product
  updateProduct(product: Product): Observable<ApiResponse<Product>> {
    return this.httpclient.put<ApiResponse<Product>>(`${this.api_url}/Update-Product/`, product);
  }
  // delete an existing product
  deleteProduct(id: number): Observable<ApiResponse<Product>> {
    return this.httpclient.delete<ApiResponse<Product>>(`${this.api_url}/Delete-Product/${id}`);
  }

}
