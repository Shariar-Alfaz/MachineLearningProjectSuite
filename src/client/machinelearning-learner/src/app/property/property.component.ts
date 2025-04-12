import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { InputNumberModule } from 'primeng/inputnumber';
import { SelectModule } from 'primeng/select';
import { FormsModule } from '@angular/forms';
import { InitRequestModel, ResponseModel } from '../../models/type/app.type';
import { PropertyService } from '../../services/property/property.service';

@Component({
  selector: 'app-property',
  imports: [
    ButtonModule,
    ToolbarModule,
    CommonModule,
    InputNumberModule,
    SelectModule,
    FormsModule,
  ],
  templateUrl: './property.component.html',
  styleUrl: './property.component.css',
})
export class PropertyComponent {
  initData: InitRequestModel = {
    addresses: [],
    types: [],
  };

  propertyService = inject(PropertyService);

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
}
