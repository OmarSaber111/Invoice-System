import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse } from '../models/api-response.model';
import { User } from '../models/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private apiUrl = 'http://invoice.somee.com/api';
  private assignUserToGPApi = `${this.apiUrl}/Admin/Assign-User-to-Group`;

  constructor(private http: HttpClient) {}

  private handleResponse<T>(response: Observable<ApiResponse<T>>): Observable<T> {
    return response.pipe(
      map(res => {
        if (!res.IsSucceeded) {
          throw new Error(res.ErrorMessage || res.Error || 'Unknown error');
        }
        return res.Data;
      })
    );
  }

  getAllUsers(): Observable<User[]> {
    return this.handleResponse(
      this.http.get<ApiResponse<User[]>>(`${this.apiUrl}/Users/Get-All-Users`)
    );
  }

  updateUserGroup(userId: number, groupId: number): Observable<ApiResponse<string>> {
    return this.http.post<ApiResponse<string>>(this.assignUserToGPApi,{userId,groupId});
  }
  deleteUser(userId: number): Observable<ApiResponse<string>> {
    return this.http.delete<ApiResponse<string>>( `http://invoice.somee.com/api/Users/Delete-User?userid=${userId}`);
  }
}
