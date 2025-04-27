import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Seller } from '../models/seller.model';
import { ApiResponse } from '../models/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  private api_url = 'http://invoice.somee.com/api/sellers';

  constructor(private http: HttpClient) {}
// 1. Get all sellers
getAllSellers(): Observable<ApiResponse<Seller[]>> {
  return this.http.get<ApiResponse<Seller[]>>(this.api_url);
}

// 2. Get seller by ID
getSellerById(id: number): Observable<ApiResponse<Seller>> {
  return this.http.get<ApiResponse<Seller>>(`${this.api_url}/Get-Seller-ById/${id}`);
}

// 3. Update a seller
updateSeller(id: number, seller: Seller): Observable<ApiResponse<Seller>> {
  return this.http.put<ApiResponse<Seller>>(`${this.api_url}/${id}`, seller);
}

// 4. Remove a seller
deleteSeller(id: number): Observable<ApiResponse<void>> {
  return this.http.delete<ApiResponse<void>>(`${this.api_url}/${id}`);
}
}
