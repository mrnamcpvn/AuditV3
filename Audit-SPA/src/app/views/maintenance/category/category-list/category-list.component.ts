import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../../../_core/_services/category.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from '../../../../_core/_services/alertify.service';
import { Category } from '../../../../_core/_models/category';
import { User } from '../../../../_core/_models/user';
import { Pagination, PaginatedResult } from '../../../../_core/_models/pagination';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {

  categories: Category[];
  category: any = {};
  user: User = JSON.parse(localStorage.getItem('user'));
  pagination: Pagination;
  constructor(
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private alertify: AlertifyService) { }

  ngOnInit() {
    this.categoryService.currentCategory.subscribe(category => this.category = category)
    console.log(">>", this.category)
    this.spinner.show(undefined, { fullScreen: true });
    this.route.data.subscribe(data => {
      this.spinner.hide();
      this.categories = data['categories'].result;
      this.pagination = data['categories'].pagination;
    });

    console.log(this.pagination);
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadKinds();
  }

  loadKinds() {
    this.spinner.show(undefined, { fullScreen: true });
    this.categoryService.getCategories(this.pagination.currentPage, this.pagination.itemsPerPage)
      .subscribe((res: PaginatedResult<Category[]>) => {
        this.categories = res.result;
        this.pagination = res.pagination;
        this.spinner.hide();
      }, error => {
        this.alertify.error(error);
      });
  }

  addCategory() {
    this.category = {};
    this.categoryService.changeCategory(this.category);
    this.router.navigate(["/maintenance/category/add"]);
  }

  changeStatus(id: number) {
    this.categoryService.changeStatus(id)
      .subscribe(() => {
        this.alertify.success('Change active succeed');
      }, error => {
        this.alertify.error(error);
      });
  }

  changeToEdit(category: Category) {
    this.categoryService.changeCategory(category);
    this.router.navigate(["/maintenance/category/add"]);
  }

  deleteKind(category: Category) {
    this.alertify.confirm('Delete kind', 'Are you sure you want to delete this Category name "' + category.name + '" ?', () => {
      this.categoryService.deleteCategory(category.id).subscribe(() => {
        this.loadKinds();
        this.alertify.success('Kind has been deleted');
      }, error => {
        this.alertify.error('Failed to delete the kind');
      });
    });
  }
}
