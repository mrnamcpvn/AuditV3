import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Kind } from '../_models/kind';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { KindService } from '../_services/kind.service';
import { AlertifyService } from '../_services/alertify.service';

@Injectable()
export class KindListResolver implements Resolve<Kind[]> {
    pageNumber = 1;
    pageSize = 3;
    constructor(private kindService: KindService, private router: Router, private alertify: AlertifyService ) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Kind[]> {
        return this.kindService.getKinds(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                this.alertify.error('Problem retrieving data');
                this.router.navigate(['/dashboard']);
                return of(null);
            }),
        );
    }
}
