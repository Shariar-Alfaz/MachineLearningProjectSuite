export type HttpAppError = {
  errorMesage: string;
  statusCode: number;
};

export type ResponseModel<T> = {
  message: string;
  data: T;
  isSuccess: boolean;
  listData: T[];
  totalRecords: number;
};

export type Address = {
  address: string;
  addressValue: number;
};

export type Type = {
  type: string;
  typeValue: number;
};

export type InitRequestModel = {
  addresses: Address[];
  types: Type[];
};

export const baseUrl = 'https://localhost:7271/api/v1';
