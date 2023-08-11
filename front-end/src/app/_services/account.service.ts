import { Account } from './../_models/account';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { Observable } from 'rxjs/internal/Observable';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({providedIn: 'root'})
export class AccountService {
  private accountSubject: BehaviorSubject<Account | null>;
  public account: Observable<Account | null> | undefined;
  constructor(private router: Router,private httpClient: HttpClient) {
        this.accountSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('userAccount')!));
        this.account = this.accountSubject.asObservable();
  }

    public get userValue() {
        return this.accountSubject.value;
    }

    login(username: string, password: string) {
        return this.httpClient.post<Account>(`${environment.identityApiUrl}/users/login`, { username, password })
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('user', JSON.stringify(user));
                this.accountSubject.next(user);
                return user;
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('userAccount');
        this.accountSubject.next(null);
        this.router.navigate(['/account/login']);
    }

}
