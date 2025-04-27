import { Invoice } from './../../models/invoice.model';
export declare var bootstrap: any;
import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from "../../UI/header/header.component";
import { CommonModule } from '@angular/common';
import { FooterComponent } from "../../UI/footer/footer.component";
import { ActivatedRoute } from '@angular/router';
import { InvoiceService } from '../../Services/invoice.service';
import { ProductsService } from '../../Services/products.service';
@Component({
  selector: 'app-seller-invoices',
  standalone: true,
  imports: [CommonModule, FooterComponent, HeaderComponent],
  templateUrl: './seller-invoices.component.html',
  styleUrl: './seller-invoices.component.scss'
})
export class SellerInvoicesComponent implements OnInit{
  selectedInvoice: Invoice ={} as Invoice;
  invoices: Invoice[] =[];
  sellerId : number = 0;
  sellerIdStr : string | null = '';
  constructor(private route: ActivatedRoute,private invoiceService : InvoiceService,private productService : ProductsService){}
  openInvoiceModal(invoice: Invoice): void {
    this.selectedInvoice = invoice;
    const modal = new bootstrap.Modal(document.getElementById('invoiceDetailsModal')!);
    modal.show();
  }
  ngOnInit() {
    this.sellerIdStr = localStorage.getItem("sellerId");
    this.sellerId = this.sellerIdStr? parseInt(this.sellerIdStr,10):0;

    this.route.paramMap.subscribe(params => {
      const idParam = params.get('id');
      this.sellerId = idParam ? Number(idParam) : 0;
      if (!idParam) {
        console.error('No Seller ID provided in the route');
      }
      this.getInvoices();
    });
  }
  getInvoices():void{
    this.invoiceService.getInvoicesBySellerId(this.sellerId).subscribe({
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

        // Close the modal
        const modalElement = document.getElementById('invoiceDetailsModal');
        if (modalElement) {
          const modalInstance = bootstrap.Modal.getInstance(modalElement);
          modalInstance.hide();
        }
        this.getInvoices();
      },
      error: (err) => {
        console.error('Failed to delete invoice:', err);
      }
    });
  }


}
