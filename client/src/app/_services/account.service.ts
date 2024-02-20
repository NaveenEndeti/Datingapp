import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  [x: string]: any;
  baseUrl =environment.apiUrl;
  private currentUsersource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUsersource.asObservable();
  

  constructor(private http:HttpClient) { }

  login(model : any) {
    return this.http.post<User>(this.baseUrl + 'account/login',model).pipe(
      map((response: any)=> {
        const user = response;
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUsersource.next(user);
        }
      })
      
      
    )
  }
  
  register(model:any){
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user=>{
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUsersource.next(user);
        }

      })
    )
  }

  setCurrentUser(user:User){
    this.currentUsersource.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUsersource.next(null);

  }


}
