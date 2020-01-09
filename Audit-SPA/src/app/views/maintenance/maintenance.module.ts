// Angular
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgxSpinnerModule } from "ngx-spinner";
// Components Routing
import { MaintenanceRoutingModule } from './maintenance-routing.module';
import { KindListComponent } from './kinds/kind-list/kind-list.component';
import { PaginationModule } from 'ngx-bootstrap';
import { KindAddComponent } from './kinds/kind-add/kind-add.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryFormComponent } from './category/category-form/category-form.component';
import { NgSelectModule } from '@ng-select/ng-select';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgxSpinnerModule,
    MaintenanceRoutingModule,
    PaginationModule,
    NgSelectModule
  ],
  declarations: [
    KindListComponent,
    KindAddComponent,
    CategoryListComponent,
    CategoryFormComponent
  ]
})
export class MaintenanceModule {}
