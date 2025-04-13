import { inject, Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { baseUrl, SearchProperty } from '../../models/type/app.type';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PropertyService {
  http = inject(HttpService);
  constructor() {}

  getInitialData() {
    return this.http.get(`${baseUrl}/property/initial`);
  }

  getPropertyListData(searchProperty: SearchProperty) {
    const params = new HttpParams()
      .set('bed', searchProperty.bed?.toString() || '')
      .set('bath', searchProperty.bath?.toString() || '')
      .set('area', searchProperty.area?.toString() || '')
      .set('addressValue', searchProperty.addressValue?.toString() || '')
      .set('typeValue', searchProperty.typeValue?.toString() || '')
      .set('skip', searchProperty.skip?.toString() || '')
      .set('length', searchProperty.length?.toString() || '');
    return this.http.get(`${baseUrl}/property/paged`, params);
  }

  predictPrice(searchProperty: SearchProperty) {
    return this.http.post(`${baseUrl}/property/predict-price`, searchProperty);
  }
}
