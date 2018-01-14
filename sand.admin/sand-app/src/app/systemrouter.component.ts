import { Routes } from '@angular/router';
import { Component, OnInit, Injectable } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SandHttpService } from './tools/sandHttp.service'
import { DicComponent } from './admin-dic/dic.component';
import { UserComponent } from './admin-users/users.component';
@Injectable()
export class SystemRouterComponent implements OnInit {
  routerList = [];
  constructor(private http: HttpClient, private sandhttp: SandHttpService) {
  }
  ngOnInit() {
  }
}

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '' },
  { path: 'dic', component:DicComponent },
  { path: 'users', component:UserComponent },
  // todo 验证 terminal被替换成了pathMatch，默认为prefix
  { path: '**', redirectTo: '', pathMatch: 'full' }
];