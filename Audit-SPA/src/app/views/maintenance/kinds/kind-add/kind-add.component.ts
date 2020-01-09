import { Component, OnInit } from '@angular/core';
import { KindService } from '../../../../_core/_services/kind.service';
import { AlertifyService } from '../../../../_core/_services/alertify.service';
import { AuthService } from '../../../../_core/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: "app-kind-add",
  templateUrl: "./kind-add.component.html",
  styleUrls: ["./kind-add.component.scss"]
})
export class KindAddComponent implements OnInit {
  kind: any = {};
  constructor(
    private kindService: KindService,
    private alertify: AlertifyService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit() {
    this.kindService.currentKind.subscribe(kind => this.kind = kind)
    console.log(this.kind)
  }

  backList() {
    this.router.navigate(["/maintenance/kind"])
  }

  addKind() {
    console.log(this.kind);
    if (!this.kind.id) {
      console.log("Add",this.kind);
      this.kindService.createKind(this.kind).subscribe(
        () => {
          this.alertify.success("Add succeed");
          this.router.navigate(["/maintenance/kind"])
        },
        error => {
          this.alertify.error(error);
        }
      );
    } else {
      this.kindService.updateKind(this.kind).subscribe(
        () => {
          this.alertify.success("Updated succeed");
          this.router.navigate(["/maintenance/kind"])
        },
        error => {
          this.alertify.error(error)
        }
      )
    }
  }
}
