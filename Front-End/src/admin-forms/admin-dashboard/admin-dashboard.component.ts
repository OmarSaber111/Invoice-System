import { Component, OnInit } from '@angular/core';
import { UserService } from "../../Services/user.service";
import { User } from '../../models/user.model';
import { HeaderComponent } from "../../UI/header/header.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  standalone: true,
  imports: [HeaderComponent, CommonModule, FormsModule],
  styleUrls: ['./admin-dashboard.component.scss']
})
export class AdminDashboardComponent implements OnInit {
  users: User[] = [];
  selectedUser: User | null = null;
  selectedGroup: string | null = null;
  isLoading: boolean = false;
  errorMessage: string | null = null;
  groupId: number = 0;
  // Permission management
   allowedPermissions = [
    // Seller Permissions
    { group: 'Seller', action: 'Create Product', permission: true },
    { group: 'Seller', action: 'View Invoices', permission: true },
    { group: 'Seller', action: 'Delete Product', permission: true },
    { group: 'Seller', action: 'Edit Front Store', permission: true },

    // Buyer Permissions
    { group: 'Buyer', action: 'Shopping', permission: true },
    { group: 'Buyer', action: 'Add Item to Cart', permission: true },
    { group: 'Buyer', action: 'Buy Product', permission: true },
    { group: 'Buyer', action: 'Pay an Invoice', permission: true },
  ];
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.isLoading = true;
    this.errorMessage = null;

    this.userService.getAllUsers().subscribe({
      next: (users) => {
        console.log(users);
        this.users = users;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = err.message || 'Failed to load users';
        this.isLoading = false;
      }
    });
  }

  selectGroup(group: string): void {
    this.selectedGroup = group;
  }

  deleteUser(user: User): void {
      this.userService.deleteUser(user.id).subscribe({
        next: (res) => {
          this.loadUsers();
        },
        error: (err) => this.errorMessage = err.message || 'Failed to delete user'
      });
  }

  assignUserToGroup(user: User, group:string): void {
    this.groupId = group === 'Seller Group' ? 2 : 3;
    this.userService.updateUserGroup(user.id, this.groupId).subscribe({
      next: (res) => {
        console.log(res.Data);
        user.group = group;
        this.selectedUser = null;
        this.loadUsers();
      },
      error: (err) => this.errorMessage = err.message || 'Failed to update user group'
    });
  }

  toggleAction(group: string, action: string): void {
    const permission = this.allowedPermissions.find(p => p.group === group && p.action === action);
    if (permission) {
      permission.permission = !permission.permission;
    }
  }

  savePermissions(): void {
    this.selectedGroup = null;
  }
}
