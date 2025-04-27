export interface ApiResponse<T> {
  Data: T;
  IsSucceeded: boolean;
  Error: string | null;
  ErrorMessage: string | null;
  StatusCode: number | null;
}
