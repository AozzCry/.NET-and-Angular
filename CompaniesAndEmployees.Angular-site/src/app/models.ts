export interface Employee {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
  createdDate: Date;
}
export interface EmployeeVm {
  firstName: string;
  lastName: string;
  email: string;
  phone: string;
}

export interface Company {
  id: number;
  name: string;
  createdDate: Date;
}
export interface CompanyVm {
  name: string;
  createdDate: Date;
}

export interface UserLogin {
  email: string;
  password: string;
}

export interface UserRegister {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}

export interface LoginResponse {
  userId: string;
  token: string;
  firstName: string;
  lastName: string;
  email: string;
}
