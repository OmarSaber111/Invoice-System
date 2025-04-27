import { AuthGuard } from './../guards/auth.guard';
import { Routes } from '@angular/router';
import { CanActivate } from '@angular/router';
import { HomeComponent } from '../guest-forms/home/home.component';
import { SignInComponent } from '../auth-forms/sign-in/sign-in.component';
import { SignUpComponent } from '../auth-forms/sign-up/sign-up.component';
import { AdminDashboardComponent } from '../admin-forms/admin-dashboard/admin-dashboard.component';
import { BuyerInvoicesComponent } from '../buyer-forms/buyer-invoices/buyer-invoices.component';
import { CheckoutComponent } from '../buyer-forms/checkout/checkout.component';
import { ShoppingComponent } from '../buyer-forms/shopping/shopping.component';
import { AboutUsComponent } from '../guest-forms/about-us/about-us.component';
import { FrontStoreComponent } from '../seller-forms/front-store/front-store.component';
import { SellerInvoicesComponent } from '../seller-forms/seller-invoices/seller-invoices.component';
import { NotFoundComponent } from '../UI/not-found/not-found.component';
import { AdminGuard } from '../guards/admin.guard';
import { BuyerGuard } from '../guards/buyer.guard';
import { SellerGuard } from '../guards/seller.guard';
import { ContactUsComponent } from '../guest-forms/contact-us/contact-us.component';

export const routes: Routes = [
  {path:'', redirectTo:'/home',pathMatch:'full'},
  {path:'signup', component:SignUpComponent,title:"Sign up"},
  {path:'signin',component:SignInComponent,title:"Log in"},
  {path:'home',component:HomeComponent,title:"Home"},
  {path:'contactus',component:ContactUsComponent,title:"Contact Us!"},
  {path:'admindashboard',component:AdminDashboardComponent,title:"manage platform",canActivate:[AuthGuard,AdminGuard]},
  {path:'buyerinvoices/:id',component:BuyerInvoicesComponent,title:"Invoices",canActivate:[AuthGuard,BuyerGuard]},
  {path:'checkout/:id',component:CheckoutComponent,title:"Checkout",canActivate:[AuthGuard,BuyerGuard]},
  {path:'shopping',component:ShoppingComponent,title:"shopping",canActivate:[AuthGuard,BuyerGuard]},
  {path:'aboutus',component:AboutUsComponent,title:"About Us"},
  {path:'frontstore/:id',component:FrontStoreComponent,title:"Front Store",canActivate:[AuthGuard,SellerGuard]},
  {path:'sellerinvoices/:id',component:SellerInvoicesComponent,title:"Invoices",canActivate:[AuthGuard,SellerGuard]},
  {path:'**',component:NotFoundComponent,title:"Not found"}
];
