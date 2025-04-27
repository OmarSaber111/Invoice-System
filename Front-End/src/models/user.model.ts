import { UserGroupModel } from "./user-group.model";

export interface User {
  id: number;
  name?: string;
  email?: string;
  nationalId?: string;
  group:string;
  createdAt?: Date;
  groups: UserGroupModel[];
}
