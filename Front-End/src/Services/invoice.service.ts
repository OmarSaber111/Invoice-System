import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { Invoice } from '../models/invoice.model';
import { InvoiceCreationInterface } from '../models/invoice-creation.interface';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private baseUrl = 'http://invoice.somee.com/api/Invoice';
  constructor(private http: HttpClient) { }

  // Get all invoices
  getAllInvoices(): Observable<ApiResponse<Invoice[]>> {
    return this.http.get<ApiResponse<Invoice[]>>(`${this.baseUrl}`);
  }

  // Get invoice by ID
  getInvoiceById(id: number): Observable<ApiResponse<Invoice>> {
    return this.http.get<ApiResponse<Invoice>>(`${this.baseUrl}/${id}`);
  }

  // Get invoices by seller ID
  getInvoicesBySellerId(sellerId: number): Observable<ApiResponse<Invoice[]>> {
    return this.http.get<ApiResponse<Invoice[]>>(`${this.baseUrl}/Get-Invoice-BySellerId/${sellerId}`);
  }

  // Get invoices by buyer ID
  getInvoicesByBuyerId(buyerId: number): Observable<ApiResponse<Invoice[]>> {
    return this.http.get<ApiResponse<Invoice[]>>(`${this.baseUrl}/Get-Invoice-ByBuyerId/${buyerId}`);
  }

  // Create a new invoice
  createInvoice(invoiceData: InvoiceCreationInterface): Observable<ApiResponse<Invoice>> {
    return this.http.post<ApiResponse<Invoice>>(`${this.baseUrl}/Create-Invoice`, invoiceData);
  }

  // Delete an invoice
  deleteInvoice(id: number): Observable<any>{
    return this.http.delete(`${this.baseUrl}/Delete-Invoice/${id}`);
  }

  // Update an invoice
  updateInvoice(invoice:Invoice):Observable<ApiResponse<string>>{
    return this.http.put<ApiResponse<string>>(`${this.baseUrl}/Update-Invoice`,invoice);
  }

}
