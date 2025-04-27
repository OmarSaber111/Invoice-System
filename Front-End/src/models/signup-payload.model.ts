export interface SignupPayloadModel {
  name: string;
  username: string;
  email: string;
  password: string;
  nationalId: string;
  isSeller: boolean;
  storeName?: string;
  productType?: string;
  governmentId?: number;
}
