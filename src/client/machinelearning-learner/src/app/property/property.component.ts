import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectModule } from 'primeng/select';
import { FormsModule } from '@angular/forms';
import {
  InitRequestModel,
  PropertyListing,
  ResponseModel,
  SearchProperty,
} from '../../models/type/app.type';
import { PropertyService } from '../../services/property/property.service';
import { DataViewLazyLoadEvent, DataViewModule } from 'primeng/dataview';
import { Data } from '@angular/router';
@Component({
  selector: 'app-property',
  imports: [
    ButtonModule,
    ToolbarModule,
    CommonModule,
    InputNumberModule,
    SelectModule,
    FormsModule,
    DataViewModule,
  ],
  templateUrl: './property.component.html',
  styleUrl: './property.component.css',
})
export class PropertyComponent {
  initData: InitRequestModel = {
    addresses: [],
    types: [],
  };

  propertylist = signal<PropertyListing[]>([]);

  propertyService = inject(PropertyService);

  searchProperty = {} as SearchProperty;

  predictedPrice!: number;
  length = 50;
  totalRecords = 0;

  ngOnInit() {
    this.getInitialData();
  }

  getInitialData() {
    this.propertyService
      .getInitialData()
      .subscribe((res: ResponseModel<InitRequestModel>) => {
        this.initData = res.data;
      });
  }

  getPropertyList() {
    this.propertyService
      .getPropertyListData(this.searchProperty)
      .subscribe((res: ResponseModel<PropertyListing>) => {
        this.propertylist.set(res.listData);
        this.totalRecords = res.totalRecords;
        console.log(this.propertylist);
      });
  }

  loadData(event: any) {
    this.searchProperty.skip = event.first;
    this.searchProperty.length = this.length;
    this.getPropertyList();
  }

  searchPropertyList() {
    this.searchProperty.skip = 0;
    this.searchProperty.length = this.length;
    this.getPropertyList();
    this.predictPrice();
  }

  predictPrice() {
    if (
      this.searchProperty.bed &&
      this.searchProperty.bath &&
      this.searchProperty.area
    ) {
      this.propertyService
        .predictPrice(this.searchProperty)
        .subscribe((res: ResponseModel<number>) => {
          this.predictedPrice = res.data;
        });
    }
  }
}
