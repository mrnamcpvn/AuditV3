import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../_core/_services/auth.service';
import { Router } from '@angular/router';
import { AlertifyService } from '../../_core/_services/alertify.service';

@Component({
  selector: "app-dashboard",
  templateUrl: "login.component.html"
})
export class LoginComponent implements OnInit {
  user: any = {};

  constructor(
    private authService: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    if (this.authService.loggedIn) this.router.navigate(["/dashboard"]);
  }
  login() {
    console.log(this.user);
    this.authService.login(this.user).subscribe(
      next => {
        this.alertify.success("Login Success!!")
      },
      error => {
        this.alertify.error("Login failed!!")
      },
      () => {
        this.router.navigate(["/dashboard"]);
      }
    );
  }
}
