import { Component, OnInit } from '@angular/core';
import { PaginatedResult, Pagination } from '../../../../_core/_models/pagination';
import { Kind } from '../../../../_core/_models/kind';
import { ActivatedRoute, Router } from '@angular/router';
import { KindService } from '../../../../_core/_services/kind.service';
import { AlertifyService } from '../../../../_core/_services/alertify.service';
import { User } from '../../../../_core/_models/user';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-kind-list',
  templateUrl: './kind-list.component.html',
  styleUrls: ['./kind-list.component.scss']
})
export class KindListComponent implements OnInit {
  kinds: Kind[];
  kind: any = {};
  user: User = JSON.parse(localStorage.getItem('user'));
  pagination: Pagination;

  constructor(private kindService: KindService, private alertify: AlertifyService,
    private router: Router,
    private route: ActivatedRoute, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.spinner.show();
    this.kindService.currentKind.subscribe(kind => this.kind = kind)
    this.route.data.subscribe(data => {
      this.spinner.hide();
      this.kinds = data['kinds'].result;
      this.pagination = data['kinds'].pagination;
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadKinds();
  }

  loadKinds() {
   // this.spinner.show();
    this.kindService.getKinds(this.pagination.currentPage, this.pagination.itemsPerPage)
      .subscribe((res: PaginatedResult<Kind[]>) => {
        this.kinds = res.result;
        this.pagination = res.pagination;
    //    this.spinner.hide();
      }, error => {
        this.alertify.error(error);
      });
  }

  addKind() {
    this.kind = {};
    this.kindService.changeKind(this.kind);
    this.router.navigate(["/maintenance/kind/add"]);
  }

  changeStatus(id: number) {
    this.kindService.changeStatus(id)
      .subscribe(() => {
        this.alertify.success('Change active succeed');
      }, error => {
        this.alertify.error(error);
      });
  }

  changeToEdit(kind: Kind) {
    this.kindService.changeKind(kind);
    this.router.navigate(["/maintenance/kind/add"]);
  }

  deleteKind(kind: Kind) {
    this.alertify.confirm('Delete kind', 'Are you sure you want to delete this Kind name "' + kind.name + '" ?', () => {
      this.kindService.deleteKind(kind.id).subscribe(() => {
        this.loadKinds();
        this.alertify.success('Kind has been deleted');
      }, error => {
        this.alertify.error('Failed to delete the kind');
      });
    });
  }

}
