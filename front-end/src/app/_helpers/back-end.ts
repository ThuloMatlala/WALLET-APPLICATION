import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable, of, throwError, delay, materialize, dematerialize } from 'rxjs';

@Injectable()
export class BackEndInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const { url, method, headers, body } = req;

    return handleRoute();
    function handleRoute(): Observable<HttpEvent<any>> {
      switch (true) {
                case url.endsWith('authorization/Register') && method === 'POST':
                    return register();
                case url.endsWith('authorization/login') && method === 'POST':
                     return login();
                case url.endsWith('Account/{id}/transactions') && method === 'GET':
                    return getTransactions();
                case url.endsWith('Account/{id}/balance') && method === 'GET':
                    return getBalance();
                case url.endsWith('Account/{id}/credit') && method === 'PUT':
                    return creditAccount();
                case url.endsWith('Account/{id}/debit') && method === 'PUT':
                    return debitAccount();
                default:
                    // pass through any requests not handled above
                    return next.handle(req);
      }
      //TODO possibly move these
      function register(): Observable<HttpEvent<any>> {
        throw new Error('Function not implemented.');
      }
      function login(): Observable<HttpEvent<any>> {
        throw new Error('Function not implemented.');
      }
      function getTransactions(): Observable<HttpEvent<any>> {
        throw new Error('Function not implemented.');
      }
      function getBalance(): Observable<HttpEvent<any>> {
        throw new Error('Function not implemented.');
      }
      function creditAccount(): Observable<HttpEvent<any>> {
        throw new Error('Function not implemented.');
      }
      function debitAccount(): Observable<HttpEvent<any>> {
        throw new Error('Function not implemented.');
      }

        // helper functions

        function ok(body?: any) {
            return of(new HttpResponse({ status: 200, body }))
                .pipe(delay(500)); // delay observable to simulate server api call
        }

        function error(message: string) {
            return throwError(() => ({ error: { message } }))
                .pipe(materialize(), delay(500), dematerialize()); // call materialize and dematerialize to ensure delay even if an error is thrown (https://github.com/Reactive-Extensions/RxJS/issues/648);
        }

        function basicDetails(user: any) {
            const { id, username } = user;
            return { id, username};
        }
    }

  }
}


