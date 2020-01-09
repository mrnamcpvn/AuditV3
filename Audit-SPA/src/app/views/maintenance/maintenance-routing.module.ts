import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { KindListComponent } from './kinds/kind-list/kind-list.component';
import { KindListResolver } from '../../_core/_resolvers/kind-list.resolver';
import { KindAddComponent } from './kinds/kind-add/kind-add.component';
import { CategoryListComponent } from './category/category-list/category-list.component';
import { CategoryListResolver } from '../../_core/_resolvers/category-list.resolver';
import { CategoryFormComponent } from './category/category-form/category-form.component';



const routes: Routes = [
  {
    path: "",
    data: {
      title: "Maintenance"
    },
    children: [
      {
        path: "kind",
        children:
          [
            {
              path: "",
              component: KindListComponent,
              resolve: { kinds: KindListResolver },
              data: {
                title: "Kind"
              }
            },
            {
              path: "add",
              component: KindAddComponent,
              data: {
                title: "Add new kind"
              }
            }
          ]
      },
      {
        path: "category",
        children:
          [
            {
              path: "",
              component: CategoryListComponent,
              resolve: { categories: CategoryListResolver },
              data: {
                title: "Category"
              }
            },
            {
              path: "add",
              component: CategoryFormComponent,
              data: {
                title: "Add new category"
              }
            }
          ]
      },
    ]
  }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MaintenanceRoutingModule { }
