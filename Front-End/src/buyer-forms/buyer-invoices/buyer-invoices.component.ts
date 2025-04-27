export declare var bootstrap: any;
import { ProductsService } from './../../Services/products.service';
import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from "../../UI/header/header.component";
import { Invoice } from '../../models/invoice.model';
import { CommonModule } from '@angular/common';
import { FooterComponent } from "../../UI/footer/footer.component";
import { ActivatedRoute, Router } from '@angular/router';
import { InvoiceService } from '../../Services/invoice.service';

@Component({
  selector: 'app-buyer-invoices',
  standalone: true,
  imports: [HeaderComponent, CommonModule, FooterComponent],
  templateUrl: './buyer-invoices.component.html',
  styleUrl: './buyer-invoices.component.scss'
})
export class BuyerInvoicesComponent implements OnInit{
  pay:boolean = false;
  buyerIdStr : string | null = null;
  buyerId : number = 0;
  selectedInvoice:Invoice = {} as Invoice;
  invoices: Invoice[] = [];
  prices : number[] = [];
  constructor(private route: ActivatedRoute,private invoiceService : InvoiceService,private productService : ProductsService){}
  ngOnInit() {
    this.buyerIdStr = localStorage.getItem("buyerId");
    this.buyerId = this.buyerIdStr? parseInt(this.buyerIdStr,10):0;

    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      this.buyerId = idParam ? Number(idParam) : 0;
      if (!idParam) {
        console.error('No Buyer ID provided in the route');
      }
      this.getInvoices();
    });

  }
    openPaymentModal(invoice: Invoice): void {
    console.log('Paying invoice:', invoice.id);
    this.pay = true;
    // update it in the database
    this.invoiceService.updateInvoice(invoice).subscribe({
      next: (res) => {
        invoice.payment = true;
        console.log(res.Data);
      },
      error: (err) => {
        console.error(err);
      }
    });
    const modalElement = document.getElementById('successPaymentModal');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    } else {
      console.error('Payment modal element not found');
    }
  }
  openInvoiceModal(invoice: Invoice): void {
    this.selectedInvoice = invoice;
    const modal = new bootstrap.Modal(document.getElementById('invoiceDetailsModal')!);
    modal.show();
  }
  // get all invoices done by this buyer
  getInvoices():void{
    this.invoiceService.getInvoicesByBuyerId(this.buyerId).subscribe({
      next: (res) => {
        this.invoices = res.Data;
        console.log(res.Data);
      },
      error: (err) => {
        console.error(err);
      }
    });

  }
    deleteInvoice(id: number): void {
      this.invoiceService.deleteInvoice(id).subscribe({
        next: (res) => {
          console.log('Invoice deleted successfully:', res);
          this.getInvoices();
        },
        error: (err) => {
          console.error('Failed to delete invoice:', err);
        }
      });
    }
}
