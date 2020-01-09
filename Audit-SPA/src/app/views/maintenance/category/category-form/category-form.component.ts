import { Component, OnInit } from '@angular/core';
import { NgSelectConfig } from "@ng-select/ng-select";
import { CategoryService } from '../../../../_core/_services/category.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../../../_core/_services/alertify.service';
import { KindService } from '../../../../_core/_services/kind.service';
import { Kind } from '../../../../_core/_models/kind';

@Component({
  selector: "app-category-form",
  templateUrl: "./category-form.component.html",
  styleUrls: ["./category-form.component.scss"]
})
export class CategoryFormComponent implements OnInit {
  category: any = {};
  kinds: Kind[];
  constructor(
    private categoryService: CategoryService,
    private kindService: KindService,
    private router: Router,
    private route: ActivatedRoute,
    private ngSelectConfig: NgSelectConfig,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.categoryService.currentCategory.subscribe(
      category => (this.category = category)
    );
    this.loadKinds();
  }

  backList() {
    this.router.navigate(["/maintenance/category"]);
  }

  addCateogry() {
    console.log(this.category);
    if (!this.category.id) {
      console.log("Add", this.category);
      this.categoryService.createCategory(this.category).subscribe(
        () => {
          this.alertify.success("Add succeed");
          this.backList();
        },
        error => {
          this.alertify.error(error);
        }
      );
    } else {
      this.categoryService.updateCategory(this.category).subscribe(
        () => {
          this.alertify.success("Updated succeed");
          this.backList();
        },
        error => {
          this.alertify.error(error);
        }
      );
    }
  }

  //Lấy danh sách tất cả Kind để bỏ vào Select
  loadKinds() {
    this.kindService.getAllKinds().subscribe(
      res => {
        this.kinds = res;
      },
      error => {
        this.alertify.error(error);
      }
    );
  }
}
