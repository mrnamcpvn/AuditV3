import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { PaginatedResult } from '../_models/pagination';
import { Kind } from '../_models/kind';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Bearer ' + localStorage.getItem('token'),
  }),
};
@Injectable({
  providedIn: 'root',
})
export class KindService {
  baseUrl = environment.apiUrl;
  kindSource = new BehaviorSubject<Object>({});
  currentKind = this.kindSource.asObservable();
  constructor(private http: HttpClient) { }

  getKinds(page?, itemsPerPage?): Observable<PaginatedResult<Kind[]>> {
    const paginatedResult: PaginatedResult<Kind[]> = new PaginatedResult<Kind[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }


    return this.http.get<Kind[]>(this.baseUrl + 'kinds', { observe: 'response', params})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        }),
      );
  }

  createKind(kind: Kind) {
    console.log(httpOptions);
    return this.http.post(this.baseUrl +  'kinds/', kind);
  }

  getAllKinds() {
    return this.http.get<Kind[]>(this.baseUrl + 'kinds/all', {});
  }

  changeStatus(id: number) {
    return this.http.post(this.baseUrl + 'kinds/' + id + '/changeStatus', {});
  }

  updateKind(kind: Kind) {
    return this.http.put(this.baseUrl + 'kinds/', kind);
  }

  deleteKind(id: number) {
    return this.http.delete(this.baseUrl + 'kinds/' + id, {});
  }

  changeKind(kind: Kind) {
    this.kindSource.next(kind);
  }

}
