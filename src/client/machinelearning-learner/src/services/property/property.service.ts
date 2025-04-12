import { inject, Injectable } from '@angular/core';
import { HttpService } from '../http/http.service';
import { baseUrl } from '../../models/type/app.type';

@Injectable({
  providedIn: 'root',
})
export class PropertyService {
  http = inject(HttpService);
  constructor() {}

  getInitialData() {
    return this.http.get(`${baseUrl}/property/initial`);
  }
}
