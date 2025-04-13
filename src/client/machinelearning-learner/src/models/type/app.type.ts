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

export type PropertyListing = {
  id: string;
  title: string;
  beds: number;
  bath: number;
  area: number;
  address: string;
  type: string;
  purpose: string;
  floorPlan: string;
  url: string;
  price: number;
  addressValue: number;
  typeValue: number;
};

export type SearchProperty = {
  bed?: number;
  bath?: number;
  area?: number;
  addressValue?: number;
  typeValue?: number;
  skip: number;
  length: number;
};
