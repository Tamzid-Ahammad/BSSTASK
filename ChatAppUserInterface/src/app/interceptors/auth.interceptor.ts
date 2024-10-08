import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private router: Router) {

  }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add authorization header with basic auth credentials if available
    if (localStorage.getItem('token') != null) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${localStorage.getItem('token')}`
        }
      });
    }

    return next.handle(request).pipe(
      tap(
        succ => { },
        err => {
          if (err.status == 401) {
            localStorage.removeItem('token');
            this.router.navigateByUrl('/user/login');
          }
          else if (err.status == 403)
            this.router.navigateByUrl('/forbidden');
        }
      )
    )
  }

}
